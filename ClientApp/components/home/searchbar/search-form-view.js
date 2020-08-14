import React from 'react';
import * as S from './styles';
import { SearchFormWrapper } from './styles';
import Box from '@material-ui/core/Box';
import DateField from '../../shared/form-elements/date-field';
import TimeField from '../../shared/form-elements/time-field';
import { SubmitButton } from './submit-button';
import { CityFromField } from './city-from-field';
import { SwapCitiesButton } from './swap-cities-button';
import { CityToField } from './city-to-field';

const SearchFormView = ({ setFieldValue, values }) => {

  const handleExchange = () => {
    setFieldValue('from', values.to)
    setFieldValue('to', values.from)
  }

  return (
    <SearchFormWrapper>
      <S.CitiesRangeWrapper>
        <CityFromField
          name='from'
          value={values.from}
          onChange={setFieldValue}
        />
        <SwapCitiesButton onClick={handleExchange}/>
        <CityToField
          name='to'
          value={values.to}
          onChange={setFieldValue}
        />
      </S.CitiesRangeWrapper>
      <Box width='50%' display='flex' alignItems='center'>
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
        <SubmitButton type='submit'/>
      </Box>
    </SearchFormWrapper>
  );
};

export default SearchFormView;
