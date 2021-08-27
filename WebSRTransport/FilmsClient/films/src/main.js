import 'materialize-css/dist/css/materialize.min.css'
import 'material-design-icons/iconfont/material-icons.css'
import 'vue3-openlayers/dist/vue3-openlayers.css'
import 'ol/ol.css'
import './main.css'

import { createApp } from 'vue'
import App from './App.vue'
import store from "./stores/index.js"
import router from './router'
import OpenLayersMap from 'vue3-openlayers'
import directives from './directives/main.js'

const appMain = createApp(App).use(store).use(router).use(OpenLayersMap);
directives.Directives.call(appMain);
appMain.mount('#app');

import moment from 'moment'
moment.locale('ru-ru')