<template>
  <ol-map 
    id='map'
    :loadTilesWhileAnimating="false" 
    :loadTilesWhileInteracting="true"
    @click="pathStat($event)">

    <ol-view 
      ref="view" 
      :center="CurCenter.coord" 
      :rotation="rotation" 
      :zoom="zoom" 
      :projection="projection" />

    <ol-tile-layer>
        <ol-source-osm />
    </ol-tile-layer>

    <ol-context-menu 
      :items="ContextMenuItems" />

    <ol-fullscreen-control tipLabel="Полный вид" />

    <ol-vector-layer
      @click="pathStat(index)"> 
        <ol-source-vector :projection="projection">
            <ol-feature
              v-for="(route, index) in pathSteps"
              :key="'route' + index"
              :title="'route' + index">
              <Path 
                :path="route"
                :color="getColor(index)"
                :title="'route' + index"
                @mouseover="pathStat(index)"
                @click="pathStat(index)" />
            </ol-feature>

            <ol-feature
              v-for="(item, index) in Path.path"
              :key="'point' + item.id">
               <circle-point
                  :coord="item.coord"
                  :color="getColor(index)"
                  :text="`${item.id}`" />
            </ol-feature>


              <ol-feature 
              
                v-for="(item, index) in CirclePoints"
                :key="'point' + index">
                <circle-point 
                  :coord="item.coord"
                  :color="item.color"
                  :text="item.text"
                  :radius="item.radius" />
                  
              </ol-feature>

        </ol-source-vector>

    </ol-vector-layer>

  </ol-map>
</template>

<script>
import CirclePoint from './CirclePoint.vue'
import Path from './Path.vue'

export default {
  name: 'MapView',
  components: {
    CirclePoint,
    Path
  },
  props: {
    CirclePoints: Array,
    Path: Array,
    CurCenter: Array,
    ContextMenuItems: Array,
  },
  computed: {
    getFeatures: function(){
      return [];
    },
    pathSteps: function(){
      let res = this.Path.routes 
        ? this.Path.routes.map((x)=> x.steps.map(step=> step.maneuver.location))
        : [[],[]];

      return res;
    },
  },
  data: ()=>{
    return {
      projection: 'EPSG:4326',
      zoom: 10,
      rotation: 0,
      styles: {
        radius: 10,
        strokeWidth: 4,
        strokeColor: 'red',
        fillColor: 'white'
      },
      colors: ['#9f8fe4', '#ec9edd', '#6e75fd', '#72cbfb', '#66e885', '#a8ef55', '#fbdf67'],
    }
  },

  methods: {
    getColor(index){
      return this.colors[index];
    },
    pathStat: function(event){
      console.log(event)
      var feature = event.map.forEachFeatureAtPixel(event.pixel, function(feature) {
                    return feature;
                 });
      if (feature) {
        console.log("Feature found");
        feature.geometryChangeKey_.target.click();
      }
    },
    geoLocChange: function(loc) {
        console.log(loc);
        // view.value.fit([loc[0], loc[1], loc[0], loc[1]], {
        //     maxZoom: 14
        // })
    },
    enableRotatedTransform: function(event){
      console.log('enableRotatedTransform',event)
    },
    drawend: function(event){
      console.log(event)
    }
  },
  mounted(){
    
  },
}
</script>

<style scoped>
  #map{
      width: 100%;
      height: 80vh;
  }
</style>