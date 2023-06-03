import { createRouter, createWebHistory } from "vue-router";
import HomeVue from "@/components/Home.vue";
import ProductsVue from "@/components/Products.vue";
import AboutVue from "@/components/About.vue";
import ErrorVue from "@/components/Error.vue";
const routes = [
  {
    path: "/",
    component: HomeVue,
  },
  {
    path: "/products",
    component: ProductsVue,
  },
  {
    path: "/about",
    component: AboutVue,
  },
  {
    path: "/:pathMatch(.*)*",
    component: ErrorVue,
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});
export default router;
