import Common from '../../libs/common'
const axios = require('axios')
let filmUrl = 'http://localhost:9999/api/Films';

export default {
    state: {
        films: [],
        count: 0
    },
    getters: {
        getFilms(state){
            return state.films;
        },
        getFilmsCount(state){
            return state.count;
        },
        getActiveFilm(state){
            return state.films.find(x=>x.Active);
        }
    },
    actions: {
        async fetchFilms(ctx, data){
            let params = Common.objToStr(data);
            let res = await fetch(`${filmUrl}?${params}`);
            let result = await res.json();
            let films = result.item1;
            films.forEach(x=>x.Active = false);

            if (films.length > 0)
                films[0].Active = true; //!!!!!!!!
                
            ctx.commit('setFilms', films);
            ctx.commit('setCount', result.item2);
        },
        async getFilm(ctx, id){
            let res = await fetch(`${filmUrl}/${id}`);
            let result = await res.json();
            let films = [result];
            ctx.commit('setFilms', films);
            ctx.commit('setActive', films[0].id);
        },
        setActive(ctx, id){
            ctx.commit('setActive', id);
        },
        async saveFilm(ctx, film){
            let response = await axios
            .post(filmUrl, film );
            let filmId = response.data;
            film.id = filmId;
            ctx.commit('saveFilm', film);
        },
        async removeFilm(ctx, film){
            await axios.delete(`${filmUrl}/${film.id}`);
            ctx.commit('removeFilm', film);
        },
        newFilm() {
            return {
                id: 0
            };
        }
    },
    mutations: {
        setFilms(state, films){
            state.films = films;
        },
        setCount(state, count){
            state.count = count;
        },
        setActive(state, id){
            state.films.forEach(x=>x.Active = false);
            let film = state.films.find(x=>x.id == id);
            
            if (film)
                film.Active = true;
        },
        saveFilm(state, film){
            let exist = state.films.filter(x=>x.id == film.id);
            exist = film;
            return exist;
        },
        removeFilm(state, film){
            state.films = state.films.filter(x=>x.id != film.id);
        }
    }
}