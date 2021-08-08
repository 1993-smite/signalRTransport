import Films from "@/views/Films.vue";
import Tasks from "@/views/Tasks.vue";
import Frameworks from "@/views/Frameworks.vue";
import Map from "@/views/Map.vue";

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
    component: Map,
    meta: { title: 'Карта' }
  },
];

export default routes;