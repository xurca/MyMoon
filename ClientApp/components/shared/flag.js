import React from 'react';

const Flag = ({ countryCode, width, ...rest }) => (
  <img
    src={`/assets/flags/${countryCode}.svg`} alt={`${countryCode} flag`}
    style={{
      width,
    }}
    {...rest}
  />
);

export default Flag;
