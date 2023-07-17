import { Image, SemanticSIZES } from 'semantic-ui-react';
import { Planet } from '../../models/Planet';
import { Link } from 'react-router-dom';

interface Props {
	planet: Planet;
	insertEmpty: boolean;
}

export const NavigationMenuItem = ({planet, insertEmpty}: Props) => {
	
	const getPlanetSize = (circular: boolean) => {		
		const resultSize: SemanticSIZES = circular ? 'tiny' : 'small' 
		return resultSize;
	}

	return (
		<>
			<li>
				<div className='Placeholder'>
					<div className='Upside'>
						<Link to={`/planet/${planet.id}`} className='Button' >
							<Image 
								src={planet.imageIconPath} 
								centered 
								size={getPlanetSize(planet.circular)} 
								circular={planet.circular} />
							<span>{planet.name}</span>
						</Link>
					</div>
				</div>
			</li>
			{insertEmpty? (
				<li>
					<div className='Placeholder'>
						<div className='Upside'>
							<a href='#' />
						</div>
					</div>
				</li>
			): null}
		</>
	);
}
