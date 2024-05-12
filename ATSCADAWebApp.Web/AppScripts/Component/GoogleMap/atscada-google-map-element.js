
const template = document.createElement('template');
template.innerHTML = `
    <div class="panel panel-default panel-hover-icon">
        <div class="panel-heading">
            <h4 class="panel-title atscada-google-map-content"></h4>
        </div>
        <div class="panel-toolbar">
            <div class="row">
                <div class="col-sm-4">
                    <atscada-date-range-picker></atscada-date-range-picker>
                </div>
                <div class="col-sm-2">
                    <div class="input-group">
                        <select class="atscada-gps-list form-select form-select" placeholder="Selection Tags" title="Selection Tags">
                            <option>All</option>
                        </select>                       
                    </div>
                </div>
                <div class="col-sm-1">
                    <div class="input-group">
                        <select class="atscada-gps-speed form-select form-select" placeholder="Simulation Speed" title="Simulation Speed">
                            <option>x0.25</option>
                            <option>x0.5</option>
                            <option>x1</option>
                            <option>x5</option>
                            <option>x10</option>
                            <option>x20</option>
                        </select>
                    </div>
                </div>
                <div class="col-sm-1">
                    <div class="btn-group">
                        <button type="button" class="atscada-google-map-mode btn btn-primary">Realtime</button>
                        <button type="button" class="btn btn-primary dropdown-toggle" data-bs-toggle="dropdown"><b class="caret"></b></button>
                        <div class="dropdown-menu dropdown-menu-end mr-3">
                            <a class="atscada-google-map-realtime dropdown-item">Realtime</a>
                            <a class="atscada-google-map-history dropdown-item">History</a>
                        </div>
                        <button type="button" style="margin: 0px 0px 0px 2px" class="atscada-google-map-play btn btn-primary"><span class="fa fa-play"></span></button>
                    </div>
                </div>               
                <div class="col-sm-1">                  
                </div>
                <div class="col-sm-3">
                </div>
            </div>
        </div>
        <div class="panel-body">      
            <div class="row">
                <div class="col-sm-12">
                    <div class="map"></div>
                </div>              
            </div>
        </div>
    </div>
`;

import { } from '../../Core/Component/DateRangePicker/atscada-date-range-picker-element.js'
import { AtscadaFetchService } from '../../Core/Common/atscada-fetch-service.js'
import { AtscadaGoogleMapMarker } from './atscada-google-map-marker.js'
import { AtscadaGoogleMapView } from './atscada-google-map-view.js'
import { AtscadaGoogleMapModel } from './atscada-google-map-model.js'
import { AtscadaGoogleMapController } from './atscada-google-map-controller.js'

export class AtscadaGoogleMapElement extends HTMLElement {
    constructor() {
        super();

        const clone = document.importNode(template.content, true);
        this.appendChild(clone);
        this.attachShadow({ mode: 'open' });
        this.shadowRoot.innerHTML = `<slot></slot>`;

        this.content = 'ATSCADA Google Map';
        this.applicationName = 'DemoMap';
        this.connection = 'atscada';
        this.height = '300px';
        this.apikey = 'AIzaSyB41DRUbKWJHPxaFjMAwdrzWzbVKartNGg';      
        this.dataTagNames = [];
        this.markerItems = [];
        this.items = [];        
        this.index = 0;
        
        this.map = this.querySelector('.map');
        this.selectionTags = this.querySelector('.atscada-gps-list');
        this.speed = this.querySelector('.atscada-gps-speed');
        this.modeButtonElement = this.querySelector('.atscada-google-map-mode');
        this.playButtonElement = this.querySelector('.atscada-google-map-play');
        this.realtimeButtonElement = this.querySelector('.atscada-google-map-realtime');
        this.historyButtonElement = this.querySelector('.atscada-google-map-history');

        this.dateRangePickerElement = this.querySelector('atscada-date-range-picker');
        this.contentHTML = this.querySelector('.atscada-google-map-content');
        this.service = new AtscadaFetchService();

        this.listen();
    }
   
