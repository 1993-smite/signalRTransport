<template>
    <div class="row">
      <ul id="tabs" class="tabs">
        <li class="tab col s3">
          <a class="active" 
            href="#test-swipe-1">Точки</a>
        </li>
        <li class="tab col s3">
          <a href="#test-swipe-2">Маршруты</a>
        </li>
        <li class="tab col s3">
          <a href="#test-swipe-3">Машины</a>
        </li>
      </ul>
      <div id="test-swipe-1" class="col s12">
        <div class="col s9">
          <div class="input-field"
            v-for="(item,index) in countLocation"
            :key="item">
            <Location 
              :id="`point-${index}`"
              v-on:change="changeLocation" />
            <label :for="index">Точка №{{index+1}}</label>
          </div>
        </div>
        <div class="col s3">
            <a class="btn-floating btn-medium waves-effect waves-light red"
              v-on:click="addCountLocation()">
              <i class="material-icons">add</i>
            </a>
        </div>
      </div>
      <div id="test-swipe-2" class="col s12">
        <div class="input-field"
          v-for="(item,index) in [1,2]"
          :key="item">
          <Location 
            :id="'path' + index"
            v-on:change="changeLocationPath" />
          <label :for="'path' + index">Точка №{{index+1}}</label>
        </div>
      </div>
      <div id="test-swipe-3" class="col s12">
        <div class="input-field">
          <Location 
            id="pathMap"
            v-on:changeLocation="changeGeoLocation" />
          <label for="pathMap">Адрес</label>
        </div>
        <div class="input-field">
          <textarea name="" 
            class="materialize-textarea"
            id="" 
            rows="10"
            v-model="paths"
            v-on:blur="changePaths()"></textarea>
          <label for="pathMaps">Адреса</label>
        </div>
      </div>
    </div>
</template>

<script>
import M from 'materialize-css'
import Location from './Location'
import Dadata from '../../libs/dadata'

export default {
  name: 'MapPanel',
  props:{
    coordinates: Array,
    path: Array,
  },
  components: {
    Location
  },
  data: ()=>{
    return {
      countLocation: [],
      paths: ""
    }
  },
  methods: {
    addCountLocation: function(){
      this.countLocation.push(this.countLocation.length + 1);
      M.updateTextFields();
    },
    changeLocation: function(location){
      if (!location.coord)
        return;
      
      let exist = this.coordinates.find(x=>x[0] === location.coord.lon && x[1] === location.coord.lat);

      if (!exist){
        this.$emit('addLocation', location);
      }
      return;
    },
    changeLocationPath: function(location){
      if (!location.coord)
        return;

      let exist = this.path.find(x=>x[0] === location.coord.lon && x[1] === location.coord.lat);

      if (!exist){
        this.$emit('addLocationPath', location);
      }
      return;
    },
    changeGeoLocation: function(location){
      location.lat = location.coord[1];
      location.lon = location.coord[0];
      this.$emit('addGeoLocation', location);
    },
    changePaths: async function(){
      let lines = this.paths.split('\n');
      for (const line of lines) {
        let lnCoord = await Dadata.getCoord(line);

        if (lnCoord){
          this.changeGeoLocation({
            address: line,
            lat: +lnCoord.data.geo_lat,
            lon: +lnCoord.data.geo_lon,
            coord: [+lnCoord.data.geo_lon, +lnCoord.data.geo_lat]
          });
        }
      }
    }
  },
  mounted(){
    this.addCountLocation();
    
    var el = document.querySelectorAll('#tabs');
    M.Tabs.init(el, {

    });

  },
}
</script>