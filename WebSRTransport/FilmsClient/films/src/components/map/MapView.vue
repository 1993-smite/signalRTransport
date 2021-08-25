<template>
  <ol-map 
    id='map'
    :loadTilesWhileAnimating="false" 
    :loadTilesWhileInteracting="true"
    @click="tapMap($event)">

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
                :key="'point' + index"
                :id="'point' + index">
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
import M from 'materialize-css'
import CirclePoint from './CirclePoint.vue'
import Path from './Path.vue'
//import OSMLib from '@/libs/osm'
import dadata from '@/libs/dadata'
import GeoLocation from '@/libs/geoLocation'
import saveGeolocation from '@/libs/db'

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
    GeoLocations: Array
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
    ...saveGeolocation,
    tapMap: async function(event){
      console.log(event)

      if (!event.map)
        return;

      var feature = event.map.forEachFeatureAtPixel(event.pixel, function(feature) {
                    return feature;
                 });
      if (feature) {
        console.log("Feature found", feature, feature.values_.geometry.flatCoordinates);
        this.$emit('clickFeature', feature);
        //feature.geometryChangeKey_.target.click();
      }
      else {
        let coord = event.map.getCoordinateFromPixel(event.pixel)
        //let address = await OSMLib.getAddressByCoordinate(coord[0], coord[1]);
        let address = await dadata.getAddress(coord[1], coord[0]);
        let geoLocation = new GeoLocation(address.suggestions[0].value, coord[1], coord[0]);

        console.log("Feature not found", geoLocation);
        let res = coord.join(';');
        this.saveGeolocation(geoLocation);
        M.toast({html: `Coordinate: ${res}, Address: ${geoLocation.address}`})
        this.$emit('addGeoLocation', geoLocation);
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