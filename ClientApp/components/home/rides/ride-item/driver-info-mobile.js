import React from 'react';
import styled from '@material-ui/core/styles/styled';
import Box from '@material-ui/core/Box';
import DriverName from './driver-name';
import DriverRating from './driver-rating';
import DriverAvatar from './driver-avatar';

const Wrapper = styled('div')({
  display: 'flex',
  alignItems: 'center',
  justifyContent: 'center',
  height: '100%',
});

const DriverInfoMobile = () => (
  <Wrapper>
    <DriverAvatar size='small'/>
    <Box ml={1}>
      <DriverName/>
      <DriverRating/>
    </Box>
  </Wrapper>
);

export default DriverInfoMobile;
