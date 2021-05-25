<template>
    <div class="row">
        <div class="col s12">
            <div class="card blue-grey darken-1">
                <div class="card-content white-text">
                    <span class="card-title">{{task.name}}</span>
                    <div class="row">
                        <div class="input-field col s12">
                            <input id="name" type="text" v-model="task.name">
                            <label for="name">Название</label>
                        </div>
                    </div>
                </div>
                <div class="card-action">
                    <a href="#">This is a link</a>
                    <a href="#">This is a link</a>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';
import M from 'materialize-css'

export default {
    name: 'TaskCard',
    components: {

    },
    data: function(){
        return {
            task: {
                Active: false
            }
        }
    },
    watch: {
        'getActiveTask.id': function(){
            this.task = Object.assign({},this.getActiveTask);
            M.updateTextFields();
        }
    },
    computed: {
        ...mapGetters(['getActiveTask']),
    },
    methods: {
        ...mapActions(["saveTask","newTask","setActiveTask"]),
    }
}
</script>
