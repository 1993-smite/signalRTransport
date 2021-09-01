import Films from "@/views/Films.vue";
import Tasks from "@/views/Tasks.vue";
import Frameworks from "@/views/Frameworks.vue";
import MapWorker from "@/views/MapWorker.vue";
import Directives from "@/views/Directives.vue";
import Animate from "@/views/Animate.vue";
import Video from "@/views/Video.vue";

const routes = [
  {
    path: "/",
    name: "Фильмы",
    component: Films,
    meta: { title: 'Фильмы' }
  },
  {
    path: "/tasks",
    name: "Таски",
    component: Tasks,
    meta: { title: 'Таски' }
  },
  {
    path: "/frameworks",
    name: "Фреймворки",
    component: Frameworks,
    meta: { title: 'Фреймворки' }
  },
  {
    path: "/map",
    name: "Карта",
    component: MapWorker,
    meta: { title: 'Карта' }
  },
  {
    path: "/directives",
    name: "Директивы",
    component: Directives,
    meta: { title: 'Директивы' }
  },
  {
    path: "/animate",
    name: "Анимации",
    component: Animate,
    meta: { title: 'Анимации' }
  },
  {
    path: "/video",
    name: "Плей лист",
    component: Video,
    meta: { title: 'Плей лист' }
  },
];

export default routes;