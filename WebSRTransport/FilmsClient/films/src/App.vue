
<template>
  <div class="container"
    v-cloak>
    <nav>
      <div class="nav-wrapper">
        <a href="#!" class="brand-logo right">Logo</a>
        <ul class="left hide-on-med-and-down">
          <li class="active">
            <router-link to="/">Фильмы</router-link>
          </li>
          <li>
            <router-link to="/tasks">Таски</router-link>
          </li>
        </ul>
      </div>
    </nav>
    <router-view />
  </div>
</template>

<script>
import M from 'materialize-css'

export default {
  name: 'App',
  components: {
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
