import React, { useEffect, useState } from 'react';
import '../../App.css';
import { Planet } from '../models/Planet';
import agent from '../services/agent';
import { Media, MediaContextProvider } from '../models/Common';
import { Segment } from 'semantic-ui-react';
import { Navigation } from './menu/Navigation';
import { ImageDisplay } from './ImageDisplay';
import PageHeader from '../../features/PageHeader';
import Home from '../../features/Home';

const App = () => {
	const [planets, setPlanets] = useState<Planet[]>([]);

	const headerContent = 'Solar system';
	const subHeaderContent =  'Characteristics of its planets.';
	const imgUrl = ''; // '/images/planets/mercury.png';

	useEffect(() => {
		const params = new URLSearchParams();
		params.append('pageNumber', '1');
		params.append('pageSize', '4');

		agent.planets.list(params).then(response => {
			let planets: Planet[] = [];		

			// console.log(response);

			response.forEach(planet => {
				planets.push(planet);
			});

			setPlanets(planets);		
		});
	}, [])


	return (
		<MediaContextProvider>
			<Media greaterThan='mobile'>
				<Segment
					inverted
					textAlign='center'
					style={{padding:'5px 0', marginTop: -15}}
					vertical
				>
					<Navigation />	
					<PageHeader
						mobile={false}
						headerContent={headerContent}
						subHeaderContent={subHeaderContent}
					/>
				</Segment>
			 
				<Home mobile={false} />				
			</Media>
			<Media lessThan='desktop'>
				<h1>Mobile Version</h1>
			</Media> 
		</MediaContextProvider>
	);
}

export default App;
