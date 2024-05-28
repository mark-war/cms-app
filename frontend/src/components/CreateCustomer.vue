<template>
  <div class="cust-details">
    <h2>Create Customer</h2>
    <!-- Input fields for creating a new customer -->
    <div>
      <label for="firstName">First Name:</label>
      <input type="text" id="firstName" v-model="firstName" />
    </div>
    <div>
      <label for="lastName">Last Name:</label>
      <input type="text" id="lastName" v-model="lastName" />
    </div>
    <div>
      <label for="email">Email:</label>
      <input type="email" id="email" v-model="email" />
    </div>
    <div>
      <label for="phone">Phone:</label>
      <input type="text" id="phone" v-model="phone" />
    </div>
    <div>
      <label for="address">Address:</label>
      <input type="text" id="address" v-model="address" />
    </div>
    <div>
      <button @click="createCustomer">Create</button>
      <button @click="goBack">Back</button>
    </div>
  </div>
</template>
  
  <script>
import axios from "axios";

export default {
  data() {
    return {
      firstName: "",
      lastName: "",
      email: "",
      phone: "",
      address: "",
    };
  },
  methods: {
    createCustomer() {
      const newCustomer = {
        firstName: this.firstName,
        lastName: this.lastName,
        email: this.email,
        phone: this.phone,
        address: this.address,
      };

      axios
        .post("https://localhost:5001/Customer/Create", newCustomer)
        .then(() => {
          alert("Customer created successfully!");
          this.$router.push("/");
        })
        .catch((error) => {
          console.error("Error creating customer:", error);
          alert("Failed to create customer. Please try again.");
        });
    },
    goBack() {
      this.$router.push("/");
    },
  },
};
</script>
  
  <style scoped>
/* Add your CSS styles here */
.cust-details {
  margin-bottom: 10px;
  justify-content: center;
  text-align: center;
}
label {
  display: inline-block;
  width: 100px;
}
input {
  padding: 5px;
  width: 200px;
}
button {
  padding: 5px 10px;
  margin-top: 10px;
}
</style>