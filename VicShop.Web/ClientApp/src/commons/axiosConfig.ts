import axios from "axios";
import { BASE_URL } from "./constants";
const instance = axios.create({
  baseURL: BASE_URL,
});
instance.interceptors.request.use(
  async function (config) {
    // let token = localStorage.getItem('token');
    // if (token) {
    //   config.headers['x-auth-token'] = token;
    // }
    // Do something before request is sent
    return config;
  },
  function (error) {
    return Promise.reject(error);
  }
);

// Add a response interceptor
instance.interceptors.response.use(
  function (response) {
    return response;
  },
  function (error) {
    return Promise.reject(error);
  }
);
export default instance;
