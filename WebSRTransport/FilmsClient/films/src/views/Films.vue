<template>
    <div class="row" v-cloak>
      <div class="col s6">
        <FilsmList/>
      </div>
      <div class="col s6">
        <FilmCard 
          class="b-color"
          v-bind:hub="hub"
                        />
      </div>
    </div>
</template>

<script>
import FilsmList from './../components/films/FilsmList'
import FilmCard from './../components/films/FilmCard'
import connection from './../libs/filmSignalR'

export default {
  name: 'Films',
  components: {
    FilsmList,
    FilmCard
  },
  data: ()=>{
    return {
      hub: connection.hub
    }
  },
  mounted(){
    this.hub.start()
      .then(() => this.hub.invoke("send", "Hello"));
  },
  beforeRouteLeave () {
    this.hub.stop();
  }
}
</script>