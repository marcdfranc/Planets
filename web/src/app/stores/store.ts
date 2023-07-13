import { createContext, useContext } from "react";
import PlanetStore from "./PlanetStore";

interface Store {
	planetStore : PlanetStore
}

export const store: Store = {
	planetStore: new PlanetStore()
}

export const StoreContext = createContext(store);

export const useStore = () => { 
	return useContext(StoreContext); 
}