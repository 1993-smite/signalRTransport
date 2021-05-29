<template>
    <div class="row"
      v-on:keyup.up="up()"
      v-on:keyup.down="down()">
      <div class="col s6">
        <TaskList/>
      </div>
      <div class="col s6">
        <TaskCard class="b-color"
                        />
      </div>
    </div>
</template>

<script>
import TaskList from './../components/tasks/TaskList'
import TaskCard from './../components/tasks/TaskCard'

import { mapGetters, mapActions } from 'vuex';
import M from 'materialize-css'

export default {
  name: 'Tasks',
  components: {
    TaskList,
    TaskCard
  },
  computed: {
    ...mapGetters(['getTasks','getActiveTask'])
  },
  methods: {
    ...mapActions(["fetchTasks","setActiveTask","removeTask"]),
    getActiveTaskIndex: function(){
      let tasks = this.getTasks;
      return tasks.findIndex(x=>x.id == this.getActiveTask.id);
    },
    up: function(){
      let tasks = this.getTasks;
      const taskIndex = this.getActiveTaskIndex();

      if (taskIndex > 0) 
        this.setActiveTask(tasks[taskIndex - 1].id);
    },
    down: function(){
      let tasks = this.getTasks;
      const taskIndex = this.getActiveTaskIndex();

      if (taskIndex < this.getTasks.length - 1) 
        this.setActiveTask(tasks[taskIndex + 1].id);
    }
  },
  mounted(){
    let context = this;
    this.fetchTasks().then((tasks) => {
      M.updateTextFields();

      let tasksToday = tasks.filter(x=>x.IsToday);
      //let index = 1;
      var notifications = [];
      for(let task of tasksToday){
        notifications.push(new Notification(`Task`, {
            tag : task.id,
            body : task.name
        }));
        notifications[notifications.length - 1].onclick = function(event){
          const taskId = +event.target.tag;
          let task = context.getTasks.find(x=>x.id == taskId);
          context.removeTask(task);
          console.log(arguments);
        };
      }
      console.log(notifications);
    });
  }
}
</script>