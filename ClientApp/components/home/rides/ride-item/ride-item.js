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

const RideInfoWrapper = styled('div')({
  position: 'absolute',
  top: 0,
  right: 0
});

const RideItem = ({ onClick }) => {
  return (
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
  );
};

export default RideItem;
