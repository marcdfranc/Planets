import { createContext, useContext } from "react";
import PlanetStore from "./PlanetStore";
import { MenuAttributes } from "../models/MenuAttributes";
import { PageHeaderAttributes } from "../models/PageHeaderAttributes";
import PageHeaderStore from "./PageHeaderStore";

interface Store {
	planetStore : PlanetStore;
	// menuAttributes: MenuAttributes;
	pageHeaderStore: PageHeaderStore;
}

export const store: Store = {
	planetStore: new PlanetStore(),
	pageHeaderStore: new PageHeaderStore() 
}

export const StoreContext = createContext(store);

export const useStore = () => { 
	return useContext(StoreContext); 
}