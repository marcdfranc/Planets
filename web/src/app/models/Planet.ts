export interface Planet {
	id: string;
	name: string;
	distanceFromTheSun: number;
	mass: number;
	diameter: number;
	notes: string;
}

export class Planet implements Planet {
	constructor(init: PlanetFormValues) {
		Object.assign(this, init);		
	}
}

export class PlanetFormValues {
	id?: string = undefined;
	name: string = '';
	distanceFromTheSun: number | null = null;
	mass:  number | null = null;
	diameter:  number | null = null;
	notes: string = '';

	constructor(planet?: PlanetFormValues) {
		if (planet) {
			this.id = planet.id;
			this.name = planet.name;
			this.distanceFromTheSun = planet.distanceFromTheSun;
			this.mass = planet.mass;
			this.diameter = planet.diameter;
			this.notes = planet.notes;
		}
	}
}