<template>
    <ul class="collection">
        <li class="collection-item"
            v-for="(task, index) in getTasks" 
            :key="index"
            v-on:click="setActiveTask(task.id)"
            v-bind:class="{active: task.Active, today: task.IsToday}">
            {{getDate(task)}} <b>{{task.name}}</b>
        </li>
    </ul>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';
import MomentFormat from './../../libs/moment-format'

export default {
  name: 'TaskList',
  components: {

  },
  computed: {
    ...mapGetters(['getTasks','getActiveTask'])
  },
  methods: {
    ...mapActions(["setActiveTask","getTask"]),
    getDate(task){
        return MomentFormat.getDateFormat(task.date);
    }
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
