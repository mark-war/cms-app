<template>
  <div class="cust-details">
    <h2>Create Customer</h2>
    <!-- Input fields for creating a new customer -->
    <div class="form-group">
      <label for="firstName">First Name:</label>
      <input type="text" id="firstName" v-model="firstName" />
    </div>
    <div class="form-group">
      <label for="lastName">Last Name:</label>
      <input type="text" id="lastName" v-model="lastName" />
    </div>
    <div class="form-group">
      <label for="email">Email:</label>
      <input type="email" id="email" v-model="email" />
    </div>
    <div class="form-group">
      <label for="phone">Phone:</label>
      <input type="text" id="phone" v-model="phone" />
    </div>
    <div class="form-group">
      <label for="address">Address:</label>
      <input type="text" id="address" v-model="address" />
    </div>
    <div class="button-group">
      <button @click="createCustomer">Create</button>
      <button @click="goBack">Back</button>
    </div>
  </div>
</template>
  
  <script>
import axios from "axios";
import { useToast } from "vue-toastify";
import { getToken } from "../../utils/auth";

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
      const toast = useToast();
      const token = getToken();
      axios
        .post("https://localhost:5001/Customer/Create", newCustomer, {
          headers: { Authorization: `Bearer ${token}` },
        })
        .then(() => {
          toast.success("Customer created successfully!");
          this.$router.push("/");
        })
        .catch((error) => {
          console.error("Error creating customer:", error);

          if (
            error.response &&
            error.response.data &&
            error.response.data.errors
          ) {
            const errors = error.response.data.errors;
            const flattenedErrors = [];

            // Ensure that errors is not undefined or null
            if (errors) {
              // Flatten the nested arrays and concatenate error messages
              Object.keys(errors).forEach((fieldName) => {
                errors[fieldName].forEach((errorMessage) => {
                  flattenedErrors.push(errorMessage);
                });
              });
            }

            // Display each error message in a toast
            flattenedErrors.forEach((errorMessage) => {
              toast.error(errorMessage);
            });
          } else if (error.response && error.response.status === 400) {
            if (error.response.data === "Email address is already in use.") {
              // Display a specific error message for unique constraint violation
              toast.error(
                "Email address is already in use. Please use a different email."
              );
            }
          } else {
            // If the error does not have a response or data,
            // display a generic error message
            toast.error("Failed to create customer. Please try again.");
          }
        });
    },
    goBack() {
      this.$router.push("/");
    },
  },
};
</script>
  
<style scoped>
.cust-details {
  margin-bottom: 20px;
  text-align: center;
  margin-top: 50px;
}
.form-group {
  margin-bottom: 10px;
}
label {
  display: inline-block;
  width: 100px;
}
input {
  padding: 5px;
  width: 200px;
}

.button-group button {
  margin-right: 10px;
  padding: 5px 10px;
}

.button-group button:last-child {
  margin-right: 0;
}
</style>