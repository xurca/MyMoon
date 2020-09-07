import React from 'react';
import Rating from '@material-ui/lab/Rating';

const DriverRating = ({ rating }) => (
  <Rating value={rating} size='small' readOnly/>
);

export default DriverRating;
