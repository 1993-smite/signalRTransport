<template>
    <ul class="collection">
        <li class="collection-item"
            v-for="(framework, index) in getFrameworks" 
            :key="index"
            v-on:click="setActiveFramework(framework.id)"
            v-bind:class="{active: framework.Active, today: framework.IsToday}">
            <b>{{framework.name}}</b>
        </li>
    </ul>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';

export default {
  name: 'FrameworkList',
  components: {

  },
  computed: {
    ...mapGetters(['getFrameworks'])
  },
  methods: {
    ...mapActions(['setActiveFramework']),
  }
}
</script>

<style scoped>
    .collection-item{
        cursor: pointer;
    }
    .today{
        background-color: #ffc4b6;
    }
</style>
