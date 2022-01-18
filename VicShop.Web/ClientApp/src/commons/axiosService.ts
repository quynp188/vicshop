import { IResponseResult } from "./modules";
import instance from "./axiosConfig";
async function post(url: string, data: object) {
  try {
    const response = await instance.post(url, data);
    return handleSuccess(response);
  } catch (e: any) {
    return handleFailed(e);
  }
}
async function get(url: string) {
  try {
    const response = await instance.get(url);
    return handleSuccess(response);
  } catch (e: any) {
    return handleFailed(e);
  }
}
async function put(url: string, data: object) {
  try {
    const response = await instance.put(url, data);
    return handleSuccess(response);
  } catch (e: any) {
    return handleFailed(e);
  }
}
async function Delete(url: string) {
  try {
    const response = await instance.delete(url);
    return handleSuccess(response);
  } catch (e: any) {
    return handleFailed(e);
  }
}
const handleSuccess = (response: any): IResponseResult => {
  return {
    status: response?.status,
    message: response?.data?.message || "",
    data: response?.data,
  };
};
const handleFailed = (error: any): IResponseResult => {
  if (error.response) {
    return {
      status: error?.response?.status,
      message: error?.response?.data || error?.message,
      data: error?.response?.data,
    };
  }
  return {
    message: error?.message,
  };
};
export { post, get, put, Delete };
