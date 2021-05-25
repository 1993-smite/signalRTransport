import { createStore } from 'vuex'
import films from'./modules/films';
import filmTypes from'./modules/filmTypes';
import tasks from'./modules/tasks';

export default createStore({
  modules: {
    films,
    filmTypes,
    tasks
  }
})