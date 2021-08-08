import 'materialize-css/dist/css/materialize.min.css'
import 'material-design-icons/iconfont/material-icons.css'
import 'ol/ol.css'
import './main.css'

import { createApp } from 'vue'
import App from './App.vue'
import store from "./stores/index.js"
import router from './router'

createApp(App).use(store).use(router).mount('#app')

import moment from 'moment'
moment.locale('ru-ru')