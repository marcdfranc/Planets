import { SemanticSIZES } from "semantic-ui-react";

export interface MenuAttributes {
	name: string;
	icon: string;
	circular: boolean;
	size: SemanticSIZES;
}

export class MenuAttributes implements MenuAttributes {	
	constructor(init: MenuAttributesValues) {
		Object.assign(this, init);		
	}
}

export class MenuAttributesValues {
	name: string = '';
	icon: string = '';
	circular: boolean = true;
	size: SemanticSIZES = 'tiny';
	
	constructor(menuAttributes? : MenuAttributesValues) {
		if (menuAttributes) {
			this.name = menuAttributes.name;
			this.icon = menuAttributes.icon;
		}		
	}
} 
