import { createStore } from 'vuex'
import films from'./modules/films';
import filmTypes from'./modules/filmTypes';

export default createStore({
  modules: {
    films,
    filmTypes
  }
})