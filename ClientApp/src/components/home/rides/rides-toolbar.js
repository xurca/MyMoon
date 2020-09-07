import React from 'react'
import Typography from '@material-ui/core/Typography'
import CenteredBox from '../../shared/centered-box';
import FlexBox from '../../shared/flex-box';
import CreateRideAlert from '../create-ride-alert';

const RidesToolbar = () => {
  return (
    <CenteredBox justifyContent='space-between'>
      <FlexBox alignItems='flex-end'>
        <Typography variant='h6' style={{ marginRight: 8, paddingLeft: 6 }}>
          მიმდინარე მარშრუტები
        </Typography>
        <sub>150+ შედეგი</sub>
      </FlexBox>
      <CreateRideAlert/>
    </CenteredBox>
  )
}

export default RidesToolbar
