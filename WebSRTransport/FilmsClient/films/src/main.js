import 'materialize-css/dist/css/materialize.min.css'
import 'material-design-icons/iconfont/material-icons.css'

import { createApp } from 'vue'
import App from './App.vue'
import store from "./stores/index.js"

createApp(App).use(store).mount('#app')