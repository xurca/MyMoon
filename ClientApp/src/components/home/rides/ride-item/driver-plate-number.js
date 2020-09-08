import React from 'react';
import Typography from '@material-ui/core/Typography';

const DriverPlateNumber = ({ plateNumber }) => (
  <Typography variant='subtitle2'>
    {plateNumber}
  </Typography>
);

export default DriverPlateNumber;
