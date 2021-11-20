<template>
    <div class="row" v-cloak>
        <div class="col s7">
            <h6>Карта</h6>
            <MapView 
              :CirclePoints="points"
              :Path="pathLine"
              :CurCenter="center"
              :ContextMenuItems="contextMenuItems"
              :GeoLocations="geolocations"
              v-on:clickFeature="checkFeature"
              v-on:addGeoLocation="addGeoLocation" />
        </div>
        <div class="col s5 two">
        
            <Toggle>
              <template v-slot:title>
                <h6>Рабочая панель</h6>
              </template>
              <template v-slot:default>
                <i 
                  class="small material-icons s1 pointer"
                  style="float:right; color: red"
                  v-on:click="clearFeatures()">clear_all</i>
                <MapPanel 
                  :coordinates="coords"
                  :path="pathLine.path"
                  v-on:addGeoLocation="addGeoLocation"
                  v-on:addLocation="addLocation"
                  v-on:addLocationPath="addLocationPath" />
              </template>
            </Toggle>

            <Toggle>
              <template v-slot:title>
                <h6>Адреса</h6> 
              </template>
              <template v-slot:default>
                
                <div>
                  <div class="row">
                    <!-- <div class="input-field col s5">
                      <input id="count" type="number">
                      <label for="count">Кластеров</label>
                    </div> -->
                    <div class="col s8">
                      <a class="waves-effect waves-light btn"
                        v-on:click="clusterize(0)">KMeans</a>
                      <a class="waves-effect waves-light btn"
                        v-on:click="clusterize(1)">Binary</a>
                      <a class="waves-effect waves-light btn"
                        v-on:click="clusterize(2)">Mean</a>
                      <a class="waves-effect waves-light btn"
                        v-on:click="clusterize(3)">Gausian</a>
                    </div>
                    <div class="col s2">
                      <div class="input-field inline">
                        <input id="email_inline" 
                          type="number" 
                          class="validate" 
                          v-model="countClusters">
                      </div>
                    </div>
                  </div>
                  <div id="geo-location">
                    <table class="striped highlight">
                      <thead>
                        <tr>
                            <th>Адрес</th>
                            <th>Широта</th>
                            <th>Долгота</th>
                        </tr>
                      </thead>

                      <tbody>
                        <tr v-for="item in geolocations"
                          v-bind:key="item.address">
                          <td>{{item.address}}</td>
                          <td>{{item.lat}}</td>
                          <td>{{item.lon}}</td>
                        </tr>
                      </tbody>
                    </table>
                  </div>
                  
                </div>
              </template>
            </Toggle>
            <!--h5>Рабочая панель</h5>
            <div class="row">
              <i 
                class="small material-icons s1 pointer"
                style="float:right; color: red"
                v-on:click="clearFeatures()">clear_all</i>
            </div>
            <MapPanel 
              :coordinates="coords" 
              :path="pathLine.path"
              v-on:addLocation="addLocation"
              v-on:addLocationPath="addLocationPath" /-->
        </div> 
    </div>
</template>

<script>
import MapView from '../components/map/MapView.vue'
import MapPanel from '../components/map/MapPanel.vue'
import Toggle from '../components/common/Toggle.vue'
import OSMLib from '@/libs/osm'
import clusterization from '@/libs/db'

export default {
  name: 'MapWorker',
  components: {
    MapView,
    MapPanel,
    Toggle
  },
  data: function(){
    let center = { coord: [37.64, 55.76] };
    let context = this;
    return {
      coords: [],
      points: [],
      pathLine: {
        path: []
      },
      center: center,
      geolocations: [],
      countClusters: 3,
      contextMenuItems: [{
            text: 'Center map here',
            callback: (val) => {
              context.setCenter(val.coordinate);
            } // `center` is your callback function
        },
        {
            text: 'Add as Marker',
            callback: (val) => {
              context.addLocation({
                coord: {
                  lat: val.coordinate[1],
                  lon: val.coordinate[0]
                }
              })
            }
        },
        {
            text: 'Add as Line',
            callback: (val) => {
              context.addLocationPath({
                coord: {
                  lat: val.coordinate[1],
                  lon: val.coordinate[0]
                }
              })
            }
        },
        '-' // this is a separator
      ],
      colors: [
        'blue', 'red', 'black', 'green', 'yellow','white','brown'
      ],
      urls: [
        'http://localhost:9999/api/Clusterize/AccordKMeans',
        'http://localhost:9999/api/Clusterize/AccordBinarySplit',
        'http://localhost:9999/api/Clusterize/AccordMeanSplit',
        'http://localhost:9999/api/Clusterize/AccordGausian',
      ]
    }
  },
  methods: {
    setCenter: function(coord){
      this.center.coord = coord;
    },
    addLocation: function(location){
      this.coords.push([location.coord.lon, location.coord.lat]);
      this.addPoint(location);
    },
    addPoint: function(location){
      let point = {
        coord: [
          location.coord.lon,
          location.coord.lat
        ],
        color: location.color || undefined,
        text: `${this.points.length + 1}`,
      };
      this.points.push(point);
      this.setCenter(point.coord);
    },
    addLocationPath: function(location){
      this.path.push([location.coord.lon, location.coord.lat]);
      this.addPointPath(location);
    },
    addPointPath: function(location){
      let point = [
          location.coord.lon,
          location.coord.lat
        ];
      this.pathLine.path.push({
        coord: point,
        id: this.pathLine.path.length + 1
      });
      this.routePath();
      //this.center = point.coord;
    },
    routePath: async function(){
      this.pathLine.routes = await 
        OSMLib.getRouteByCoordinates(this.pathLine.path.map(x=>x.coord));
    },
    checkFeature: function(feature){
      let coord = feature.values_.geometry.flatCoordinates;
      this.points = this.points.filter(x=>!(x.coord[0] === coord[0] && x.coord[1] === coord[1]));
    },
    clearFeatures: function(){
      this.points = [];
      this.pathLine = [];
    },
    addGeoLocation: function(geoLocation){
      this.geolocations.push(geoLocation);
    },
    ...clusterization,
    clusterize: async function(index){
      let locations = await this.clusterization(this.urls[index],this.geolocations, +this.countClusters);

      for(let location of locations){
        this.addPoint({
          coord: { lat: location.lat, lon: location.lon },
          color: this.colors[location.cluster]
        });
      }
    }
  },
  mounted(){
    
  },
}
</script>

<style scoped>
  #geo-location{
    max-height: 400px;
    overflow-y: auto;
  }
  .input-field {
    margin-top: 0px;
    margin-bottom: 0px;
  }
  .row{
    margin-bottom: 0px;
  }
  td{
    padding: 5px;
  }
</style>