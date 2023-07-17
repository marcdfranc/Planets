import { observer } from 'mobx-react-lite'
import React, { useEffect } from 'react'
import { useNavigate, useParams } from 'react-router-dom'
import { useStore } from '../app/stores/store'
import { PageHeaderAttributesValues } from '../app/models/PageHeaderAttributes'
import LoadingComponent from '../app/layout/LoadingComponent'
import { Grid, Header, Segment, Image, Button, Container, List, Label } from 'semantic-ui-react'

const PlanetDetail = () => {
	const { planetStore: { loadPlanet, selectedPlanet, clearSelectedPlanet, loadingScreen, planetRegistry }, pageHeaderStore: { setHeader } } = useStore();
	const { id } = useParams<{ id: string }>();

	useEffect(() => {

		if (id) {
			loadPlanet(id);
		}

		if (!loadingScreen && selectedPlanet) {			
			const attr = new PageHeaderAttributesValues();
			attr.content = selectedPlanet.name;
			attr.imgUrl = selectedPlanet.imagePath;
			setHeader(attr);
		}

		return () => clearSelectedPlanet();
	}, [setHeader, id, loadPlanet, clearSelectedPlanet, selectedPlanet, loadingScreen, planetRegistry])

	if (loadingScreen || !selectedPlanet) return <LoadingComponent content='Loading Planet...' />


	return (
		<Segment style={{ padding: '8em 0em' }} vertical>
			<Grid container stackable verticalAlign='middle'>
				<Grid.Row>
					<Grid.Column floated='left' width={6}>
						<Image bordered rounded size='large' src={selectedPlanet.imagePath} />
					</Grid.Column>
					<Grid.Column width={8}>
						<Header as='h3' style={{ fontSize: '2em' }}>
							Physical characteristics
						</Header>
						<Container>
							<List>								
								<List.Item>
									<List.Header>Diameter</List.Header>
									<Label style={{margin: '10px 0 5px 0'}}  basic color='blue' size='small'>kilometers</Label>
									<span style={{marginLeft: 12,  fontSize: '1.33em'}}>{selectedPlanet.diameter}</span>
								</List.Item>	
								<List.Item>
									<List.Header>Mass</List.Header>
									<Label style={{margin: '10px 0 5px 0'}}  basic color='orange' size='small'>kilograms</Label>
									<span style={{marginLeft: 12,  fontSize: '1.33em'}}>{selectedPlanet.mass}</span>
								</List.Item>
								<List.Item>
									<List.Header >Distance from the sun</List.Header>
									<Label style={{margin: '10px 0 5px 0'}} basic color='blue' size='small'>kilometers</Label>
									<span style={{marginLeft: 12,  fontSize: '1.33em'}}>{selectedPlanet.distanceFromTheSun}</span>
								</List.Item>							
							</List>
						</Container>

						<p style={{ fontSize: '1.33em' }}> </p>

						{selectedPlanet.notes && (
							<>
								<Header as='h3' style={{ fontSize: '2em' }}>
									Important Notes
								</Header>
								<p style={{ fontSize: '1.33em' }}>{selectedPlanet.notes}</p>
							</>
						)}
					</Grid.Column>

				</Grid.Row>
			</Grid>
		</Segment>
	)
}

export default observer(PlanetDetail);