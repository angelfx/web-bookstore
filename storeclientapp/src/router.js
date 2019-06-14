import Vue from "vue";
import Router from "vue-router";
import Home from "./views/Home.vue";
//import { isAbsolute } from 'path';
//import AboutTemplate from './components/AboutTemplate.vue'
import About from "./views/About.vue";
import Books from "./views/Books.vue";
import Book from "./views/Book.vue";
import AddBook from "./views/AddBook.vue";

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: "/",
      name: "home",
      component: Home
    },
    {
      path: "/about",
      name: "about",
      component: About
      //component: AboutTemplate,
      // route level code-splitting
      // this generates a separate chunk (about.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      //component: () => import(/* webpackChunkName: "about" */ './views/About.vue')
    },
    {
      path: "/books",
      name: "books",
      component: Books
    },
    {
      path: "/book/:id",
      name: "book",
      component: Book
    },
    {
      path: "/books/add",
      name: "addbook",
      component: AddBook
    },
    {
      path: "/books/add/:id",
      name: "updatebook",
      component: AddBook
    }
  ]
});
