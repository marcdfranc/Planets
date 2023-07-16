import React, { useEffect } from 'react'
import { Button, Icon, Segment, Menu } from 'semantic-ui-react'
import { MenuToogle } from './MenuToogle'
import { MenuAttributes, MenuAttributesValues } from '../../models/MenuAttributes'
import { MenuList } from './MenuList'
import { NavigationArrow } from './NavigationArrow'

export const Navigation = () => {
	const menuItems: MenuAttributes[] = [];
	
	const venus = new MenuAttributesValues();
	venus.icon = "venus.png";
	venus.name = "Venus";
	menuItems.push(venus);
	
	const mercury = new MenuAttributesValues();
	mercury.icon = "mercury.png";
	mercury.name = "Mercury";
	menuItems.push(mercury);

	menuItems.push(new MenuAttributes(new MenuAttributesValues()));	

	const pluto = new MenuAttributesValues();
	pluto.icon = "pluto.png";
	pluto.name = "pluto";
	menuItems.push(pluto);	
	
	const neptune = new MenuAttributesValues();
	neptune.icon = "neptune.png";
	neptune.name = "Neptune";
	menuItems.push(neptune);
	
	const uranus = new MenuAttributesValues();
	uranus.icon = "uranus.png";
	uranus.name = "Uranus";
	menuItems.push(uranus);
	
	const saturn = new MenuAttributesValues();
	saturn.icon = "saturn.png";
	saturn.name = "Saturn";
	saturn.circular = false;
	saturn.size = 'small';
	menuItems.push(saturn);

	const jupiter = new MenuAttributesValues();
	jupiter.icon = "jupiter.png";
	jupiter.name = "Jupiter";
	menuItems.push(jupiter);		
	
	const mars = new MenuAttributesValues();
	mars.icon = "mars.png";
	mars.name = "Mars";
	menuItems.push(mars);
	
	const earth = new MenuAttributesValues();
	earth.icon = "earth.png";
	earth.name = "Earth";
	menuItems.push(earth);	
	

	console.log(menuItems);	

	return (
		<>
			<section className='Menu MenuCircle'>
				<input id='MenuActive' type='checkbox' ></input>
				<label htmlFor='MenuActive' className='MenuActive'>
					<MenuToogle />
					<MenuList itemAttributes={menuItems} />
					<NavigationArrow />				
				</label>
			</section>
			<Segment stacked className='BtnHome'>
				<Button primary size='huge' floated='right' >
					Home
					<Icon className='right' name='home'  />
				</Button>
			</Segment>
		</>
	)
}
