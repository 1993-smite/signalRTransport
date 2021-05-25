let taskUrl = 'http://localhost:9999/api/WebTasks';
const axios = require('axios')

async function getTask(id){
    let res = await fetch(`${taskUrl}/${id}`);
    let task = await res.json();
    return task;
}

export default {
    state: {
        tasks: []
    },
    getters: {
        getTasks(state){
            return state.tasks;
        },
        getActiveTask(state){
            return state.tasks.find(x=>x.Active);
        }
    },
    actions: {
        async fetchTasks(ctx){
            let res = await fetch(taskUrl);
            let tasks = await res.json();
            tasks.forEach(x=>{
                x.Active = false;
            });
            ctx.commit('setTasks', tasks);
            ctx.commit('setActive', tasks[0].id);
        },
        async setActiveTask(ctx, id){
            await ctx.dispatch('setTask', id);
            ctx.commit('setActive', id);
        },
        async setTask(ctx, id){
            let task = await getTask(id);
            
            ctx.commit('setTask', task);
        },
        async getTask(ctx, id){
            let task = getTask(id);
            let tasks = [task];
            
            ctx.commit('setTasks', tasks);
            ctx.commit('setActive', tasks[0].id);
        },
        async saveTask(ctx, task){
            let response = await axios
            .post(taskUrl, task );
            let taskId = response.data;
            task.id = taskId;
            ctx.commit('saveTask', task);
        },
    },
    mutations: {
        setTasks(state, tasks){
            state.tasks = tasks;
        },
        setTask(state, task){
            let stTask = state.tasks.find(x=>x.id == task.id);
            stTask = Object.assign(stTask, task);
            console.log(stTask);
        },
        setActive(state, id){
            state.tasks.forEach(x=>x.Active = false);
            let task = state.tasks.find(x=>x.id == id);
            
            if (task)
                task.Active = true;
        },
    }
}