import React from 'react';
import { CityFromField } from './city-from-field';
import { CityToField } from './city-to-field';
import Box from '@material-ui/core/Box';
import DateField from '../../shared/form-elements/date-field';
import TimeField from '../../shared/form-elements/time-field';
import { SubmitButton } from './submit-button';
import FlexBox from '../../shared/flex-box';

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
    <FlexBox mt={2}>
      <DateField
        name='date'
        value={values.date}
        onChange={setFieldValue}
        style={{ marginRight: 8 }}
      />
      <TimeField
        name='time'
        value={values.date}
        onChange={setFieldValue}
        style={{ marginRight: 4 }}
      />
    </FlexBox>
    <FlexBox my={2} justifyContent='flex-end'>
      <SubmitButton
        type='submit'
        style={{ margin: 0 }}
      />
    </FlexBox>
  </div>
);

