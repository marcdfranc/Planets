import axios, { AxiosResponse } from "axios";
import { PaginatedResult } from "../models/Pagination";
import { Planet, PlanetFormValues } from "../models/Planet";


// test loaders, delay requests
const sleep = (delay: number) => { 
	return new Promise((resolve) => { 
		setTimeout(resolve, delay); 
	});
 }

// axios.defaults.baseURL = process.env.REACT_APP_API_URL;

axios.defaults.baseURL = 'http://localhost:5188/api';

// aply delay
axios.interceptors.response.use(async (response) => {
	try {
		if (process.env.NODE_ENV == 'development') await sleep(1000);
		return response;
	} catch (error) {		
		console.log(error);
		return await Promise.reject(error);
	}
});

const responseBody = <T> (response: AxiosResponse<T>) => response.data;

const requests = {
	get: <T>(url: string) => axios.get<T>(url).then(responseBody),
	post: <T>(url: string, body: {}) => axios.post<T>(url, body).then(responseBody),
	put: <T>(url: string, body: {}) => axios.put<T>(url, body).then(responseBody),
	patch: <T>(url: string, body: {}) => axios.patch<T>(url, body).then(responseBody),
	delete: <T>(url: string) => axios.delete<T>(url).then(responseBody)
}

const planets = {
	//list: (params: URLSearchParams) => axios.get<PaginatedResult<Planet[]>>("/planet", {params: params}).then(responseBody),
	list: (params: URLSearchParams) => axios.get<Planet[]>("/planet", {params: params}).then(responseBody),
	details: (id: string) => requests.get<Planet>(`/planet/${id}`),
	create: (planet: PlanetFormValues) => requests.post<void>('/planet', planet),
	update: (planet: PlanetFormValues) => requests.put<void>(`/planet/${planet.id}`, planet),
	delete: (id: string) => requests.delete<void>(`/planet/${id}`)
}

const agent = {
	planets
}

export default agent;