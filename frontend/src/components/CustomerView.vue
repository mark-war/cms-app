<template>
  <div class="cust-details">
    <h2>Customer Details</h2>
    <div v-if="customer">
      <div>
        <label for="firstName">First Name:</label>
        <input
          type="text"
          id="firstName"
          v-model="editedCustomer.firstName"
          :disabled="!isEditing"
        />
      </div>
      <div>
        <label for="lastName">Last Name:</label>
        <input
          type="text"
          id="lastName"
          v-model="editedCustomer.lastName"
          :disabled="!isEditing"
        />
      </div>
      <div>
        <label for="email">Email:</label>
        <input
          type="text"
          id="email"
          v-model="editedCustomer.email"
          :disabled="!isEditing"
        />
      </div>
      <div>
        <label for="phone">Phone:</label>
        <input
          type="text"
          id="phone"
          v-model="editedCustomer.phone"
          :disabled="!isEditing"
        />
      </div>
      <div>
        <label for="address">Address:</label>
        <input
          type="text"
          id="address"
          v-model="editedCustomer.address"
          :disabled="!isEditing"
        />
      </div>
      <div v-if="isEditing">
        <button @click="saveChanges">Save</button>
        <button @click="cancelEdit">Cancel</button>
      </div>
      <div v-else>
        <button @click="toggleEdit">Update</button>
        <button @click="goBack">Back</button>
      </div>
    </div>
    <div v-else>
      <p>Loading...</p>
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  props: ["id"],
  data() {
    return {
      customer: null,
      editedCustomer: null,
      isEditing: false,
    };
  },
  mounted() {
    this.fetchCustomer();
  },
  methods: {
    fetchCustomer() {
      axios
        .get(`https://localhost:5001/Customer/GetById/${this.id}`)
        .then((response) => {
          this.customer = response.data;
          // Clone the customer object for editing
          this.editedCustomer = { ...this.customer };
        })
        .catch((error) => {
          console.error("Error fetching customer:", error);
          alert("Customer not found. Please try again.");
        });
    },
    toggleEdit() {
      this.isEditing = !this.isEditing;
    },
    saveChanges() {
      axios
        .put(
          `https://localhost:5001/Customer/Update/${this.id}`,
          this.editedCustomer
        )
        .then(() => {
          alert("Customer updated successfully!");
          this.isEditing = false;
          this.fetchCustomer(); // Refresh customer details
        })
        .catch((error) => {
          console.error("Error updating customer:", error);
          alert("Failed to update customer. Please try again.");
        });
    },
    cancelEdit() {
      // Reset editedCustomer to original values
      this.editedCustomer = { ...this.customer };
      this.isEditing = false;
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
