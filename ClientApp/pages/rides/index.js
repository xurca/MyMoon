import React from 'react';
import Hidden from '@material-ui/core/Hidden';
import Searchbar from '../../components/home/searchbar';
import { ContentContainer } from '../../components/shared/content-container';
import Grid from '@material-ui/core/Grid';
import RidesToolbar from '../../components/home/rides/rides-toolbar';
import RideItem from '../../components/home/rides/ride-item/ride-item';
import { useMediaQuery } from '@material-ui/core';
import useTheme from '@material-ui/core/styles/useTheme';
import Toolbar from '@material-ui/core/Toolbar';
import Paper from '@material-ui/core/Paper';
import FlexBox from '../../components/shared/flex-box';
import Typography from '@material-ui/core/Typography';
import FiltersModal from '../../components/home/rides/filters-modal';
import FiltersForm from '../../components/home/rides/filters-form';
import RideItemResponsive from '../../components/home/rides/ride-item/ride-item-responsive';

export default function Rides() {
  const theme = useTheme();
  const matches = useMediaQuery(theme.breakpoints.down('sm'));

  return (
    <div>
      <Searchbar/>
      <ContentContainer maxWidth='lg'>
        <Grid container spacing={2}>
          <Hidden smDown>
            <Grid item md={3}>
              <FiltersForm/>
            </Grid>
          </Hidden>
          <Grid item xs={12} md={9} style={matches ? { paddingTop: 0 } : {}}>
            <Hidden smDown>
              <RidesToolbar/>
              <RideItem/>
              <RideItem/>
              <RideItem/>
            </Hidden>
            <Hidden mdUp>
              <RideItemResponsive
                rideDate='Today'
                rideTime='10:33'
                settings='settings'
                description='description'
                bookedSeats='bookedSeats'
                plateNumber='ANZ-224'
                driver='გელა'
              />
              <RideItemResponsive/>
              <RideItemResponsive/>
            </Hidden>
          </Grid>
        </Grid>
      </ContentContainer>
      <Hidden mdUp>
        <Paper variant='outlined' square style={{ position: 'fixed', bottom: 0, left: 0, right: 0 }}>
          <Toolbar>
            <FlexBox justifyContent='space-between' alignItems='center' width='100%'>
              <Typography variant='body2'>
                150+ შედეგი
              </Typography>
              <FiltersModal/>
            </FlexBox>
          </Toolbar>
        </Paper>
      </Hidden>
    </div>
  );
}
