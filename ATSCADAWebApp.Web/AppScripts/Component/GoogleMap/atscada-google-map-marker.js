
import { AtscadaDispatcher } from '../../Core/Common/atscada-dispatcher.js'
import { AtscadaTaskModel } from '../../Core/Component/Task/atscada-task-model.js'
import { AtscadaTaskMultiModel } from '../../Core/Component/Task/atscada-task-multi-model.js'
import { AtscadaParamItemElement } from './atscada-google-map-param.js'

// This class have purposes to get data when tool in 'realtime' mode
export class AtscadaGoogleMapMarker extends HTMLElement {
    constructor() {
        super();
        this.attachShadow({ mode: 'open' });
        this.shadowRoot.innerHTML = `<slot></slot>`;

        this.alias = 'Marker Item';
        this.color = '#00acac';
        this.locationTagName = 'TaskName.TagName';
        this.url = 'http://';
        this.show = 'checked';
        this.newTab = 'checked';
        this.movable = 'checked';
        this.table = 'datalog';
        this.paramItems = [];
        this.dataTagNames = [];

        this.bound = [];
        this.markers = [];
        this.locations = [];       
        this.retrieveData = [];
        this.polylines = [];
        this.dotMarker = [];
        this.countUp = 0;
       
        this.map = undefined;
        this.modeButton = undefined;
        this.selectionTag = undefined;
        this.applicationName = undefined;
        this.dispatcher = new AtscadaDispatcher();

        this.isLoaded = false;
        this.listen();       
    }

    listen() {
        let check = false;
        const slot = this.shadowRoot.querySelector('slot');
        slot.addEventListener('slotchange', (e) => {
            const itemElements = e.target.assignedElements();
            itemElements.forEach((itemElement) => {
                if (itemElement instanceof AtscadaParamItemElement) {
                    this.dataTagNames.push(itemElement.paramTagName);
                    this.paramItems.push({
                        name: itemElement.paramTagName,
                        alias: itemElement.alias
                    });
                }
                check = true;
            });

            if (check) {
                check = false;
                this.isLoaded = true;
                this.paramInit();
                this.dispatcher.dispatch('loaded', {});
            }           
        });
    }

    connectedCallback() {
        this.alias = this.getAttribute('at-alias') || this.alias;
        this.color = this.getAttribute('at-color') || this.color;
        this.locationTagName = this.getAttribute('at-location-tag-name') || this.locationTagName;
        this.show = this.getAttribute('at-show') || this.show;
        this.table = this.getAttribute('at-table') || this.table;
        this.newTab = this.getAttribute('at-new-tab') || this.newTab;
        this.url = this.getAttribute('at-url') || this.url;
        this.movable = this.getAttribute('at-movable') || this.movable;

        // Add location tag
        this.dataTagName = this.locationTagName;
        this.model = new AtscadaTaskModel(this);        
        this.model.initialize();
    }

    paramInit() {
        // Add parameter tags
        this.models = new AtscadaTaskMultiModel(this);
        this.models.initialize();
    }

    initialize() {
        const locationData = this.model.dataTag;
        this.paramData = this.models.dataTags;
        var length = this.paramData.length;

        // Register event of tags
        if (locationData) {
            locationData.dispatcher.on('valueChanged', (data) => this.actionLocValueChanged(data.e.newValue));
            this.actionLocValueChanged(locationData.value);
        }

        // Make sure that all of param tags are having value (not null)
        var lastParam = this.paramData[length - 1];
        if (lastParam) {
            // Need to set delay timeout cause status of last tag cannot update on time
            lastParam.dispatcher.on('valueChanged', (data) => setTimeout(() => {
                this.actionParamValueDone(data.e.newValue), 100}))
        }

        // Google map GeoCoding & InfoWindow
        this.geocoder = new google.maps.Geocoder();
        this.beginInfowindow = new google.maps.InfoWindow();
        this.endInfowindow = new google.maps.InfoWindow();      

        // Create new Marker
        this.startMarker = new google.maps.Marker({
            zIndex: 0
        });
        this.stopMarker = new google.maps.Marker({
            zIndex: 1
        });

        this.startMarker.addListener("click", () => this.redirectLink());
        this.stopMarker.addListener("click", () => this.redirectLink());

        this.stopMarker.addListener("mouseover", () => this.showInfoWindow());
        this.map.addListener("click", () => this.hideInfowindow());

        this.markers.push({
            name: 'startMarker',
            lat: 0,
            lng: 0
        }, {
            name: 'endMarker',
            address: 'undefined',
            lat: 0,
            lng: 0
        }, {
            name: 'dotMarker',
            lat: 0,
            lng: 0
        });

        this.selectionTag.addEventListener('change', () => {
            var mode = this.modeButton.textContent;
            if (mode == "History") return;
            this.showLayers();
        });
    }

