import { useEffect } from 'react';
import '../../App.css';
import { Media, MediaContextProvider } from '../models/Common';
import { Container, Segment } from 'semantic-ui-react';
import PageHeader from '../../features/PageHeader';
import { Outlet } from 'react-router-dom';
import { useStore } from '../stores/store';
import { observer } from 'mobx-react-lite';
import Navigation from './menu/Navigation';

const App = () => {	
	const {planetStore: {planetRegistry, loadPlanets}} = useStore();
	
	useEffect(() => {
		if (planetRegistry.size == 0) {
			loadPlanets(); 
		}
	}, [planetRegistry, loadPlanets])	

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
					/>
				</Segment>
			</Media>
			<Container>				
				<Outlet />
			</Container>
			<Media lessThan='desktop'>
				<h1>TO DO - Mobile Version</h1>
			</Media> 
		</MediaContextProvider>
	);
}

export default observer(App);
