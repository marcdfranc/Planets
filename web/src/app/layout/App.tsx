import React, { useEffect, useState } from 'react';
import logo from '../../logo.svg';
import '../../App.css';
import { Planet } from '../models/Planet';
import agent from '../services/agent';

function App() {
	const [planets, setPlanets] = useState<Planet[]>([]);

	useEffect(() => {
		const params = new URLSearchParams();
		params.append('pageNumber', '1');
		params.append('pageSize', '4');

		agent.planets.list(params).then(response => {
			let planets: Planet[] = [];		

			console.log(response);

			response.forEach(planet => {
				planets.push(planet);
			});

			setPlanets(planets);		
		});
	}, [])


	return (
		<div className="App">
			<ul>
				{planets.map((planet: Planet) => ( <li key={planet.id}>{planet.name}</li>))}
			</ul>
			<header className="App-header">
				<img src={logo} className="App-logo" alt="logo" />
				<p>
					Edit <code>src/App.tsx</code> and save to reload.
				</p>
				<a
					className="App-link"
					href="https://reactjs.org"
					target="_blank"
					rel="noopener noreferrer"
				>
					Learn React
				</a>
			</header>
		</div>
	);
}

export default App;
