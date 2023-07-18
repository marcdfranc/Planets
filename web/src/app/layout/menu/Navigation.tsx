import React from 'react'
import { Button, Icon, Segment } from 'semantic-ui-react'
import { MenuToogle } from './MenuToogle'
import { NavigationArrow } from './NavigationArrow'

import MenuList from './MenuList'
import { Link } from 'react-router-dom'

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
				<Button as={Link} to="/" primary size='huge' floated='right' >
					Home
					<Icon className='right' name='home'  />
				</Button>
			</Segment>
		</>
	)
}

export default Navigation;