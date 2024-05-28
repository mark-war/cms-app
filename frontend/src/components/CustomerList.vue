<template>
  <div class="customer-list">
    <router-link to="/create-customer" class="create-customer-btn"
      >Create Customer</router-link
    >

    <table>
      <thead>
        <tr>
          <th>Name</th>
          <th>Email</th>
          <th>Actions</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="customer in customers" :key="customer.customerId">
          <td>{{ customer.firstName }} {{ customer.lastName }}</td>
          <td>{{ customer.email }}</td>
          <td>
            <button
              class="customer-view"
              @click="viewCustomer(customer.customerId)"
            >
              View
            </button>
            <button
              class="customer-del"
              @click="deleteCustomer(customer.customerId)"
            >
              X
            </button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import axios from "axios";

export default {
  data() {
    return {
      customers: [],
    };
  },
  mounted() {
    this.fetchCustomers();
  },
  methods: {
    fetchCustomers() {
      axios
        .get("https://localhost:5001/Customer/GetAll")
        .then((response) => {
          this.customers = response.data;
        })
        .catch((error) => {
          console.error("Error fetching customers:", error);
        });
    },
    viewCustomer(id) {
      this.$router.push({ path: `/customer/${id}` });
    },
    deleteCustomer(id) {
      axios
        .delete(`https://localhost:5001/Customer/Remove/${id}`)
        .then(() => {
          alert("Customer deleted successfully!");
          this.fetchCustomers(); // Refresh the list after deletion
        })
        .catch((error) => {
          console.error("Error deleting customer:", error);
          alert("Failed to delete customer. Please try again.");
        });
    },
  },
};
</script>

<style scoped>
.customer-list {
  max-width: 800px;
  margin: 0 auto;
}

table {
  width: 100%;
  border-collapse: collapse;
  margin-top: 20px;
  margin-bottom: 20px;
}

th,
td {
  border: 1px solid #ccc;
  padding: 8px;
  text-align: left;
}

th {
  background-color: #f2f2f2;
}

.customer-view {
  background: blue;
  border-radius: 5px;
  margin-right: 5px;
}

.customer-del {
  background: red;
  border-radius: 50%;
  margin-left: 5px;
}

.customer-view,
.customer-del {
  color: #fff;
  border: none;
  cursor: pointer;
  transition: background-color 0.3s;
}

.customer-view:hover {
  background-color: #fff;
  color: blue;
}
.customer-del:hover {
  background-color: #fff;
  color: red;
}

.create-customer-btn {
  position: fixed;
  right: 20px;
  padding: 10px 20px;
  background-color: #35495e;
  color: #fff;
  text-decoration: none;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  transition: background-color 0.3s;
}

.create-customer-btn:hover {
  background-color: #fff;
  color: #35495e;
}
</style>