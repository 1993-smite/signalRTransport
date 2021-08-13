<template>
    <div class="row" v-cloak>
        <div class="col s7">
            <h5>Карта</h5>
            <MapView 
              :CirclePoints="points"
              :CurCenter="center" />
        </div>
        <div class="col s1">
        </div>
        <div class="col s4 two">
            <h5>Рабочая панель</h5>
            <MapPanel 
              :coordinates="coords" 
              v-on:addLocation="addLocation" />
        </div> 
    </div>
</template>

<script>
import MapView from '../components/map/MapView.vue'
import MapPanel from '../components/map/MapPanel.vue'

export default {
  name: 'MapWorker',
  components: {
    MapView,
    MapPanel
  },
  data: ()=>{
    return {
      coords: [],
      points: [],
      center: [37.64, 55.76],
    }
  },
  methods: {
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
        text: `${this.points.length + 1}`,
      };
      this.points.push(point);
      this.center = point.coord;
    }
  },
  mounted(){
    
  },
}
</script>

<style scoped>

</style>