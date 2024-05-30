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
import apiClient from "../../utils/api";
import { useToast } from "vue-toastify";

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
      apiClient
        .get(`/Customer/GetById/${this.id}`)
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
      apiClient
        .put(`/Customer/Update/${this.id}`, this.editedCustomer)
        .then(() => {
          toast.success("Customer updated successfully!");
          this.isEditing = false;
          this.fetchCustomer(); // Refresh customer details
        })
        .catch((error) => {
          console.error("Error updating customer:", error);

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
            toast.error("Failed to update customer. Please try again.");
          }
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
