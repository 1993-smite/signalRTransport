<template>
    <div class="row" v-cloak>
        <div class="col s7">
            <h5>Карта</h5>
            <div id='map'></div>
        </div>
        <div class="col s5">
            <h5>
                Рабочая панель
                <sup class="count">
                    {{workArea.places.length}}
                    <div class="collection address-panel">
                        <div class="address-item collection-item"
                            v-for="place in workArea.places"
                            v-bind:key="index + place.address">
                            {{place.address}}
                        </div>
                    </div>
                </sup>
            </h5>
            <div class="row two-rw"
                v-for="(place, index) in workArea.places"
                v-bind:key="index + place.address">
                <div class="col s11 input-field">
                    <keep-alive>
                        <Place id='address' 
                            v-model:placeAddress.lazy='place.address'
                            v-model:placeCoord.lazy='place.coord'
                            v-on:update="checkAddress(place)"
                            />
                    </keep-alive>
                    <label for='address'>Адрес</label>
                    <span class="helper-text" 
                        data-error="не корректно" 
                        data-success="верно">Введите корректный адрес</span>
                </div>
                <div class="col s1">
                    <a class="btn-floating btn-middle waves-effect waves-light red"
                        v-on:click="addPlace()">
                        <i class="material-icons">add</i>
                    </a>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import {Map, View} from 'ol';
import OSM from 'ol/source/OSM';
import VectorLayer from 'ol/layer/Vector';
import VectorSource from 'ol/source/Vector';
//import {Tile} from 'ol';
import TileLayer from 'ol/layer/Tile';
import {fromLonLat} from 'ol/proj';
import Feature from 'ol/Feature';
import Point from 'ol/geom/Point';
import {Fill, Stroke, Circle, Style, Text} from 'ol/style';
import Place from '../components/map/Place.vue';
//import {toStringXY} from 'ol/coordinate';
//import {fromLonLat} from 'ol/coordinate';

export default {
  name: 'Map',
  components: {
    Place
  },
  data: ()=>{
    return {
        map: {},
        view: {},
        source: {},
        userLayer: {},
        workArea: {
            places: [],
            features: []
        }
    }
  },
  methods: {
    checkAddress: async function(place){
        this.createOsmMarker(place.coord[0], place.coord[1], 'gray', 'A');
        this.addLayer();
    },
    addPlace: function(){
        this.workArea.places.push(
        {
            address: '',
            coord: [],
        });
    },
    createOsmMarker: function (lon, lat, color, text) {
        var marker = new Feature({
            geometry: new Point(fromLonLat([lon, lat]))
        });
        marker.setStyle(new Style({
            image: new Circle({
                fill: new Fill({ color: color }),
                stroke: new Stroke({ color: "black", width: 2 }),
                radius: 12
            }),
            text: new Text({
                fill: new Fill({ color: "black" }),
                stroke: new Stroke({ color: "black", width: 1 }),
                offsetX: 0,
                textAlign: "center",
                font: "14px Arial",
                text: text
            })
        }));
        this.workArea.features.push(marker);
    },
    addLayer: function(){
        var vectorSource = new VectorSource({ features: this.workArea.features });
        this.userLayer = new VectorLayer({ source: vectorSource });
        this.map.addLayer(this.userLayer);
    }
  },
  mounted(){
        this.view = new View({
                center: fromLonLat([37.64, 55.76]),
                zoom: 10
            });
        this.map = new Map({
            target: 'map',
            layers: [
                new TileLayer({
                    source: new OSM()
                })
            ],
            view: this.view,
            moveTolerance: 20
        });

        this.addPlace();
  },
}
</script>

<style scoped>
    #map{
        width: 100%;
        height: 80vh;
    }
    .two-rw{
        margin-left: 10px;
    }
    sup.count{
        border-radius: 50%;
        background-color: black;
        color: white;
        font-size: 60%;
        padding-left: 3px;
        padding-right: 3px;
        cursor: pointer;
    }
    .address-panel{
        position: absolute;
        color: black;
        background-color: darkgray;
        z-index: 1000;
        top: 0px;
        left: 0px;
        width: 200px;
        text-align: left;
        display: none;
    }
    .address-item{
        padding: 5px;
    }
    sup.count:hover .address-panel{
        display: block;
    }
</style>