
<template>
  <div class="container"
    v-cloak>
    <nav>
      <div class="nav-wrapper">
        <a href="#!" class="brand-logo right">
          <img src="logo60.png"/>
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
[v-cloak]{
  display: none;
}
</style>