    actionLocValueChanged(data) {
        var index = this.selectionTag.selectedIndex;
        var selection = this.selectionTag.options[index].text;

        // If tag is not movable, dont need to update value of tag
        if (this.countUp > 1) return;
        if (this.movable == 'unchecked') {
            this.countUp++;
        }       

        var value = data;
        var str = String(value).split(";", 2);
        var latitude = parseFloat(str[0]);
        var longitude = parseFloat(str[1]);
        var length = this.locations.length;
        if (isNaN(latitude) || isNaN(longitude)) return;
        
        // First scan
        if (length == 0) {
            this.locations.push({
                lat: latitude,
                lng: longitude
            });

            this.markers[0].lat = latitude;
            this.markers[0].lng = longitude;
        }
        else {
            var lat = this.locations[length - 1].lat;
            var lng = this.locations[length - 1].lng;

            // Only update new value of location
            if (latitude != lat && longitude != lng) {
                this.locations.push({
                    lat: latitude,
                    lng: longitude
                });
            }
        }

        // Set bounds for map
        this.bound.push({
            latlng: new google.maps.LatLng(latitude, longitude)
        });

        var count = this.locations.length;       
        this.markers[1].lat = this.locations[count - 1].lat;
        this.markers[1].lng = this.locations[count - 1].lng; 

        // Proceed functions
        if (count > 0) {
            this.drawPolyline();
            this.setMarker();
            if (selection == this.alias) {
                this.fitBounds(count);
            }
            else {
                // IMPORTANT
                this.dispatcher.dispatch('fitBounds', {});
            }
        } 
    }

    actionParamValueDone(data) {
        if (!data) return;
        var html = '';
        var today = new Date();
        var date = today.getDate() + '/' + (today.getMonth() + 1) + '/' + today.getFullYear();
        var time = today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
        var now = date + ' ' + time;

        for (const param of this.paramData) {
            for (const item of this.paramItems) {
                if (param.name == item.name) {
                    html = html + '<b>' + item.alias + ': </b>' + + param.value + ' (' + param.status + ')' + '<br>';
                    continue;
                }
            }
        }

        var mode = 0;
        this.geocodeLatLng(mode);
        this.startMarker.addListener("mouseover", () => this.showStartInfoWindow(html, now));
        this.map.addListener("click", () => this.hideInfowindow());
    }

