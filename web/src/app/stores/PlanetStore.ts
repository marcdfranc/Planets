import { makeAutoObservable, runInAction } from "mobx";
import { Planet } from "../models/Planet";
import agent from "../services/agent";

export default class PlanetStore {
	planets: Planet[] = [];
	planetRegistry = new Map<string, Planet>();	
	selectedPlanet: Planet | undefined = undefined;
	loadingScreen = false;

	constructor() {
		makeAutoObservable(this);
	}

	get axiosParams() {
		const params = new URLSearchParams();
		params.append('pageNumber', '1');
		params.append('pageSize', '10');
		return params;
	}

	loadPlanets = async (id?: string) => {
		if (this.planets.length == 0) {
			this.loadingScreen = true;

			try {
				const result = await agent.planets.list(this.axiosParams);

				runInAction(() => {
					this.planets = result;
					result.forEach(planet => {
						if (planet.id === id) {
							this.selectedPlanet = planet;
						}
						this.setPlanet(planet);
					});
				});

			} catch (error) {
				console.log(error);
			} finally {
				this.setLoadingScreem(false);
			}
		}
	}

	loadPlanet = async (id: string) => {
		let planet = this.getPlanet(id);
		if (planet) {
			this.selectedPlanet = planet;			
		}
	};

	setLoadingScreem = (state: boolean) => {
		this.loadingScreen = state;
	}

	clearSelectedPlanet = () => {
		this.selectedPlanet = undefined;
	}

	private getPlanet = (id: string) => {
		return this.planetRegistry.get(id);
	}

	private setPlanet = (planet: Planet) => {
		this.planetRegistry.set(planet.id, planet);
	}

}