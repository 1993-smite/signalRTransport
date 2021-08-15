<template>
    <div class="row" v-cloak>
        <div class="col s7">
            <h5>Карта</h5>
            <MapView 
              :CirclePoints="points"
              :Path="pathLine"
              :CurCenter="center"
              :ContextMenuItems="contextMenuItems" />
        </div>
        <div class="col s1">
        </div>
        <div class="col s4 two">
            <h5>Рабочая панель</h5>
            <MapPanel 
              :coordinates="coords" 
              :path="pathLine.path"
              v-on:addLocation="addLocation"
              v-on:addLocationPath="addLocationPath" />
        </div> 
    </div>
</template>

<script>
import MapView from '../components/map/MapView.vue'
import MapPanel from '../components/map/MapPanel.vue'
import OSMLib from '@/libs/osm'

export default {
  name: 'MapWorker',
  components: {
    MapView,
    MapPanel
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
        text: `${this.points.length + 1}`,
      };
      this.points.push(point);
      this.setCenter(point.coord);
    },
    addLocationPath: function(location){
      //this.path.push([location.coord.lon, location.coord.lat]);
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
    }
  },
  mounted(){
    
  },
}
</script>

<style scoped>

</style>