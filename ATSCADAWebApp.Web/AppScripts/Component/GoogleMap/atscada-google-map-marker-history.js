
// This class have purposes to get data when tool in 'history' mode
export class AtscadaGoogleMapMarkerHistory {
    constructor(applicationName, map, selection, alias, color, newTab, url, movable, database) {
        this.applicationName = applicationName;
        this.map = map;
        this.selectionTag = selection;
        this.alias = alias;
        this.color = color;
        this.newTab = newTab;
        this.url = url;
        this.movable = movable;
        this.database = database;

        this.markers = [];
        this.dotMarker = [];
        this.locations = [];
        this.route = undefined;

        // Create Google Map Marker && Polyline
        this.startMarker = new google.maps.Marker({
            zIndex: 1
        });

        this.stopMarker = new google.maps.Marker({
            zIndex: 2
        });

        this.truck = new google.maps.Marker({
            zIndex: 3,
            icon: this.applicationName + '/Image/lorry_35px.png'
        });

        this.polyline = new google.maps.Polyline({
            geodesic: true,
            strokeColor: this.color,
            strokeOpacity: 1,
            strokeWeight: 4,
            zIndex: 2
        });
    }

    initialize() {
        if (typeof (this.markers) !== 'undefined') {
            delete this.markers;
            this.markers = [];
        }

        this.markers.push({
            name: 'startMarker',
            datetime: '',
            html: '',
            lat: 0,
            lng: 0
        }, {
            name: 'endMarker',
            datetime: '',
            html: '',
            lat: 0,
            lng: 0
        });

        this.drawPolyline();
        this.setMarker();

        this.startMarker.addListener("click", () => this.redirectLink());
        this.stopMarker.addListener("click", () => this.redirectLink());
    }

