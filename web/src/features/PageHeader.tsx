import { observer } from 'mobx-react-lite';
import React from 'react'
import {Header, Image, Segment } from 'semantic-ui-react'
import { useStore } from '../app/stores/store';


interface Props {
	mobile: boolean
	headerContent: string;
	subHeaderContent?: string;
	imgUrl?: string;
}

const PageHeader = ({ mobile, imgUrl }: Props) => {
	const {pageHeaderStore : {attributes}} = useStore();

	return (
		<Segment className='PageHeader' stacked >
			<Header
				as='h1'
				content={attributes?.content}
				inverted
				style={{
					fontSize: mobile ? '2em' : '4em',
					fontWeight: 'normal',
					marginBottom: 0,
					marginTop: '1.5em' // mobile ? '1.5em' : '3em',
				}}
			/>

			{attributes?.subContent ? (<>
				<Header
					as='h2'
					content={attributes.subContent}
					inverted
					style={{
						fontSize: mobile ? '1.5em' : '1.7em',
						fontWeight: 'normal',
						marginTop: mobile ? '0.5em' : '1.5em',
					}}
				/>
			</>) : null}

			{imgUrl ? (<Image
				src={imgUrl}
				floated='right'
			/>) : null}
		</Segment>
	)
}

export default observer(PageHeader);