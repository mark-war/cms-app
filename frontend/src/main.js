import { createApp } from 'vue';
import App from './App.vue';
import { createRouter, createWebHistory } from 'vue-router';
import CustomerList from './components/CustomerList.vue';
import CustomerView from './components/CustomerView.vue';
import CreateCustomer from './components/CreateCustomer.vue'

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
app.use(router);
app.mount('#app');