    setMarker() {
        var html = '';
        var length = this.database.length;
        var oldLat = undefined;
        var oldLng = undefined;
        var label = this.alias;
        var lengthLabel = label.length;
        var countDot = 0;

        // Create markers
        for (var i = 0; i < length; i++) {
            var table = this.database[i];
            var datetime = table.DateTime;
            var location = table.Location.split(';', 2);
            var latitude = parseFloat(location[0]);
            var longitude = parseFloat(location[1]);                      
            
            var latlng = {
                lat: latitude,
                lng: longitude
            }

            for (const column in table) {
                var name = column;
                var value = table[column];
                if (name == 'DateTime' || name == 'Location')
                    continue;
                else
                    html = html + '<b>' + name + ': </b>' + + value + '<br>';
            }

            if (isNaN(latitude) || isNaN(longitude)) continue;
            if (i == length - 1) {
                // Create stop marker
                this.stopMarker.setPosition(latlng);
                this.stopMarker.setMap(this.map);
                this.stopMarker.setVisible(true);
                this.stopMarker.setLabel(label.substring(0, 1) + label.substring(lengthLabel - 1, lengthLabel));

                // Set value
                this.markers[1].lat = latitude;
                this.markers[1].lng = longitude;
                this.markers[1].datetime = datetime;
                this.markers[1].html = html;
                html = '';

                if (this.movable == 'checked') {
                    // Create infowindow
                    var inforWindow1 = new google.maps.InfoWindow();
                    this.map.addListener("click", () => inforWindow1.close());
                    this.stopMarker.addListener("mouseover", (mapsMouseEvent) => {
                        var endMarker = this.markers[1];
                        inforWindow1.setPosition(mapsMouseEvent.latLng);
                        inforWindow1.setContent(
                            '<b>DateTime:</b> ' + endMarker.datetime + '<br>' +
                            '---<br>' + endMarker.html);

                        inforWindow1.open(this.map, this.stopMarker);
                    });
                }             
            }
            else {
                if (this.movable == 'unchecked') {
                    html = '';
                    continue;
                }
                if (oldLat == latitude && oldLng == longitude) {
                    html = '';
                    continue;
                }                  
                else {
                    oldLat = latitude;
                    oldLng = longitude;
                }
                
                if (i == 0) {
                    // Create start marker             
                    this.startMarker.setPosition(latlng);
                    this.startMarker.setMap(this.map);
                    this.startMarker.setVisible(true);
                    this.startMarker.setIcon(this.applicationName + '/Image/home_35px.png');

                    // Set value
                    this.markers[0].lat = latitude;
                    this.markers[0].lng = longitude;
                    this.markers[0].datetime = datetime;
                    this.markers[0].html = html;
                    html = '';

                    // Create infowindow
                    var infoWindow2 = new google.maps.InfoWindow();
                    this.map.addListener("click", () => infoWindow2.close());
                    this.startMarker.addListener("mouseover", (mapsMouseEvent) => {
                        var startMarker = this.markers[0];
                        infoWindow2.setPosition(mapsMouseEvent.latLng);
                        infoWindow2.setContent(
                            '<b>DateTime:</b> ' + startMarker.datetime + '<br>' +
                            '---<br>' + startMarker.html);
                        infoWindow2.open(this.map, this.startMarker);
                    });
                }
                else {
                    // Create dot marker
                    countDot++;
                    const marker = new google.maps.Marker({
                        zIndex: 0
                    });
                    marker.setPosition(latlng);
                    marker.setMap(this.map);
                    marker.setIcon(this.applicationName + '/Image/map_pin_17px.png');
                    marker.setVisible(true);
                    this.dotMarker.push(marker);

                    // Set value
                    this.markers.push({
                        name: 'dotMarker' + countDot,
                        datetime: datetime,
                        html: html,
                        lat: latitude,
                        lng: longitude
                    });
                    html = '';

                    // Create infowindow
                    const infoWindow3 = new google.maps.InfoWindow();
                    this.map.addListener("click", () => infoWindow3.close());
                    marker.addListener("mouseover", (mapsMouseEvent) => {
                        var letLng = mapsMouseEvent.latLng;                                          
                        // Convert data to json
                        var json = JSON.stringify(letLng.toJSON(), null, 2);
                        var vido = parseFloat(json.split(",", 2)[0].split(":", 2)[1].split(" ", 2)[1]);
                        var kinhdo = parseFloat(json.split(",", 2)[1].split(":", 2)[1].split("}", 2)[0].split(" ", 3)[1]);

                        for (const dot of this.markers) {
                            if (dot.lat == vido && dot.lng == kinhdo) {                                
                                infoWindow3.setContent(
                                    '<b>DateTime:</b> ' + dot.datetime + '<br>' +
                                    '---<br>' + dot.html);
                                infoWindow3.setPosition(letLng);
                                infoWindow3.open(this.map, marker);
                                break;
                            }
                        }
                    });
                }
            }
        }
    }

    drawPolyline() {       
        var countUp = 1;
        var length = this.database.length;
        if (length <= 1) return;
        for (const row of this.database) {
            var coordinate = row.Location.split(';',2);
            var lat = parseFloat(coordinate[0]);
            var lng = parseFloat(coordinate[1]);
            if (isNaN(lat) || isNaN(lng)) return;

            if (countUp == this.database.length) {
                if (this.movable == 'unchecked') {
                    this.locations = [];
                    this.locations.push({
                        lat: lat,
                        lng: lng
                    });
                    return;
                }
            }
            else {
                this.locations.push({
                    lat: lat,
                    lng: lng
                });
                countUp++;
            }  
        }      
        this.polyline.setPath(this.locations);
        this.polyline.setMap(this.map);
        this.polyline.setVisible(true);
    }

