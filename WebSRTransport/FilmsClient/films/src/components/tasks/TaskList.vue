<template>
    <ul class="collection">
        <li class="collection-item"
            v-for="(task, index) in getTasks" 
            :key="index"
            v-on:click="setActiveTask(task.id)"
            v-bind:class="{active: task.Active}">
            {{getDate(task)}} <b>{{task.name}}</b>
        </li>
    </ul>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';

export default {
  name: 'TaskList',
  components: {

  },
  computed: {
    ...mapGetters(['getTasks','getActiveTask'])
  },
  methods: {
    ...mapActions(["fetchTasks","setActiveTask","getTask"]),
    getDate(task){
        const date = new Date(task.date);
        return `${date.getDay()}.${date.getMonth()}.${date.getFullYear()}`;
    }
  },
  async mounted(){
      await this.fetchTasks();
  }
}
</script>

<style scoped>
    .collection-item{
        cursor: pointer;
    }
</style>
