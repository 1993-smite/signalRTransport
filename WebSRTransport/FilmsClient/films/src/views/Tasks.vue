<template>
    <div class="row">
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

export default {
  name: 'Tasks',
  components: {
    TaskList,
    TaskCard
  }
}
</script>