import React from 'react';
import { CityFromField } from './city-from-field';
import { CityToField } from './city-to-field';
import Box from '@material-ui/core/Box';
import DateField from '../../shared/form-elements/date-field';
import TimeField from '../../shared/form-elements/time-field';
import { SubmitButton } from './submit-button';

export const SearchFormViewResponsive = ({ setFieldValue, values }) => (
  <div>
    <Box mt={2}>
      <CityFromField
        name='from'
        value={values.from}
        onChange={setFieldValue}
      />
    </Box>
    <Box mt={2}>
      <CityToField
        name='to'
        value={values.to}
        onChange={setFieldValue}
      />
    </Box>
    <Box mt={2}>
      <DateField
        name='date'
        value={values.date}
        onChange={setFieldValue}
        style={{ marginRight: 8 }}
      />
    </Box>
    <Box mt={2}>
      <TimeField
        name='time'
        value={values.date}
        onChange={setFieldValue}
        style={{ marginRight: 4 }}
      />
    </Box>
    <Box my={2}>
      <SubmitButton
        type='submit'
        style={{ margin: 0 }}
      />
    </Box>
  </div>
);

