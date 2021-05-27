<template>
    <div class="row"
        v-on:keyup.enter="save()"
        v-on:keyup.esc="newTask()">
        <div class="col s12">
            <div class="card blue-grey darken-1">
                <div class="card-content white-text">
                    <span class="card-title">
                        {{task.name}}
                        <div class="switch">
                            <label>
                                Off
                            <input type="checkbox" 
                                v-model="state">
                            <span class="lever"></span>
                                On
                            </label>
                        </div>
                    </span>
                    <div class="row">
                        <div class="input-field col s12">
                            <input id="name" 
                                type="text" 
                                v-model="task.name"
                                autocomplete="off">
                            <label for="name">Название</label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s12">
                            <input id="date" 
                                type="text" 
                                class="datepicker" 
                                :value="getDate">
                            <label for="date">Дата</label>
                        </div>
                    </div>
                </div>
                <div class="card-action">
                    <a href="#"
                        v-on:click="newTask()">Новый таск</a>
                    <a href="#"
                        v-on:click="save()">Сохранить</a>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';
import M from 'materialize-css'
import MomentFormat from './../../libs/moment-format'

export default {
    name: 'TaskCard',
    components: {

    },
    data: function(){
        return {
            task: {
                Active: false
            },
            state: false
        }
    },
    watch: {
        'getActiveTask.id': function(){
            let context = this;
            context.task = Object.assign({},context.getActiveTask);
            context.state = context.task.status == 1;
            this.readyCard();
        },
        state: function(value){
            this.task.status = value ? 1 : 9;
        }
    },
    computed: {
        ...mapGetters(['getActiveTask']),
        getDate: function (){
            return MomentFormat.getDateFormat(this.task.date);
        }
    },
    methods: {
        ...mapActions(["saveTask","newTask","setActiveTask"]),
        save: async function(){
            await this.saveTask(this.task);
        },
        newTask: function(){
            this.task = Object.assign(this.task,{
                id: 0,
                name: '',
                status: 1,
                date: new Date(),
            });
            this.state = true;
            this.readyCard();
        },
        readyCard: function(){
            let context = this;

            M.updateTextFields();

            var elem = document.querySelectorAll('#date');
            let dtMax = new Date();
            dtMax.setFullYear(dtMax.getFullYear()+2);

            M.Datepicker.init(elem, {
                defaultDate: context.task.date,
                minDate: new Date(),
                maxDate: dtMax,
                format: 'dd mmmm',
                i18n: {
                    months: ["Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"],
                    monthsShort: ["Янв", "Фев", "Мар", "Апр", "Май", "Июнь", "Июль", "Авг", "Сен", "Окт", "Нбр", "Дек"],
                    weekdays: ["Воскресенье","Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота"],
                    weekdaysShort: ["Вс","Пон", "Вт", "Ср", "Чет", "Пят", "Суб"],
                    weekdaysAbbrev: ["Вс","Пн", "Вт", "Ср", "Чт", "Пт", "Сб"]
                },
                onSelect: function(date){
                    context.task.date = new Date(date.setHours(5));
                    //this.task
                }
            });
        }
    },
    mounted(){
        document.getElementById('name').focus();
    }
}
</script>

<style>
    
    .datepicker-calendar-container {
        color: black !important;
    }
    .selects-container input {
        color: black !important;
    }
    .card .card-content input:not(:read-only){
        color: white !important;
    }
</style>
