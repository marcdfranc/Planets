import React from 'react'
import { Header, Image, Segment } from 'semantic-ui-react'

interface Props {
	mobile: boolean;
	imgUrl: string;
}

export const ImageDisplay = ({mobile, imgUrl} : Props) => {
  const imageTest = '/images/planets/mercury.png';

  return (
	<Segment className='ImageDisplay' stacked >
		<Header
			as='h3'
			content="Mercury"
			inverted
			style={{
				fontSize: mobile ? '2em' : '4em',
				fontWeight: 'normal',
				marginBottom: 0			
			}}
		/>
		<Image 
			src={imgUrl}
			floated='right'
		/>
	</Segment>
  )
}
