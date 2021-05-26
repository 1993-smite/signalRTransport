<template>
    <ul class="collection">
        <li class="collection-item"
            v-for="(task, index) in getTasks" 
            :key="index"
            v-on:click="setActiveTask(task.id)"
            v-bind:class="{active: task.Active, today: isToday(task)}">
            {{getDate(task)}} <b>{{task.name}}</b>
        </li>
    </ul>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';
import moment from 'moment';

export default {
  name: 'TaskList',
  components: {

  },
  computed: {
    ...mapGetters(['getTasks','getActiveTask'])
  },
  methods: {
    ...mapActions(["setActiveTask","getTask"]),
    isToday(task){
        const today = moment();
        const dt = moment(task.date);
        return today.format('LL') === dt.format('LL');
    },
    getDate(task){
        const date = moment(task.date);
        return date.format('LL');
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
