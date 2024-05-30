import axios from 'axios';
import { getToken } from './auth';

const apiClient = axios.create({
  baseURL: process.env.VUE_APP_API_BASE_URL,
  headers: {
    Authorization: `Bearer ${getToken()}`
  }
});
console.log(process.env.VUE_APP_API_BASE_URL)
export default apiClient;
