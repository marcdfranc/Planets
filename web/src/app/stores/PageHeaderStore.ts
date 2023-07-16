import { makeAutoObservable } from "mobx";
import { PageHeaderAttributes, PageHeaderAttributesValues } from "../models/PageHeaderAttributes";
import { store } from "./store";

export default class PageHeaderStore {
	attributes : PageHeaderAttributes | null = null;

	constructor() {
		makeAutoObservable(this);
	}

	setHeader = (attrs : PageHeaderAttributesValues) => { 
		if (attrs) this.attributes = new PageHeaderAttributes(attrs);	
	}
}