    tracking(speed, mode, selection) {
        if (this.movable == 'unchecked') return;
        if (this.database.length < 1) return;
        var check = false;
        var oldLat = undefined;
        var oldLng = undefined;
        var oldDate = undefined;
        this.route = [];

        setTimeout(async () => {
            var previousPath;
            for (const route of this.database) {
                // Not allow to select list of location tags
                if (selection.disabled == false)
                    selection.disabled = true;
                var coordinate = route.Location.split(';', 2);
                var latitude = parseFloat(coordinate[0]);
                var longtitude = parseFloat(coordinate[1]);
                var datetime = route.DateTime.split(' ', 2);
                var day = datetime[0].split('/', 3);
                var time = datetime[1];
                var convertDate = day[1] + '/' + day[0] + '/' + day[2] + ' ' + time;
                var newDate = new Date(convertDate);

                // Check duplicate coordinates
                if (latitude == oldLat && longtitude == oldLng) continue;
                oldLat = latitude;
                oldLng = longtitude;
                var path = {
                    lat: latitude,
                    lng: longtitude
                };

                // Delay time - Simulation
                if (oldDate != undefined) {
                    var deltaX = (parseFloat(path.lat) - parseFloat(previousPath.lat)) / 100;
                    var deltaY = (parseFloat(path.lng) - parseFloat(previousPath.lng)) / 100;                   
                    var previous;               

                    for (var i = 0; i < 100; i++) {
                        var chedo = mode.textContent;
                        if (chedo == 'History') {
                            // Not allow to select list of location tags
                            if (selection.disabled == false)
                                selection.disabled = true;
                            var index = speed.selectedIndex;
                            var tocdo = parseFloat(speed.options[index].text.split('x', 2)[1]);
                            // newDate - oldDate = ms Unit
                            // Chia 100: 100 diem toa do, chia tocdo: setting tren web
                            // Chia 1000: doi sang don vi ms, chia 60: quy doi 60m = 1s
                            var deltaT = Math.round((newDate - oldDate) / (100 * tocdo * 1000 * 60), 0);

                            var toadoX = parseFloat(previousPath.lat) + i * deltaX;
                            var toadoY = parseFloat(previousPath.lng) + i * deltaY;
                            var latlng = {
                                lat: toadoX,
                                lng: toadoY
                            }
                            this.simulate(latlng);
                            this.draw(previous, latlng);
                            previous = latlng;
                            await this.sleep(deltaT);
                        }
                        else {
                            check = true;
                            break;
                        }
                    }
                }
                
                previousPath = path;
                oldDate = newDate;

                if (check) {
                    for (var poly of this.route) {
                        poly.setVisible(false);
                    }
                    this.truck.setVisible(false);
                    break;
                }
            }
            selection.disabled = false;
        }, 1000);
    }

    draw(previousPath, path) {
        if (previousPath && path) {
            var draw = new google.maps.Polyline({
                path: [previousPath, path],
                geodesic: true,
                strokeColor: '#FFFF00',
                strokeOpacity: 1,
                strokeWeight: 8,
                fillColor: '#FFFF00',
                fillOpacity: 1,
                zIndex: 1
            });

            draw.setMap(this.map);
            draw.setVisible(true);
            this.route.push(draw);
        }
    }

    simulate(latlng) {
        this.truck.setPosition(latlng);
        this.truck.setMap(this.map);
        this.truck.setVisible(true);       
    }

    showLayers() {
        this.startMarker.setVisible(true);
        this.stopMarker.setVisible(true);
        this.polyline.setVisible(true);
        for (const marker of this.dotMarker) {
            marker.setVisible(true);
        }
    }

    hideLayers() {
        this.startMarker.setVisible(false);
        this.stopMarker.setVisible(false);
        this.polyline.setVisible(false);
        this.truck.setVisible(false);
        for (const marker of this.dotMarker) {
            marker.setVisible(false);
        }
    }

    fitBounds() {
        var lastLat = undefined;
        var lastLng = undefined;
        var coordinates = [];
        var value = this.locations;
        if (this.movable == 'unchecked') {
            if (this.database.length > 1) return;
            var coord = this.database[0].Location.split(';', 2);
            value.push({
                lat: parseFloat(coord[0]),
                lng: parseFloat(coord[1])
            });
        }

        for (const latlng of value) {
            var lat = latlng.lat;
            var lng = latlng.lng;
            if (lat != lastLat || lng != lastLng) {
                lastLat = lat;
                lastLng = lng;
                coordinates.push({
                    latlng: new google.maps.LatLng(lat, lng)
                });
            }
        }

        var length = coordinates.length;
        var getBounds = new google.maps.LatLngBounds();
        for (var i = 0; i < length; i++) {
            getBounds.extend(coordinates[i].latlng);
        }
        this.map.fitBounds(getBounds);
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

    sleep(ms) {
        return new Promise((resolve) => setTimeout(resolve, ms));
    }

    dispose() { }
}