<template>
    <input type="text" 
        class="validate"
        :class="{ invalid: invalid }"
        v-model.trim='addr'
        v-on:blur.prevent="checkAddress($event)">
</template>

<script>
import M from 'materialize-css'
const axios = require('axios')

export default {
  name: 'Place',
  props: {
    address: String,
    coord: Array
  },
  //emits: ['update:address', 'update:coord', 'update:model', 'update'],
  data: ()=>{
    return {
      addr: '',
      invalid: false
    }
  },
  methods: {
    checkAddress: async function(event){
      
        if (!this.addr || this.addr.length < 2){
          this.invalid = true;
          return;
        }

        let itm = this.getLCItem(this.addr);
        let coord = [];
        if (itm){
          coord = itm.coord;
        }
        else {
          let response = await 
            fetch(`http://search.maps.sputnik.ru/search/addr?tlat=56.1&tlon=36.8&blat=55.4&blon=38.6&q=${this.addr}`);
          let result = await response.json();
          let res = result.result;
          if (res.address){
            coord = res.address[0].features[0].geometry.geometries[0].coordinates;
          }
          else {
            M.toast({html: 'Не корректный адрес!'});
            this.invalid = true;
            return;
          }
          this.setLCItem(this.addr, coord);
        }
        let address = this.addr;

        this.$emit('update:placeAddress', address);
        this.$emit('update:placeCoord', coord);

        this.$emit('update', event);
    },
    setLCItem: function(address, coord){
      localStorage.setItem(`address-${address}`, JSON.stringify({ address, coord }));
      axios.post('http://localhost:9999/api/Address', 
        {
          address,
          lon: coord[0],
          lat: coord[1]
        } ).then(() => {
          M.toast({html: `<span style='backgound-color: green'>Адрес был сохранен</span>`});
          localStorage.setItem(`address-${address}`, JSON.stringify({ address, coord }));
      }, (err)=>{
          console.error('test error', err);
          M.toast({html: `<span style='backgound-color: red'>${err.message}</span>`});
      })
    },
    getLCItem: function(address){
      let obj = localStorage.getItem(`address-${address}`);
      return obj ? JSON.parse(obj) : undefined;
    }
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