    drawPolyline() {
        var mode = this.modeButton.textContent;
        var index = this.selectionTag.selectedIndex;
        var selection = this.selectionTag.options[index].text;

        // Draw new polyline
        var length = this.locations.length;
        if (length < 2) return;
        var startDraw = this.locations[length - 2];
        var endDraw = this.locations[length - 1];
        var drawPolyline = [];

        drawPolyline.push({
            lat: startDraw.lat,
            lng: startDraw.lng
        }, {
            lat: endDraw.lat,
            lng: endDraw.lng
        });

        var polyline = new google.maps.Polyline({
            path: drawPolyline,
            geodesic: true,
            strokeColor: this.color,
            strokeOpacity: 0.9,
            strokeWeight: 5,
        });
        polyline.setMap(this.map);
        this.polylines.push(polyline);

        // Allow to show on map
        if ((mode == 'Realtime') && (selection == 'All' || selection == this.alias)) {
            polyline.setVisible(true);
        }
        else {
            polyline.setVisible(false);
        }       

        // Set value to set Marker for center dot
        this.markers[2].lat = endDraw.lat;
        this.markers[2].lng = endDraw.lng;

        // Set information for tooltip
        var html = '';
        var today = new Date();
        var date = today.getDate() + '/' + (today.getMonth() + 1) + '/' + today.getFullYear();
        var time = today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
        var now = date + ' ' + time;

        for (const param of this.paramData) {
            for (const item of this.paramItems) {
                if (param.name == item.name) {
                    html = html + '<b>' + item.alias + ': </b>' + + param.value + ' (' + param.status + ')' + '<br>';
                    continue;
                }
            }
        }

        // Register event of polyline
        var infoWindow = new google.maps.InfoWindow();
        polyline.addListener("mouseover", (mapsMouseEvent) => {

            // Set position for infowindow
            infoWindow.setPosition(mapsMouseEvent.latLng);

            // Convert data to json
            var json = JSON.stringify(mapsMouseEvent.latLng.toJSON(), null, 2);
            var latitude = json.split(",", 2)[0].split(":", 2)[1].split(" ", 2)[1];
            var longitude = json.split(",", 2)[1].split(":", 2)[1].split("}", 2)[0].split(" ", 3)[1];

            infoWindow.setContent(
                '<b>DateTime:</b> ' + now + '<br>' +
                '---<br>' + html);
            infoWindow.open(this.map);
        });

        this.map.addListener("click", () => {
            infoWindow.close();
        });
    }

    setMarker() {
        var mode = this.modeButton.textContent;
        var index = this.selectionTag.selectedIndex;
        var selection = this.selectionTag.options[index].text;
        var coordinates = this.markers;
        var label = this.alias;
        var length = label.length;
        const latlngStart = {
            lat: coordinates[0].lat,
            lng: coordinates[0].lng
        };

        const latlngEnd = {
            lat: coordinates[1].lat,
            lng: coordinates[1].lng
        };

        const latlngDot = {
            lat: coordinates[2].lat,
            lng: coordinates[2].lng
        };

        var dotMarker = null;
        if (latlngDot.lat != 0 && latlngDot.lng != 0) {
            dotMarker = new google.maps.Marker();
            dotMarker.setPosition(latlngDot);
            dotMarker.setMap(this.map);
            dotMarker.setIcon(this.applicationName + '/Image/map_pin_17px.png');
            this.dotMarker.push(dotMarker);
        }

        this.startMarker.setPosition(latlngStart);
        this.startMarker.setMap(this.map);
        this.startMarker.setIcon(this.applicationName + '/Image/home_35px.png');

        this.stopMarker.setPosition(latlngEnd);
        this.stopMarker.setMap(this.map);       
        this.stopMarker.setLabel(label.substring(0, 1) + label.substring(length - 1, length));

        // Allow to show on map
        if ((mode == 'Realtime') && (selection == 'All' || selection == this.alias)) {
            this.startMarker.setVisible(true);
            this.stopMarker.setVisible(true);
            if (dotMarker) {
                dotMarker.setVisible(true);
            }
        }
        else {
            this.startMarker.setVisible(false);
            this.stopMarker.setVisible(false);            
            if (dotMarker) {
                dotMarker.setVisible(false);
            }
        }
    }

    fitBounds(count) {
        var mode = this.modeButton.textContent;
        var index = this.selectionTag.selectedIndex;
        var selection = this.selectionTag.options[index].text;

        // Allow to show on map
        if ((mode == 'Realtime') && (selection == 'All' || selection == this.alias)) {
            var getBounds = new google.maps.LatLngBounds();
            for (var i = 0; i < count; i++) {
                getBounds.extend(this.bound[i].latlng);
            }
            this.map.fitBounds(getBounds);
        }
    }

    showStartInfoWindow(html, now) {
        var startMarker = this.markers[0];
        this.beginInfowindow.setContent(
            '<b>DateTime:</b> ' + now + '<br>' +
            '<b>Location:</b> ' + startMarker.address + '<br>' +
            '---<br>' + html);

        this.beginInfowindow.open(this.map, this.startMarker);
    }

