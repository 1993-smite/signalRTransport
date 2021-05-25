
<template>
  <div class="container"
    v-cloak>
    <nav>
      <div class="nav-wrapper">
        <a href="#!" class="brand-logo right">Logo</a>
        <ul class="left hide-on-med-and-down">
          <li class="active"><a href="#">Фильмы</a></li>
        </ul>
      </div>
    </nav>
    <div class="row">
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
    M.AutoInit();
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
}
[v-cloak]{
  display: none;
}
</style>
