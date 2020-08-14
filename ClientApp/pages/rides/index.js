import React from 'react';
import Hidden from '@material-ui/core/Hidden';
import Searchbar from '../../components/home/searchbar';
import { ContentContainer } from '../../components/shared/content-container';
import Grid from '@material-ui/core/Grid';
import Filters from '../../components/home/filters';
import RidesToolbar from '../../components/home/rides/rides-toolbar';

export default function Rides() {
  return (
    <div>
      <Searchbar/>
      <ContentContainer maxWidth='lg'>
        <Grid container spacing={2}>
          <Hidden smDown>
            <Grid item xs={3}>
              <Filters/>
            </Grid>
          </Hidden>
          <Grid item xs={12} md={9}>
            <RidesToolbar/>
            {/*<Rides/>*/}
          </Grid>
        </Grid>
      </ContentContainer>
    </div>
  );
}
