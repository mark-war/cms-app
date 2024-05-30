import { createApp } from 'vue';
import App from './App.vue';
import VueToastify from 'vue-toastify';
import { createRouter, createWebHistory } from 'vue-router';
import CustomerList from './components/CustomerList.vue';
import CustomerView from './components/CustomerView.vue';
import CreateCustomer from './components/CreateCustomer.vue'
import 'vue-toastify/index.css'; //import the CSS file

const routes = [
  { path: '/', component: CustomerList },
  { path: '/customer/:id', component: CustomerView, props: true },
  { path: '/create-customer', component: CreateCustomer }
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

const app = createApp(App);
app.use(VueToastify, {
    position: 'top-right', // Set the position to top-right
    duration: 3000, // Set the duration of the toast
    theme: "dark" // You can choose between "light", "dark", or "colored"
  });
app.use(router);
app.mount('#app');
