<template>
  <div id="app">
    <h1 class="cust-header">Customer Management System</h1>
    <router-view></router-view>
  </div>
</template>

<script>
export default {
  name: "App",
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