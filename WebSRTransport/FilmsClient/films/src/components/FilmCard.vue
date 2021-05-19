<template>
    <div class="card">
        <div class="card-content">
            <div class="row">
                <div class="input-field">
                    <h4>{{film.name}}</h4>
                </div>
            </div>
            <div class="row">
                <div class="input-field">
                    <input placeholder="Название"
                        id="first_name" 
                        type="text"
                        v-model="film.name">
                    <label for="first_name">Фильм</label>
                </div>
            </div>
            <div class="row">
                <div class="input-field">
                    <select>
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
                    <input placeholder="Страна"
                        id="country" 
                        type="text"
                        v-model="film.country">
                    <label for="country">Страна</label>
                </div>
            </div>
            <div class="row">
                <div class="input-field">
                    <input placeholder="Год"
                        id="country" 
                        type="number"
                        v-model="film.year">
                    <label for="country">Год</label>
                </div>
            </div>
            <div class="row">
                <div class="input-field">
                <textarea id="description" class="materialize-textarea"></textarea>
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
import connection from "./../filmSignalR.js"

export default {
    name: 'FilmCard',
    computed: {
        ...mapGetters(['getFilmTypes','getActiveFilm']),
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
            this.hub.invoke('send', `<span>film: ${this.film.id} has been opened</span>`);
        }
    },
    data: function(){
        return {
            film: {},
            hub: connection.hub
        }
    },
    methods: {
        ...mapActions(["saveFilm","newFilm","setActive","removeFilm","fetchFilmTypes"]),
        saveFilmCard(){
            //this.$store.dispatch('saveFilm', this.film);
            this.saveFilm(this.film);
            this.hub.invoke('send', `film: ${this.film.id} has beeen saved`);
        },
        clearFilm(){
            //this.$store.dispatch('newFilm');
            this.newFilm();
            //this.$store.dispatch('setActive', -1);
            this.setActive(-1);
            //this.$refs.default.focus();
        },
        removeFilm(){
            //this.$store.dispatch('removeFilm', this.film);
            this.removeFilm(this.film);
            this.clearFilm();
        },
    },
    async mounted(){
        //this.$store.dispatch('fetchFilmTypes');
        await this.fetchFilmTypes();
        M.updateTextFields();
        M.textareaAutoResize($('#description'));
        console.log(connection);
    }
}
</script>

<style scoped>
    .card-header {
        text-align: center;
    }
    button.btn{
        margin: 0px 4px;
    }
</style>