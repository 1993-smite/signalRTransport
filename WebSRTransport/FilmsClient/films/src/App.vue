
<template>
  <div class="container">
    <div class="row">
      <div class="col s12">Фильмы</div>
      <div class="col s6">
        <FilsmList/>
      </div>
      <div class="col s6">
        <FilmCard class="b-color"
                        />
      </div>
    </div>
  </div>
</template>

<script>
import M from 'materialize-css'
import FilsmList from './components/FilsmList'
import FilmCard from './components/FilmCard'

export default {
  name: 'App',
  components: {
    FilsmList,
    FilmCard
  },
  mounted(){
    M.AutoInit()
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
