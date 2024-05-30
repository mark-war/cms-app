<template>
  <div>
    <button @click="generateToken">{{ buttonLabel }}</button>
  </div>
</template>
    
  <script>
import { generateToken } from "../../utils/auth";

export default {
  name: "TokenGenerator",
  computed: {
    buttonLabel() {
      // Check if a token exists in localStorage
      console.log(localStorage.getItem("token"));
      return localStorage.getItem("token") ? "Renew Token" : "Generate Token";
    },
  },
  methods: {
    generateToken() {
      generateToken();
    },
  },
};
</script>
    
  <style scoped>
button {
  margin-top: 20px;
  padding: 10px 20px;
  background-color: #42b883;
  color: #fff;
  border: none;
  cursor: pointer;
}

p {
  margin-top: 20px;
  color: #333;
}
</style>
    