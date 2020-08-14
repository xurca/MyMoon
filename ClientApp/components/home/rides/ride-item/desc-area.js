import React from 'react'
import Box from '@material-ui/core/Box'
import Typography from '@material-ui/core/Typography'
import RideInfoItems from './ride-info-items';

const DescArea = () => (
  <Box p={2} position='relative'>
    <Typography variant='subtitle2' gutterBottom>
      დღეს 12:30
    </Typography>
    <Typography variant='subtitle1'>
      ქუთაისი
    </Typography>
    <RideInfoItems/>
  </Box>
)

export default DescArea
