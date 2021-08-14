<template>
  <ol-map 
    id='map'
    :loadTilesWhileAnimating="true" 
    :loadTilesWhileInteracting="true">

    <ol-view 
      ref="view" 
      :center="CurCenter" 
      :rotation="rotation" 
      :zoom="zoom" 
      :projection="projection" />

    <ol-tile-layer>
        <ol-source-osm />
    </ol-tile-layer>

    <ol-vector-layer>
        <ol-source-vector>
            <ol-feature :key="'path1'">
              <Path 
                :path="Path.path"
                :color="Path.color"
                :text="Path.text"
                :width="Path.width" />
                
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
  },
  computed: {
    getFeatures: function(){
      return [];
    }
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
      }
    }
  },

  methods: {
    
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