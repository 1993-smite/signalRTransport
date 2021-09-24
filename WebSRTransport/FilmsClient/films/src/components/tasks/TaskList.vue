<template>
    <table class="highlight">
        <thead>
          <tr>
              <th>Дата</th>
              <th>Название</th>
          </tr>
        </thead>

        <tbody>
          <tr v-for="(task, index) in getTasks" 
            :key="index"
            v-on:click="setActiveTask(task.id)"
            v-bind:class="{active: task.Active, today: task.IsToday}"
            v-on:keyup.down="setActiveTaskIndex(index + 1)"
            v-on:keyup.up="setActiveTaskIndex(index - 1)"
            class="pointer">
            <td class="dt">{{getDate(task)}}</td>
            <td>
                <b>{{task.name}}</b>
            </td>
          </tr>
        </tbody>
      </table>
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
    setActiveTaskIndex(index){
        if (index > -1 && this.getTasks.length > index){
            this.setActiveTask(this.getTasks[index].id);
        }
        return index;
    },
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
        background-color: #ffc4b6 !important;
    }
    .active{
        background-color: #546e7a !important;
        color: white;
    }
    table{
        margin-top: 0.5rem;
    }
    thead{
        background-color: white;
        color: #020000;
    }
    th, td{
        border-radius: 0px;
    }
    td{
        padding: 4px 5px;
    }
    .dt{
        min-width: 100px;
    }
</style>
