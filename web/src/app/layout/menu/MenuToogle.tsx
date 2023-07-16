import React from 'react'
import { Icon } from 'semantic-ui-react'

export const MenuToogle = () => {
	const sunImage = 'url(/images/menu-sun_500x500.png)';

	return (
		<>
			<div className='MenuToggle' style={ {backgroundImage: sunImage} }>
				<div className='MenuIcon'>
					<div className='MenuBars' />
				</div>
			</div>
			<input type='radio' name='arrowUp' id='DegreeUp0' />
			<input type='radio' name='arrowUp' id='DegreeUp1' />
			<input type='radio' name='arrowUp' id='DegreeUp2' />
		</>
	)
}
