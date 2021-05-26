import Films from "@/views/Films.vue";
import Tasks from "@/views/Tasks.vue";

const routes = [
  {
    path: "/",
    name: "Фильмы",
    component: Films,
  },
  {
    path: "/tasks",
    name: "Таски",
    component: Tasks,
  },
];

export default routes;