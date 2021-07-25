<template>
    <div class="row"
      v-on:keyup.up="up()"
      v-on:keyup.down="down()">
      <div class="col s6 left">
        <FrameworkList/>
      </div>
      <div class="col s6 right">
        <FrameworkCard class="b-color"
                        />
      </div>
    </div>
</template>

<script>
  import FrameworkList from './../components/frameworks/FrameworkList'
  import FrameworkCard from './../components/frameworks/FrameworkCard'
  
  export default {
    name: 'Frameworks',
    components: {
      FrameworkList,
      FrameworkCard
    },
    data: ()=>{
      return {
        
      }
    },
    mounted(){

    },
  }
</script>

<style scoped>

</style>