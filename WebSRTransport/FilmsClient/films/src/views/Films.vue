<template>
    <div class="row">
      <div class="col s6">
        <FilsmList/>
      </div>
      <div class="col s6">
        <FilmCard class="b-color"
                        />
      </div>
    </div>
</template>

<script>
import FilsmList from './../components/films/FilsmList'
import FilmCard from './../components/films/FilmCard'

export default {
  name: 'Films',
  components: {
    FilsmList,
    FilmCard
  }
}
</script>