import React from 'react';
import * as S from './styles';
import Grid from '@material-ui/core/Grid';
import DriverInfo from './driver-info';
import RideInfo from './ride-info';
import RideDesc from './ride-desc';
import Box from '@material-ui/core/Box';
import styled from '@material-ui/core/styles/styled';
import DriverPlateNumber from './driver-plate-number';
import RideSeats from './ride-seats';
import CenteredBox from '../../../shared/centered-box';
import FlexBox from '../../../shared/flex-box';
import Divider from '@material-ui/core/Divider';
import Hidden from '@material-ui/core/Hidden';
import DriverInfoMobile from './driver-info-mobile';

const RideInfoWrapper = styled('div')({
  position: 'absolute',
  top: 0,
  right: 0
});

const RideItem = ({
  rideDate,
  rideTime,
  settings,
  description,
  bookedSeats,
  plateNumber,
  driver,
  onClick
}) => {
  return (
    <>
      <Hidden smDown>
        <S.RideItem onClick={onClick}>
          <Grid xs={3} item style={{ borderRight: '1px solid #f1f1f1' }}>
            <DriverInfo/>
          </Grid>
          <Grid xs={7} item>
            <Box p={2} position='relative'>
              <RideDesc/>
              <RideInfoWrapper>
                <RideInfo
                  infoItems={['notRequireAcceptance', 'onlyTwoPassengers']}
                />
              </RideInfoWrapper>
            </Box>
          </Grid>
          <Grid xs={2} item style={{ borderLeft: '1px solid #f1f1f1' }}>
            <FlexBox flexDirection='column' height='100%'>
              <CenteredBox flex={1} style={{ borderBottom: '1px solid #f1f1f1' }}>
                <DriverPlateNumber plateNumber='ANZ224'/>
              </CenteredBox>
              <Divider/>
              <CenteredBox flex={1}>
                <RideSeats free={2} booked={2}/>
              </CenteredBox>
            </FlexBox>
          </Grid>
        </S.RideItem>
      </Hidden>
      <Hidden mdUp>
        <S.RideItemResponsive onClick={onClick}>
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
      </Hidden>
    </>
  );
};

export default RideItem;
