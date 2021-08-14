<template>
    <input type="text" 
        class="validate"
        placeholder="Введите адрес"
        :class="{ invalid: invalid }"
        v-model.lazy.trim='address'
        v-on:change.stop="checkAddress($event)">
</template>

<script>
//import M from 'materialize-css'
import OSMLib from '@/libs/osm'
//const axios = require('axios')

export default {
  name: 'Location',
  data: ()=>{
    return {
      address: '',
      invalid: false,
      lat: 0,
      lon: 0,
      isOSM: true
    }
  },
  methods: {
    checkAddress: async function(){
      let coords = [37.511154, 55.876183];
      if (this.isOSM){
        let res = await OSMLib.getCoordinateByAddress(this.address);
        try{
          coords = res.address[0].features[0].geometry.geometries[0].coordinates;
        }
        catch(e){
          this.invalid = true;
          console.error(e);
          return;
        }
      }

      let result = [coords[0], coords[1]]; //await getCoordinateByAddress(this.address);
      this.$emit('change', { address: this.address, coord: { lat: result[1], lon: result[0] } });
    },
    
  },
  mounted(){
    
  },
  unmounted(){
    console.log('destroyed');
  }
}
</script>

<style scoped>

</style>