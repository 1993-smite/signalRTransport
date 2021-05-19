<template>
    <ul class="collection with-header">
        <li class="collection-header">
            <h4>Фильмы</h4>  
            <div class="input-field">
                <input placeholder="Год"
                    id="id" 
                    type="number"
                    v-model="id">
                <label for="id">Id</label>
            </div>
        </li>
        <li class="collection-item"
            v-for="(film, index) in getFilms" 
            :key="index"
            v-on:click="setActive(film.id)"
            v-bind:class="{active: film.Active}">
            <div>
                {{film.name}}
                <a href="#!" class="secondary-content">
                    <i class="material-icons">send</i>
                </a>
            </div>
        </li>
    </ul>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';

export default {
  name: 'FilsmList',
  computed: {
    ...mapGetters(['getFilms'])
  },
  data: ()=>{
    return {
        id: 0
    }
  },
  watch:{
      id: async function(){
          await this.getFilm(this.id);
      }
  },
  methods: {
    ...mapActions(["fetchFilms","setActive","getFilm"]),
  },
  components: {
  },
  async mounted(){
    await this.fetchFilms();
  }
}
</script>

<style scoped>
    .active{
        background-color: aqua;
    }
    .collection{
        overflow: auto;
        max-height: 700px;
    }
    .collection-item{
        cursor: pointer;
    }
</style>