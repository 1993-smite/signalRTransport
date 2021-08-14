<template>
    <div class="row">
      <ul class="collapsible">
        <li>
          <div class="collapsible-header">Точки</div>
          <div class="collapsible-body">
            <div class="row">
              <div class="col s9">
                  <div class="input-field"
                    v-for="(item,index) in countLocation"
                    :key="item">
                    <Location 
                      :id="index"
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
            </div>
        </li>
        <li class="active">
          <div class="collapsible-header">Маршруты</div>
          <div class="collapsible-body">
            <div class="row">
              <div class="col s12">
                  <div class="input-field"
                    v-for="(item,index) in [1,2]"
                    :key="item">
                    <Location 
                      :id="'path' + index"
                      v-on:change="changeLocationPath" />
                    <label :for="'path' + index">Точка №{{index+1}}</label>
                  </div>
              </div>
            </div>
          </div>
        </li>
      </ul>
    </div>
</template>

<script>
import M from 'materialize-css'
import Location from './Location'

export default {
  name: 'MapPanel',
  props:{
    coordinates: Array,
    path: Array
  },
  components: {
    Location
  },
  data: ()=>{
    return {
      countLocation: [],
    }
  },
  methods: {
    addCountLocation: function(){
      this.countLocation.push(this.countLocation.length + 1);
      M.updateTextFields();
    },
    changeLocation: function(location){
      let exist = this.coordinates.find(x=>x[0] === location.coord.lon && x[1] === location.coord.lat);

      if (!exist){
        this.$emit('addLocation', location);
      }
      return;
    },
    changeLocationPath: function(location){
      let exist = this.path.find(x=>x[0] === location.coord.lon && x[1] === location.coord.lat);

      if (!exist){
        this.$emit('addLocationPath', location);
      }
      return;
    }
  },
  mounted(){
    this.addCountLocation();
    
    var elems = document.querySelectorAll('.collapsible');
    M.Collapsible.init(elems, {
      accordion: false
    });

  },
}
</script>