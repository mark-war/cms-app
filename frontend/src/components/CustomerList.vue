<template>
  <div class="customer-list">
    <table>
      <thead>
        <tr>
          <th>Name</th>
          <th>Email</th>
          <th class="action-col">Actions</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="customer in paginatedCustomers" :key="customer.customerId">
          <td>{{ customer.firstName }} {{ customer.lastName }}</td>
          <td>{{ customer.email }}</td>
          <td class="action-btn">
            <button
              class="customer-view"
              @click="viewCustomer(customer.customerId)"
            >
              Details
            </button>
            <button
              class="customer-del"
              @click="deleteCustomer(customer.customerId)"
            >
              Delete
            </button>
          </td>
        </tr>
      </tbody>
    </table>
    <div class="pagination">
      <button @click="prevPage" :disabled="currentPage === 1">Previous</button>
      <span>Page {{ currentPage }} of {{ totalPages }}</span>
      <button @click="nextPage" :disabled="currentPage === totalPages">
        Next
      </button>
    </div>
    <router-link to="/create-customer" class="create-customer-btn"
      >+</router-link
    >
  </div>
</template>

<script>
import apiClient from "../../utils/api";
import { useToast } from "vue-toastify";
import { checkTokenExpiration } from "../../utils/auth";

export default {
  data() {
    return {
      customers: [],
      currentPage: 1,
      customersPerPage: 10, // Number of customers to show per page
    };
  },
  mounted() {
    checkTokenExpiration(); // Check token expiration on component mount
    this.fetchCustomers();
  },
  methods: {
    fetchCustomers() {
      const toast = useToast();
      apiClient
        .get("/Customer/GetAll")
        .then((response) => {
          this.customers = response.data;
        })
        .catch((error) => {
          console.error("Error fetching customers:", error);
          toast.error("Failed to fetch customers. Please try again.");
        });
    },
    viewCustomer(id) {
      this.$router.push({ path: `/customer/${id}` });
    },
    deleteCustomer(id) {
      const toast = useToast();
      apiClient
        .delete(`/Customer/Remove/${id}`)
        .then(() => {
          toast.success("Customer deleted successfully!");
          this.fetchCustomers(); // Refresh the list after deletion
        })
        .catch((error) => {
          console.error("Error deleting customer:", error);
          toast.error("Failed to delete customer. Please try again.");
        });
    },
    nextPage() {
      if (this.currentPage < this.totalPages) {
        this.currentPage++;
      }
    },
    prevPage() {
      if (this.currentPage > 1) {
        this.currentPage--;
      }
    },
    setPage(page) {
      if (page >= 1 && page <= this.totalPages) {
        this.currentPage = page;
      }
    },
  },
  computed: {
    paginatedCustomers() {
      const start = (this.currentPage - 1) * this.customersPerPage;
      const end = start + this.customersPerPage;
      return this.customers.slice(start, end);
    },
    totalPages() {
      return Math.ceil(this.customers.length / this.customersPerPage);
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

th.action-col,
td.action-btn {
  width: 120px;
}

.customer-view {
  background: rgb(126, 126, 224);
  border-radius: 5px;
  margin-right: 5px;
}

.customer-del {
  background: rgb(241, 92, 92);
  border-radius: 5px;
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
  color: rgb(126, 126, 224);
}
.customer-del:hover {
  background-color: #fff;
  color: rgb(241, 92, 92);
}

.create-customer-btn {
  position: fixed;
  right: 20px;
  bottom: 20px; /* Adjust positioning as needed */
  width: 50px;
  height: 50px;
  background-color: #35495e;
  color: #fff;
  text-decoration: none;
  border: none;
  border-radius: 50%; /* Make it a circle */
  cursor: pointer;
  transition: background-color 0.3s;
  display: flex;
  justify-content: center;
  align-items: center;
  font-size: 24px; /* Adjust font size as needed */
}

.create-customer-btn:hover::before {
  content: "Add New Customer";
  position: absolute;
  top: -30px; /* Adjust positioning as needed */
  left: 50%; /* Adjust positioning as needed */
  transform: translateX(-50%);
  background-color: #fff;
  color: #35495e;
  padding: 5px 10px;
  border-radius: 5px;
  font-size: 14px; /* Adjust font size as needed */
  opacity: 0; /* Initially hidden */
  transition: opacity 0.3s;
}

.create-customer-btn:hover::before {
  opacity: 1; /* Show on hover */
}

/* Responsive styles */
@media (max-width: 600px) {
  .customer-list {
    padding: 10px;
  }

  table {
    font-size: 14px;
  }

  th.action-col,
  td.action-btn {
    width: 100px;
  }

  .customer-view,
  .customer-del {
    padding: 5px;
    margin: 2px 0;
    width: 100%;
  }

  /* .create-customer-btn {
    padding: 8px 16px;
  } */
}

.pagination {
  display: flex;
  justify-content: center;
  align-items: center;
  margin-top: 20px;
}

.pagination button {
  margin: 0 5px;
  padding: 5px 10px;
  background-color: #35495e;
  color: #fff;
  border: none;
  cursor: pointer;
  border-radius: 5px;
  transition: background-color 0.3s;
}

.pagination button:disabled {
  background-color: #ccc;
  cursor: not-allowed;
}

.pagination span {
  margin: 0 10px;
}
</style>