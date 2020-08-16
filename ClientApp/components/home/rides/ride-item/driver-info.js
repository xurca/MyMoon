import React from 'react';
import styled from '@material-ui/core/styles/styled';
import DriverAvatar from './driver-avatar';
import DriverName from './driver-name';
import DriverRating from './driver-rating';

const Wrapper = styled('div')({
  display: 'flex',
  alignItems: 'center',
  justifyContent: 'center',
  flexDirection: 'column',
  height: '100%',
});

const DriverInfo = () => (
  <Wrapper>
    <DriverAvatar/>
    <DriverName/>
    <DriverRating/>
  </Wrapper>
);

export default DriverInfo;
