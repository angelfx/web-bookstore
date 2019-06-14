import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import axios from "axios";
import BootstrapVue from "bootstrap-vue";
import moment from "moment";

import "bootstrap/dist/css/bootstrap.css";
import "bootstrap-vue/dist/bootstrap-vue.css";

Vue.config.productionTip = false;
Vue.use(axios);
Vue.use(BootstrapVue);
Vue.use(moment);

export const HTTP = axios.create({
  baseURL: "http://localhost:5564/"
});

Vue.prototype.$http = HTTP;
Vue.prototype.moment = moment;
Vue.prototype.router = router;

new Vue({
  router,
  moment,
  render: h => h(App)
}).$mount("#app");
