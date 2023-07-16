import React from 'react'
import { MenuAttributes } from '../../models/MenuAttributes'
import { Image, SemanticSIZES } from 'semantic-ui-react';

interface Props {
	attributes?: MenuAttributes
}

export const NavigationMenuItem = ({attributes}: Props) => {
	const iconsPath = '/images/planet-icons';

	if (attributes?.name) {
		return (
			<div className='Placeholder'>
				<div className='Upside'>
					<a href='#' className='Button' target='_blank'>
						<Image 
							src={`${iconsPath}/${attributes.icon}`} 
							centered 
							size={attributes.size} 
							circular={attributes.circular} />
						<span>{attributes.name}</span>
					</a>
				</div>
			</div>
		);
	}
	else
	{
		return (<div className='Placeholder'>
				<div className='Upside'>
					<a href='#' />
				</div>
			</div>
		);
	}
}
