<template>
  <div class="cust-details">
    <h2>Customer Details</h2>
    <div v-if="customer">
      <div class="form-group">
        <label for="firstName">First Name:</label>
        <input
          type="text"
          id="firstName"
          v-model="editedCustomer.firstName"
          :disabled="!isEditing"
        />
      </div>
      <div class="form-group">
        <label for="lastName">Last Name:</label>
        <input
          type="text"
          id="lastName"
          v-model="editedCustomer.lastName"
          :disabled="!isEditing"
        />
      </div>
      <div class="form-group">
        <label for="email">Email:</label>
        <input
          type="text"
          id="email"
          v-model="editedCustomer.email"
          :disabled="!isEditing"
        />
      </div>
      <div class="form-group">
        <label for="phone">Phone:</label>
        <input
          type="text"
          id="phone"
          v-model="editedCustomer.phone"
          :disabled="!isEditing"
        />
      </div>
      <div class="form-group">
        <label for="address">Address:</label>
        <input
          type="text"
          id="address"
          v-model="editedCustomer.address"
          :disabled="!isEditing"
        />
      </div>
      <div v-if="isEditing" class="button-group">
        <button @click="saveChanges">Save</button>
        <button @click="cancelEdit">Cancel</button>
      </div>
      <div v-else class="button-group">
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
import { useToast } from "vue-toastify";
import { getToken } from '../../utils/auth';

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
      const toast = useToast();
      const token = getToken();
      axios
        .get(`https://localhost:5001/Customer/GetById/${this.id}`, {
          headers: { Authorization: `Bearer ${token}` },
        })
        .then((response) => {
          this.customer = response.data;
          // Clone the customer object for editing
          this.editedCustomer = { ...this.customer };
        })
        .catch((error) => {
          console.error("Error fetching customer:", error);
          toast.error("Customer not found. Please try again.");
        });
    },
    toggleEdit() {
      this.isEditing = !this.isEditing;
    },
    saveChanges() {
      const toast = useToast();
      const token = getToken();
      axios
        .put(
          `https://localhost:5001/Customer/Update/${this.id}`,
          this.editedCustomer,
          {
            headers: { Authorization: `Bearer ${token}` },
          }
        )
        .then(() => {
          toast.success("Customer updated successfully!");
          this.isEditing = false;
          this.fetchCustomer(); // Refresh customer details
        })
        .catch((error) => {
          console.error("Error updating customer:", error);
          toast.error("Failed to update customer. Please try again.");
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
