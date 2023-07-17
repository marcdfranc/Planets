import React from 'react'
import { Link } from 'react-router-dom'
import { Button, Header, Icon, Segment } from 'semantic-ui-react'

export const NotFound = () => {
  return (
	<Segment placeholder>
		<Header icon>
			<Icon name='search' />
			Oo's - We've looked everywhere and could not find this.
		</Header>
		<Segment.Inline>
			<Button as={Link} to='/' primary>
				Return to Planet APP
			</Button>
		</Segment.Inline>
	</Segment>
  )
}