    static isLoaded = false;
    static callbacks = [];
      
    connectedCallback() {
        this.content = this.getAttribute('at-content') || this.content;
        this.applicationName = this.getAttribute('at-application-name') || this.applicationName;
        this.height = this.getAttribute('at-height') || this.height;
        this.connection = this.getAttribute('at-connection') || this.connection;
        this.apikey = this.getAttribute('at-api-key') || this.apikey;

        this.contentHTML.innerHTML = this.content;
        this.querySelector('.map').style.width = "100%";
        this.querySelector('.map').style.height = this.height;

        if (!AtscadaGoogleMapElement.isLoaded) {
            AtscadaGoogleMapElement.callbacks.push(() => this.init(this));
            this.index = AtscadaGoogleMapElement.callbacks.length - 1;
        }

        if (!window.initMap) {
            var script = document.createElement('script');
            var source = 'https://maps.googleapis.com/maps/api/js?key=' + this.apikey + '&callback=initMap';
            script.src = source;
            script.async = true;
            script.defer = true;
            
            window.initMap = async () => {
                AtscadaGoogleMapElement.isLoaded = true;
                for (const callback of AtscadaGoogleMapElement.callbacks) {
                    if (callback.constructor.name === 'AsyncFunction')
                        await callback();
                    else
                        callback();
                }
            };

            document.head.appendChild(script);
        }             
    }

    init(self) {
        var mapProp = {
            center: new google.maps.LatLng(10.79049101184558, 106.63101180581634),
            zoom: 18,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        self.googleMap = new google.maps.Map(self.map, mapProp);
        self.view.map = self.googleMap;

        // Call class Marker
        for (const marker of self.items) {
            marker.map = self.googleMap;
            marker.modeButton = self.modeButtonElement;
            marker.selectionTag = self.selectionTags;
            marker.applicationName = self.applicationName;
            if (marker.isLoaded) {
                marker.initialize();
            }
            else {
                // Important
                marker.dispatcher.on('loaded', () => {
                    marker.initialize();
                });
            }            
        }
    }

    listen() {
        let check = false;
        const slot = this.shadowRoot.querySelector('slot');
        slot.addEventListener('slotchange', (e) => {
            const itemElements = e.target.assignedElements();
            itemElements.forEach((itemElement) => {
                if (itemElement instanceof AtscadaGoogleMapMarker) {
                    if (itemElement.show == 'checked') {
                        this.items.push(itemElement);
                        this.markerItems.push({
                            locationTag: itemElement.locationTagName,
                            alias: itemElement.alias,
                            color: itemElement.color,
                            show: itemElement.show,
                            table: itemElement.table
                        });

                        // Add selection of location tags list
                        const opt = document.createElement('option');                        
                        opt.innerHTML = itemElement.alias;
                        this.selectionTags.appendChild(opt);
                    }
                }
                check = true;
            });

            if (check) {
                check = false;
                this.initialize();
                if (AtscadaGoogleMapElement.isLoaded) {
                    this.init(this);
                }
            }
        });
    }

    initialize() {
        this.model = new AtscadaGoogleMapModel(this);
        this.view = new AtscadaGoogleMapView(this.model, this);
        this.controller = new AtscadaGoogleMapController(this.model, this.view, this.items);
        
        this.view.initialize();
        this.controller.initialize();
    }

    disconnectedCallback() {
        AtscadaGoogleMapElement.callbacks.splice(this.index, 1);
        
        if (this.controller)
            this.controller.dispose();
        if (this.view)
            this.view.dispose();
        if (this.model)
            this.model.dispose();

        let child = this.lastElementChild;
        while (child) {
            this.removeChild(child);
            child = this.lastElementChild;
        }
        this.remove();
    }
}

customElements.define('atscada-google-map', AtscadaGoogleMapElement)