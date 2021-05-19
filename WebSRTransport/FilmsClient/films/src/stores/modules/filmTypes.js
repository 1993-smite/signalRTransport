export default {
    state: {
        filmTypes: []
    },
    getters: {
        getFilmTypes(state){
            return state.filmTypes;
        }
    },
    actions: {
        async fetchFilmTypes(ctx){
            let res = await fetch('http://localhost:9999/api/FilmTypes');
            let types = await res.json();
            console.log(types);
            ctx.commit('setFilmTypes', types);
        }
    },
    mutations: {
        setFilmTypes(state, filmTypes){
            state.filmTypes = filmTypes;
        }
    }
}