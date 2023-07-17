import React, { useEffect } from 'react'
import { Button, Icon, Segment, Menu } from 'semantic-ui-react'
import { MenuToogle } from './MenuToogle'
import { MenuAttributes, MenuAttributesValues } from '../../models/MenuAttributes'
import { NavigationArrow } from './NavigationArrow'

import MenuList from './MenuList'

const Navigation = () => {
	
	return (
		<>
			<section className='Menu MenuCircle'>
				<input id='MenuActive' type='checkbox' ></input>
				<label htmlFor='MenuActive' className='MenuActive'>
					<MenuToogle />
					<MenuList />
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

export default Navigation;