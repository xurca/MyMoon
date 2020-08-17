import React from 'react';
import styled from '@material-ui/core/styles/styled';
import DriverAvatar from './driver-avatar';
import DriverName from './driver-name';
import DriverRating from './driver-rating';
import Box from '@material-ui/core/Box';

const Wrapper = styled('div')({
  display: 'flex',
  alignItems: 'center',
  justifyContent: 'center',
  flexDirection: 'column',
  height: '100%',
});

const DriverInfo = () => (
  <Wrapper>
    <Box mb={0.5}>
      <DriverAvatar/>
    </Box>
    <DriverName/>
    <DriverRating/>
  </Wrapper>
);

export default DriverInfo;
