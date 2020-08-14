import React from 'react';
import Hidden from '@material-ui/core/Hidden';
import Searchbar from '../../components/home/searchbar';
import { ContentContainer } from '../../components/shared/content-container';
import Grid from '@material-ui/core/Grid';
import Filters from '../../components/home/filters';
import RidesToolbar from '../../components/home/rides/rides-toolbar';
import RideItem from '../../components/home/rides/ride-item/ride-item';
import { useMediaQuery } from '@material-ui/core';
import useTheme from '@material-ui/core/styles/useTheme';

export default function Rides() {
  const theme = useTheme()
  const matches = useMediaQuery(theme.breakpoints.down('sm'))
  console.log(matches)
  return (
    <div>
      <Searchbar/>
      <ContentContainer maxWidth='lg'>
        <Grid container spacing={2}>
          <Hidden smDown>
            <Grid item md={3}>
              <Filters/>
            </Grid>
          </Hidden>
          <Grid item xs={12} md={9} style={matches ? {paddingTop: 0} : {}}>
            <Hidden smDown>
              <RidesToolbar/>
            </Hidden>
            <RideItem/>
            <RideItem/>
            <RideItem/>
          </Grid>
        </Grid>
      </ContentContainer>
    </div>
  );
}
