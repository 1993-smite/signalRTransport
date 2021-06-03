<template>
    <div class="card blue-grey darken-1" v-cloak>
        <div class="card-content">
            <div class="row">
                <div class="input-field">
                    <h4>{{film.name}}</h4>
                    <div class="switch">
                        <label>
                        Неактивный
                        <input type="checkbox" v-model="film.activeState">
                        <span class="lever"></span>
                        Активный
                        </label>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="input-field">
                    <i class="material-icons prefix">text_format</i>
                    <input placeholder="Название"
                        id="first_name" 
                        type="text"
                        autocomplete="off"
                        v-model="film.name">
                    <label for="first_name">Фильм</label>
                </div>
            </div>
            <div class="row">
                <div class="input-field">
                    <i class="material-icons prefix">text_format</i>
                    <select id="type" 
                        v-model="film.type.id"
                        v-bind:defaultValue="film.type.id"
                        >
                        <option value="" disabled selected>Выберите тип</option>
                        <option v-for="(type, index) in getFilmTypes"
                            v-bind:key="index"
                            v-bind:value="type.id">
                            {{type.name}}
                        </option>
                    </select>
                    <label>Тип</label>
                </div>
            </div>
            <div class="row">
                <div class="input-field">
                    <i class="material-icons prefix">call_made</i>
                    <input type="text" 
                        placeholder="Страна"
                        id="country"
                        class="autocomplete" 
                        autocomplete="off"
                        v-bind:value="film.country"
                        >
                    <label for="country">Страна</label>
                </div>
            </div>
            <div class="row">
                <div class="input-field">
                    <i class="material-icons prefix">textsms</i>
                    <input placeholder="Год"
                        id="year" 
                        type="number"
                        v-model="film.year">
                    <label for="country">Год</label>
                </div>
            </div>
            <div class="row">
                <div class="input-field">
                    <i class="material-icons prefix">textsms</i>
                    <input placeholder="Бюджет"
                        id="budget" 
                        type="number"
                        v-model="film.budget">
                    <label for="budget">Бюджет</label>
                </div>
            </div>
            <div class="row">
                <div class="input-field">
                    <i class="material-icons prefix">description</i>
                    <textarea id="description" 
                        class="materialize-textarea"
                        v-model="film.description"></textarea>
                    <label for="description">Описание</label>
                </div>
            </div>
            <div class="row">
                <button 
                    class="btn"
                    v-on:click="saveFilmCard">Сохранить</button>
            </div>
        </div>
    </div>
</template>

<script>
import M from 'materialize-css'
import $ from 'jquery'
import { mapGetters, mapActions } from 'vuex';

const activeState = 0;

export default {
    name: 'FilmCard',
    props: {
        hub: Object
    },
    computed: {
        ...mapGetters(['getFilmTypes','getActiveFilm']),
        Countries(){
            let countries = [
                "США",
                "Россия",
                "Швеция",
                "Великобритания",
                "Нидерланды",
                "Испания",
                "Италия",
                "Канада",
                "Эстония",
                "Бельгия",
                "Китай",
                "Северная корея",
                "Южная корея",
                "Греция",
                "Бразилия",
                "Аргентина",
                "Уругвай",
                "Мексика",
                "Болгария"
            ];
            let autocomplete = {};
            for(let index = 0; index < countries.length; index++){
                autocomplete[countries[index]] = countries[index];
            }
            return autocomplete;
        },
        getDollarsFormatted: function(){
            return (Number.parseFloat(this.getActiveFilm.budget))
                        .toFixed(2)
                        .replace(/\d(?=(\d{3})+\.)/g, '$&,');
        },
        getDollarsMln: function(){
            let mln = Number.parseFloat(this.getActiveFilm.budget) / 10e5;
            return (mln).toFixed(2)
                        .replace(/\d(?=(\d{3})+\.)/g, '$&,');
        },
        getHours: function(){
            let hours = Number.parseFloat(this.getActiveFilm.timing || 0) / 60;
            return hours.toFixed(2) ;
        },
        getSubstractFromNow: function(){
            let currentYear = (new Date()).getFullYear();
            let year = Number.parseInt(this.getActiveFilm.year) || currentYear;
            return currentYear - year;
        }
    },
    watch:{
        'getActiveFilm.id': function(){
            this.film = Object.assign({},this.getActiveFilm);
            
            this.film.activeState = this.film.state === activeState;

            let context = this;
            setTimeout(()=>{
                var elem = document.querySelector('#type');
                M.FormSelect.init(elem);
                
                M.updateTextFields();
                M.textareaAutoResize($('#description'));
                
                elem = document.querySelector('#country');
                M.Autocomplete.init(elem, {
                    data: context.Countries,
                    onAutocomplete: function(value){
                        context.film.country = value
                    }
                });
            }, 200);
        },
        'film.activeState': function(value){
            if (value)
                this.film.state = activeState;
            else
                this.film.state = 9;
        }
    },
    data: function(){
        return {
            film: {
                type: {
                    id: 0
                }
            }
        }
    },
    methods: {
        ...mapActions(["saveFilm","newFilm","setActive","removeFilm","fetchFilmTypes"]),
        saveFilmCard(){
            this.saveFilm(this.film);
        },
        clearFilm(){
            this.newFilm();
            this.setActive(-1);
        },
        removeFilm(){
            this.removeFilm(this.film);
            this.clearFilm();
        },
    },
    async mounted(){
        await this.fetchFilmTypes();
    }
}
</script>

<style>
    .card-header {
        text-align: center;
    }
    .card {
        color: white;
    }
    .card .select-dropdown {
        color: white;
    }
    button.btn{
        margin: 0px 4px;
    }
</style>