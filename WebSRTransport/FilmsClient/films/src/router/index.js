import { createWebHistory, createRouter } from "vue-router";
import Films from "@/views/Films.vue";
import Tasks from "@/views/Tasks.vue";

const routes = [
  {
    path: "/",
    name: "Films",
    component: Films,
  },
  {
    path: "/tasks",
    name: "Tasks",
    component: Tasks,
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;