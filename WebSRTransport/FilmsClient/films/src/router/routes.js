import Films from "@/views/Films.vue";
import Tasks from "@/views/Tasks.vue";
import Frameworks from "@/views/Frameworks.vue";

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
];

export default routes;