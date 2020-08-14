import React from 'react';
import * as S from './styles';
import { SwapCitiesButton } from './swap-cities-button';
import { CityFromField } from './city-from-field';
import { CityToField } from './city-to-field';

const PlacesRangeFields = ({
  values,
  onChange,
  setFieldValue,
}) => {

  const handleExchange = () => {
    setFieldValue('to', values.from);
    setFieldValue('from', values.to);
  };

  return (
    <S.CitiesRangeWrapper>
      <CityFromField/>
      <SwapCitiesButton onClick={handleExchange}/>
      <CityToField/>
    </S.CitiesRangeWrapper>
  );
};

export default PlacesRangeFields;
