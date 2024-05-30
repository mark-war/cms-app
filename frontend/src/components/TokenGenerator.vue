<template>
  <div>
    <button @click="generateToken">Generate Token</button>
  </div>
</template>
    
  <script>
import { generateToken } from "../../utils/auth";

export default {
  name: "TokenGenerator",
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
    