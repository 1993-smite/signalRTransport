<template>
    <h4>Фильмы</h4>  
    <div class="input-field">
        <input placeholder="Id"
            id="id" 
            type="number"
            v-model="id">
        <label for="id">Id</label>
    </div>
    <div class="input-field">
        <input placeholder="Год"
            id="year" 
            type="number"
            v-model="year">
        <label for="year">Год</label>
    </div>
    <ul class="collection" v-cloak>
        <li class="collection-item"
            v-for="(film, index) in getFilms" 
            :key="index"
            v-on:click="setActive(film.id)"
            v-bind:class="{active: film.Active}">
            <div>
                <b>{{film.name}}</b>({{film.year}})
                <span class="badge">
                    {{film.type.name}}
                </span>
                <!--span class="new badge blue">
                    {{film.year}}
                </span-->
            </div>
        </li>
    </ul>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';

export default {
  name: 'FilsmList',
  computed: {
    ...mapGetters(['getFilms','getActiveFilm'])
  },
  data: ()=>{
    return {
        id: 0,
        year: 0
    }
  },
  watch:{
      id: async function(){
          await this.getFilm(this.id);
      },
      year: async function(){
          await this.fetchFilms({ year: this.year });
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
        text-align: left;
    }
</style>