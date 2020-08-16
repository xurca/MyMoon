import React from 'react';
import * as S from './styles';
import FlexBox from '../../../shared/flex-box';
import Divider from '@material-ui/core/Divider';
import Box from '@material-ui/core/Box';
import DriverInfoMobile from './driver-info-mobile';
import RideInfo from './ride-info';
import DriverPlateNumber from './driver-plate-number';
import RideSeats from './ride-seats';
import RideDesc from './ride-desc';

const RideItemResponsive = ({
  rideDate,
  rideTime,
  settings,
  description,
  bookedSeats,
  plateNumber,
  driver
}) => (
  <S.RideItemResponsive>
    <FlexBox flexDirection='column' width='100%'>
      <FlexBox pl={1.5} justifyContent='space-between' alignItems='center'>
        <span>{rideDate} {rideTime}</span>
        <RideInfo infoItems={['notRequireAcceptance', 'onlyTwoPassengers']}/>
      </FlexBox>
      <Box px={1.5}>
        <RideDesc/>
      </Box>
      <FlexBox px={1.5} pt={1} width='100%' justifyContent='space-between'>
        <RideSeats booked={1} free={2}/>
        <DriverPlateNumber plateNumber={plateNumber}/>
      </FlexBox>
      <FlexBox px={1.5} py={1}>
        <DriverInfoMobile/>
      </FlexBox>
    </FlexBox>
  </S.RideItemResponsive>
);

export default RideItemResponsive;
