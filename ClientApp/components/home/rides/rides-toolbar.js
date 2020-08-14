import React from 'react'
import Typography from '@material-ui/core/Typography'
import CenteredBox from '../../shared/centered-box';
import FlexBox from '../../shared/flex-box';
import CreateRideAlert from '../create-ride-alert';

const RidesToolbar = () => {
  return (
    <CenteredBox justifyContent='space-between'>
      <FlexBox alignItems='flex-end'>
        <Typography variant='h5' style={{ marginRight: 8 }}>
          Upcoming Rides
        </Typography>
        <sub>150+ results</sub>
      </FlexBox>
      <CreateRideAlert/>
    </CenteredBox>
  )
}

export default RidesToolbar
