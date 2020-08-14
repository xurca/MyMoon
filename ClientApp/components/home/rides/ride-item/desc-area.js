import React from 'react'
import Box from '@material-ui/core/Box'
import Typography from '@material-ui/core/Typography'
import RideInfoItems from './ride-info-items';

const DescArea = () => (
  <Box p={2} position='relative'>
    <Typography variant='h6' gutterBottom>
      Today at 12:30
    </Typography>
    <Typography variant='subtitle1'>
      Kutaisi
    </Typography>
    <RideInfoItems/>
  </Box>
)

export default DescArea
