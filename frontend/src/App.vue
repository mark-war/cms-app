<template>
  <div id="app">
    <h1 class="cust-header">Customer Management System</h1>
    <!-- <TokenGenerator /> -->
    <router-view></router-view>
  </div>
</template>

<script>
// import TokenGenerator from "./components/TokenGenerator.vue";

export default {
  name: "App",
  // components: {
  //   TokenGenerator,
  // },
};
</script>

<style scoped>
* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
}

.cust-header {
  justify-content: center;
  text-align: center;
  padding: 10px;
  background-color: #42b883;
  color: #fff;
}

main {
  flex: 1;
  padding: 20px;
}

/* Responsive styles */
@media (max-width: 600px) {
  .cust-header {
    font-size: 1.5rem;
  }

  main {
    padding: 10px;
  }
}
</style>