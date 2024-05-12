
import { AtscadaDispatcher } from '../../Core/Common/atscada-dispatcher.js'
import { AtscadaGoogleMapMarkerHistory } from './atscada-google-map-marker-history.js'

export class AtscadaGoogleMapView {
    constructor(model, element) {
        this.model = model;
        this.element = element;
        this.applicationName = this.element.applicationName;
        this.modeButton = this.element.modeButtonElement;
        this.selectionTag = this.element.selectionTags;
        this.speed = this.element.speed;
        this.playButtonElement = this.element.playButtonElement;
        this.realtimeButtonElement = this.element.realtimeButtonElement;
        this.historyButtonElement = this.element.historyButtonElement;
        this.dateRangePickerElement = this.element.dateRangePickerElement;
        this.dispatcher = new AtscadaDispatcher();

        this.realtimeMarkers = this.element.items;
        this.historyMarkers = [];
        this.map = undefined;
        this.getBounds = undefined;
        this.oldStart = undefined;
        this.newStart = undefined;
        this.oldEnd = undefined;
        this.newEnd = undefined;
    }

    initialize() {
        // Register events
        this.speed.selectedIndex = 2;
        this.speed.disabled = true;
        this.playButtonElement.disabled = true;
        this.selectionTag.addEventListener('change', () => {
            var mode = this.modeButton.textContent;
            if (mode == "Realtime") {
                this.showRealtimeLayers();
            }
            else {
                this.showHistoryLayers();
            }
        });
        this.playButtonElement.addEventListener('click', () => this.trackingHistory());
        this.realtimeButtonElement.addEventListener('click', () => {
            this.selectionTag.selectedIndex = 0;
            this.speed.selectedIndex = 2;
            this.modeButton.innerHTML = "Realtime";
            this.showRealtimeLayers();
            this.hideHistoryLayers();

            this.speed.disabled = true;
            this.playButtonElement.disabled = true;            
        });

        this.historyButtonElement.addEventListener('click', () => {
            this.selectionTag.selectedIndex = 0;
            this.modeButton.innerHTML = "History";
            this.hideRealtimeLayers();
            this.speed.disabled = false;
            this.playButtonElement.disabled = false;            

            if (this.dateRangePickerElement.startDate != this.oldStart || this.dateRangePickerElement.endDate != this.oldEnd) {
                this.oldStart = this.dateRangePickerElement.startDate;
                this.oldEnd = this.dateRangePickerElement.endDate;
                this.hideHistoryLayers();
                delete this.historyMarkers;
                delete this.getBounds;
                this.historyMarkers = [];
                this.getBounds = undefined;
                this.dispatcher.dispatch('historyButtonClicked', {});
            }
            else {
                this.showHistoryLayers();
                this.hideRoute();
            }
        });
    }

    showRealtimeLayers() {
        var index = this.selectionTag.selectedIndex;
        var selection = this.selectionTag.options[index].text;
        if (selection != "All") return;

        var bounds = [];
        for (const marker of this.realtimeMarkers) {
            // Show all of instances
            marker.startMarker.setVisible(true);
            marker.stopMarker.setVisible(true);
            for (const dotmarker of marker.dotMarker) {
                dotmarker.setVisible(true);
            }
            for (const polyline of marker.polylines) {
                polyline.setVisible(true);
            }

            // Get coordinates to set bounds
            for (const location of marker.locations) {
                bounds.push({
                    latlng: new google.maps.LatLng(location.lat, location.lng)
                });
            }
        }

        // Fit bounds
        var getBounds = new google.maps.LatLngBounds();
        for (var i = 0; i < bounds.length; i++) {
            getBounds.extend(bounds[i].latlng);
        }
        this.map.fitBounds(getBounds);
    }

    hideRealtimeLayers() {
        for (const marker of this.realtimeMarkers) {
            // Hide all of instances
            marker.startMarker.setVisible(false);
            marker.stopMarker.setVisible(false);
            for (const dotmarker of marker.dotMarker) {
                dotmarker.setVisible(false);
            }
            for (const polyline of marker.polylines) {
                polyline.setVisible(false);
            }
        }
    }

    initHistory(data) {
        var count = 0;
        var lastLat = undefined;
        var lastLng = undefined;
        var locations = [];
        var temporary = [];
        for (const marker of this.realtimeMarkers) {
            var value = data[count].Data;
            if (value.length == 0 && marker.movable == 'unchecked') {
                value.push({
                    Location: marker.locations[0].lat + ';' + marker.locations[0].lng
                });
                temporary.push({
                    lat: parseFloat(marker.locations[0].lat),
                    lng: parseFloat(marker.locations[0].lng)
                });
            }
            var mark = new AtscadaGoogleMapMarkerHistory(this.applicationName, this.map, this.selectionTag, marker.alias, marker.color,
                marker.newTab, marker.url, marker.movable, value);
            mark.initialize();
            this.historyMarkers.push(mark);
            count++;
        }

        for (const marker of this.historyMarkers) {
            if (marker.movable == 'unchecked') {
                marker.locations = temporary;
            }
            for (const latlng of marker.locations) {
                var lat = latlng.lat;
                var lng = latlng.lng;
                if (lat != lastLat || lng != lastLng) {
                    lastLat = lat;
                    lastLng = lng;
                    locations.push({
                        latlng: new google.maps.LatLng(lat, lng)
                    });
                }
            }
        }

        var length = locations.length;
        this.getBounds = new google.maps.LatLngBounds();
        for (var i = 0; i < length; i++) {
            this.getBounds.extend(locations[i].latlng);
        }
        this.map.fitBounds(this.getBounds);
    }

    showHistoryLayers() {
        var index = this.selectionTag.selectedIndex;
        var selection = this.selectionTag.options[index].text;

        if (selection == "All") {
            for (const marker of this.historyMarkers) {
                this.hideRoute();
                marker.showLayers();
            }
            this.map.fitBounds(this.getBounds);
        }
        else {
            for (const marker of this.historyMarkers) {
                if (selection == marker.alias) {
                    this.hideRoute();
                    marker.showLayers();
                    marker.fitBounds();
                }
                else {
                    marker.hideLayers();
                }
            }
        }
    }

    hideHistoryLayers() {
        for (const marker of this.historyMarkers) {
            marker.hideLayers();
        }
        this.hideRoute();
    }

    hideRoute() {
        for (const marker of this.historyMarkers) {
            marker.truck.setVisible(false);
            if (typeof(marker.route) !== 'undefined') {
                for (const route of marker.route) {
                    route.setVisible(false);
                }
            }   
        }
    }

    trackingHistory() {
        var mode = this.modeButton.textContent;
        var index = this.selectionTag.selectedIndex;
        var selection = this.selectionTag.options[index].text;
        if (mode == 'Realtime') return;

        if (selection == "All") {
            for (const marker of this.historyMarkers) {
                this.hideRoute();
                marker.tracking(this.speed, this.modeButton, this.selectionTag);
            }
        }
        else {
            for (const marker of this.historyMarkers) {
                this.hideRoute();
                if (selection == marker.alias) {                   
                    marker.tracking(this.speed, this.modeButton, this.selectionTag);
                    return;
                }               
            }
        } 
    }

    dispose() { }
}