import { makeAutoObservable, observable } from "mobx";

export default class PlanetStore {
	title = "Hello world Mobx!!!";
	
	constructor() {
		makeAutoObservable(this, {
			title: observable
		});
	}
}