    showInfoWindow() {       
        var today = new Date();
        var date = today.getDate() + '/' + (today.getMonth() + 1) + '/' + today.getFullYear();
        var time = today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
        var now = date + ' ' + time;
        var html = '';               

        // If old value are different with new value, call API 'Geocoder' function 
        if (this.retrieveData[0] != this.markers[1].lat &&
            this.retrieveData[1] != this.markers[1].lng) {
            var mode = 1;
            this.geocodeLatLng(mode);

            // Need to delay to function 'Geocoder' can get data of location map
            setTimeout(() => {
                this.retrieveData[0] = this.markers[1].lat;
                this.retrieveData[1] = this.markers[1].lng;
            }, 300);
        }

        // Need to delay to show Infowindow
        setTimeout(() => {
            var endMarker = this.markers[1];
            for (const param of this.paramData) {
                for (const item of this.paramItems) {
                    if (param.name == item.name) {
                        html = html + '<b>' + item.alias + ': </b>' + + param.value + ' (' + param.status + ')' + '<br>';
                        continue;
                    }
                }
            }

            this.endInfowindow.setContent(
                '<b>DateTime:</b> ' + now + '<br>' +
                '<b>Location:</b> ' + endMarker.address + '<br>' +
                '---<br>' + html);

            this.endInfowindow.open(this.map, this.stopMarker);
        }, 300);
    }

    hideInfowindow() {
        this.beginInfowindow.close();
        this.endInfowindow.close();
    }

    geocodeLatLng(mode) {
        var geocoder = this.geocoder;
        var lat = '';
        var lng = '';

        if (mode == "0") {
            lat = this.markers[0].lat;
            lng = this.markers[0].lng;
        }
        else {
            lat = this.markers[1].lat;
            lng = this.markers[1].lng;
        }

        if ((isNaN(lat)) || (isNaN(lng))) return;
        const latlng = {
            lat: lat,
            lng: lng
        };

        geocoder
            .geocode({ location: latlng })
            .then((response) => {
                if (response.results[0]) {
                    if (mode == "0") {
                        this.markers[0].address = response.results[0].formatted_address;
                    }
                    else {
                        this.markers[1].address = response.results[0].formatted_address;
                    }                   
                }
                else {
                    window.alert("No results found");
                }
            })
            .catch((e) => window.alert("Geocoder failed due to: " + e));
    }

    showLayers() {
        var count = this.locations.length;
        var index = this.selectionTag.selectedIndex;
        var selection = this.selectionTag.options[index].text;
        if (selection == "All") return;
        if (selection != this.alias) {
            this.hideLayers();
            return;
        }

        // Show all of instances
        this.startMarker.setVisible(true);
        this.stopMarker.setVisible(true);
        for (const marker of this.dotMarker) {
            marker.setVisible(true);
        }
        for (const polyline of this.polylines) {
            polyline.setVisible(true);
        }

        // Fit bounds
        var getBounds = new google.maps.LatLngBounds();
        for (var i = 0; i < count; i++) {
            getBounds.extend(this.bound[i].latlng);
        }
        this.map.fitBounds(getBounds);
    }

    hideLayers() {
        this.startMarker.setVisible(false);
        this.stopMarker.setVisible(false);
        this.beginInfowindow.close();
        this.endInfowindow.close();

        for (const marker of this.dotMarker) {
            marker.setVisible(false);
        }

        for (const polyline of this.polylines) {
            polyline.setVisible(false);
        }
    }

    redirectLink() {
        if (this.url == '' || this.url === 'http://') return;
        if (this.url.includes('http')) {
            if (this.newTab == 'checked') {
                window.open(this.url, '_blank');
            }
            else {
                window.open(this.url, '_parent');
            }
        }
        else if (this.url.includes('~/')) {
            window.location.hash = `/${this.url.split('/')[1]}`;
        }
    }

    disconnectedCallback() {
        if (this.model) 
            this.model.dispose();
        if (this.models) 
            this.models.dispose();

        let child = this.lastElementChild;
        while (child) {
            this.removeChild(child);
            child = this.lastElementChild;
        }
        this.remove();
    }
}

customElements.define('atscada-marker-item', AtscadaGoogleMapMarker);