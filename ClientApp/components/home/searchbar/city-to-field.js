import React from 'react';
import CitiesField from '../../shared/form-elements/cities-field';
import { FlightLand } from '@material-ui/icons';

export const CityToField = ({ value, name, onChange }) => (
  <CitiesField
    value={value}
    onChange={onChange}
    name={name}
    label='სად'
    startIcon={<FlightLand color='primary'/>}
  />
);

