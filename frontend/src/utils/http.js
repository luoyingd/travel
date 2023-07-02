import axios from "axios";
import { myToken } from "./auth";
import loadingStore from "../stores/common/loadingStore";
import history from "./history";
import { message } from "antd";
const baseURL = "http://localhost:8090";
const http = axios.create({
  baseURL: baseURL,
  timeout: 20000,
  withCredentials: true,
});

const beforeRequest = (config) => {
  const token = myToken.getToken();
  if (token) {
    config.headers["Authorization"] = "Bearer " + token;
  }
  loadingStore.isLoading = true;
  return config;
};

http.interceptors.request.use(beforeRequest);

const responseSuccess = (response) => {
  const data = response.data;
  loadingStore.isLoading = false;
  if (data !== null) {
    if (data.code !== 200) {
      message.error(data.message, [3]);
      return Promise.reject(data.message);
    }
  }
  return Promise.resolve(data);
};
const responseFailed = (error) => {
  const { response } = error;
  if (response) {
    console.log(response)
    if (response.status === 401) {
      message.error("Need Login!", [3]);
      history.push("/login");
    }
    return Promise.reject();
  } else if (!window.navigator.onLine) {
    return Promise.reject(new Error("Please check the Internet..."));
  }
  return Promise.reject(error);
};
http.interceptors.response.use(responseSuccess, responseFailed);

export { http, baseURL };
