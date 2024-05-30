import axios from 'axios';
import { getToken } from './auth';

//to remove the redundancy of code in each method and append the headers
const apiClient = axios.create({
  baseURL: process.env.VUE_APP_API_BASE_URL || 'https://localhost:5001', // Default URL if not provided in environment,
  headers: {
    Authorization: `Bearer ${getToken()}`
  }
});

export default apiClient;
