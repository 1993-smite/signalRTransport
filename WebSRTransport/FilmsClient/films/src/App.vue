
<template>
  <div class="container"
    v-cloak>
    <nav>
      <div class="nav-wrapper">
        <a id="lg-link" href="#!" class="brand-logo right">
          <img id="lg" 
            src="lg.png"/>
          <div id="lg-body">
            Ниндзя или настоящий джедай. Сайт для джедаев!
          </div>
        </a>
        <ul class="left hide-on-med-and-down">
          <li 
            v-for="(rout, index) in routes"
            :key="index"
            :class="{active: getPath === rout.path}">
            <router-link :to="rout.path">{{rout.name}}</router-link>
          </li>
        </ul>
      </div>
    </nav>
    <router-view />
  </div>
</template>

<script>
import M from 'materialize-css'
import routes from './router/routes'
import {useRoute} from 'vue-router'

export default {
  name: 'App',
  components: {
  },
  watch: {
      $route: {
          immediate: true,
          handler(to) {
              document.title = to.meta.title || 'Дом';
          }
      },
  },
  computed: {
    getPath: function(){
      return this.router.path;
    }
  },
  data: function(){
    return {
      routes: routes,
      router: useRoute()
    }
  },
  mounted(){
    M
    //M.AutoInit();
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
.container {
    max-width: 98%;
    width: 98% !important;
}
.brand-logo{
  position: relative;
}
#lg-body{
  position: absolute;
  display: none;
  z-index: 10000;
  background-color: #ee6e73;
  top: 65px;
  border-radius: 5px;
  font-size: 12pt;
  box-shadow: 0 0 10px rgba(0,0,0,0.5); /* Параметры тени */
  line-height: 20pt;
  padding: 5px;
}
#lg-link:hover  #lg-body {
  display: block !important;
}
[v-cloak]{
  display: none;
}
.col .row{
  margin-left: 7px;
  margin-right: 7px;
}
</style>
