<template>
    <input type="text" 
        class="validate autocomplete"
        placeholder="Введите адрес"
        :class="{ invalid: invalid }"
        :id="id"
        v-model.trim='address'
        v-on:change.stop="checkAddress($event)"
        v-on:input="loadAutoComplite()">
</template>

<script>
import M from 'materialize-css'
import OSMLib from '@/libs/osm'
import DaData from '@/libs/dadata'
//const axios = require('axios')

export default {
  name: 'Location',
  props: {
    id: String
  },
  data: ()=>{
    return {
      address: '',
      invalid: false,
      lat: 0,
      lon: 0,
      isOSM: true,
      instance: {}
    }
  },
  methods: {
    checkAddress: async function(){
      let lat = 37.511154 + Math.random() / 100;
      let lon = 55.876183 + Math.random() / 100;
      let coords = [lat, lon];
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
    loadAutoComplite: async function(){

      if (this.address.length < 6)
        return;

      let res = await DaData.fetchData(this.address);

      console.log(res);

      let vars = {};
      for(let it of res){
        vars[it] = null;
      }

      this.instance.updateData(vars);
      this.instance.open();
    }
  },
  mounted(){
    var elems = document.querySelector(`#${this.id}`);
    this.instance = M.Autocomplete.init(elems, {
      minLength: 5
    });
  },
  unmounted(){
    console.log('destroyed');
  }
}
</script>

<style scoped>

</style>