import { SemanticSIZES } from "semantic-ui-react";

export interface Planet {
	id: string;
	name: string;
	decimalDistanceFromTheSun: number;
	distanceFromTheSun: string;
	decimalMass: number;
	mass: string;
	diameter: number;
	notes: string;
	imagePath: string;
	imageIconPath: string;
	position: number;
	circular: boolean;
}

export class Planet implements Planet {
	constructor(init: PlanetFormValues) {
		Object.assign(this, init);		
	}
}

export class PlanetFormValues {
	id?: string = undefined;
	name: string = '';
	decimalDistanceFromTheSun: number | null = null;
	distanceFromTheSun: string = '';
	decimalMass: number | null = null;
	mass: string = '';
	diameter: number | null = null;
	notes: string = '';
	imagePath: string = '';
	imageIconPath: string = '';
	position: number | null = null;
	circular: boolean = false;	

	constructor(planet?: PlanetFormValues) {
		if (planet) {
			this.id = planet.id;
			this.name = planet.name;
			this.decimalDistanceFromTheSun = planet.decimalDistanceFromTheSun;
			this.distanceFromTheSun = planet.distanceFromTheSun;
			this.decimalMass = planet.decimalMass;
			this.mass = planet.mass;
			this.diameter = planet.diameter;
			this.notes = planet.notes;
			this.imagePath = planet.imagePath;
			this.imageIconPath = planet.imageIconPath;
			this.position = planet.position;
			this.circular = planet.circular;
		}
	}
}