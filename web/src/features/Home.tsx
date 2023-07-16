import React, { useEffect } from 'react'
import { Button, Container, Header, Segment } from 'semantic-ui-react';
import { useStore } from '../app/stores/store';
import { PageHeaderAttributesValues } from '../app/models/PageHeaderAttributes';
import { observer } from 'mobx-react-lite';



const Home = () => {
	const {pageHeaderStore : {setHeader}} = useStore();
	const headerContent = 'Solar system';
	const subHeaderContent = 'Characteristics of its planets.';

	useEffect(() => {
		const attr = new PageHeaderAttributesValues();
		attr.content =  'Solar System';
		attr.subContent = 'Characteristics of its planets.';
		setHeader(attr);
	}, [setHeader])

	return (		
		<Segment style={{ padding: '4em 0em' }} vertical inverted={false}>
			<Container text>
				<Header as='h3' style={{ fontSize: '2em' }}>
					Presentation, the Sun is the star
				</Header>
				<p style={{ fontSize: '1.33em' }}>
					The Solar System is the gravitationally bound system of the Sun 
					and the objects that orbit it. 
					The largest of such objects are the eight planets, 
					in order from the Sun: 
					four terrestrial planets named Mercury, Venus, Earth and Mars, 
					two gas giants named Jupiter and Saturn, 
					and two ice giants named Uranus and Neptune. 
					The terrestrial planets have a definite surface and are mostly made 
					of rock and metal. 
					The gas giants are mostly made of hydrogen and helium, 
					while the ice giants are mostly made of 'volatile' substances such as water, 
					ammonia, and methane. 
					In some texts, these terrestrial and giant planets are called the 
					inner Solar System and outer Solar System planets respectively.
				</p>
				<Button as='a' href='https://en.wikipedia.org/wiki/Solar_System' size='large' target='_blank'>
					Read More
				</Button>					
			</Container>
		</Segment>		
	)
}

export default observer(Home);
