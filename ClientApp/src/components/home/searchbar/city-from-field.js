import React from 'react';
import FlightTakeoff from '@material-ui/icons/FlightTakeoff';
import CitiesField from '../../shared/form-elements/cities-field';

export const CityFromField = ({ value, name, onChange }) => (
  <CitiesField
    value={value}
    onChange={onChange}
    name={name}
    label='საიდან'
    startIcon={<FlightTakeoff color='primary'/>}
  />
);

