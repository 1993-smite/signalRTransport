import Films from "@/views/Films.vue";
import Tasks from "@/views/Tasks.vue";

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
];

export default routes;