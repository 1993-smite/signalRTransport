let taskUrl = 'http://localhost:9999/api/WebTasks';
import M from 'materialize-css'
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
        async fetchTasks(ctx, id = 0){
            let res = await fetch(taskUrl);
            let tasks = await res.json();
            tasks.forEach(x=>{
                x.Active = false;
                x.date = new Date(x.date)
            });
            ctx.commit('setTasks', tasks);
            ctx.commit('setActive', id < 1 ? tasks[0].id : id);
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
        saveTask(ctx, task){
            axios.post(taskUrl, task ).then((response) => {
                let taskId = response.data;
                task.id = taskId;
                ctx.dispatch('fetchTasks', task.id);
            }, (err)=>{
                console.error('test error', err);
                M.toast({html: `<span style='backgound-color: red'>${err.message}</span>`});
            })
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