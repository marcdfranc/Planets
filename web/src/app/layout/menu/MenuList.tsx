import React from 'react'
import { MenuAttributes } from '../../models/MenuAttributes'
import { NavigationMenuItem } from './NavigationMenuItem'
import { observer } from 'mobx-react-lite'
import { useStore } from '../../stores/store'


const MenuList = () => {
	const {planetStore: {planets}} = useStore()

	console.log(planets);
	
	return (
		<div className='MenuListings'>
			<ul className='Circle'>
				{planets.map((planet, index) => (				
					<NavigationMenuItem key={planet.id} planet={planet} insertEmpty={index == 1} />				
				))}
			</ul>
		</div>
	)
}

export default observer(MenuList);
