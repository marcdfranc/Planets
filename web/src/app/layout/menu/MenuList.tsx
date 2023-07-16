import React from 'react'
import { MenuAttributes } from '../../models/MenuAttributes'
import { NavigationMenuItem } from './NavigationMenuItem'

interface Props {
	itemAttributes: MenuAttributes[]
}

export const MenuList = ({itemAttributes} : Props) => {
	return (
		<div className='MenuListings'>
			<ul className='Circle'>
				{itemAttributes.map((item: MenuAttributes, index: number) => (
					<li key={`${item.name}-${index}`}>
						<NavigationMenuItem attributes={item} />						
					</li>
				))}
			</ul>
		</div>
	)
}
