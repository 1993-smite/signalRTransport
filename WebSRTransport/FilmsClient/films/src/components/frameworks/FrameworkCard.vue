<template>
    <div class="row">
        <div class="col s12">
            <div class="card blue-grey darken-1">
                <div class="card-content white-text">
                    <span class="card-title">
                        {{framework.name}}
                    </span>
                    <div class="row">
                        <div class="input-field col s5 lbl">
                            <span>
                                <label for="name"
                                    class="blue-grey darken-1">Название</label>
                            </span>
                        </div>
                        <div class="input-field col s7">
                            <input id="name" 
                                type="text" 
                                v-model="framework.name"
                                autocomplete="off">
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s5 lbl">
                            <span>
                                <label for="type"
                                    class="blue-grey darken-1">Тип</label>
                            </span>
                        </div>
                        <div class="input-field col s7">
                            <select v-model="framework.type.id" 
                                id="type">
                                <option value="0" 
                                    selected>Не выбрано</option>
                                <option v-for="(type, key) in getFrameworkTypes"
                                    v-bind:key="key"
                                    v-bind:value="type.id"
                                >{{type.name}}</option>
                            </select>
                        </div>
                    </div>
                </div>
                <div class="card-action">
                    
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import { mapGetters } from 'vuex';
import M from 'materialize-css'
// import MomentFormat from '../../libs/moment-format'

export default {
    name: 'FrameworkCard',
    components: {

    },
    data: function(){
        return {
            framework: {
                Active: false,
                type: { 
                    id: 1 
                }
            },
        }
    },
    watch: {
        'getActiveFramework.id': function(){
            let context = this;
            context.framework = Object.assign({},context.getActiveFramework);
            this.readyCard();
        },
    },
    computed: {
        ...mapGetters(['getActiveFramework', 'getFrameworkTypes']),
    },
    methods: {
        readyCard: function(){
            setTimeout(function(){
                var elems = document.querySelectorAll('select');
                M.FormSelect.init(elems, {});
            }, 1);
        }
    },
    mounted(){
        this.readyCard();
    }
}
</script>

<style scoped>
    .lbl{
        background: url('../../assets/table_rounds.png') 100% 90% repeat-x;
        text-align: left;
        margin-top: 30px;
        padding-left: 0px;
    }
    .lbl span{
        font-size: 1.5rem;
    }
    .lbl span label{
        font-size: 16px;
        vertical-align: sub;
    }
</style>
