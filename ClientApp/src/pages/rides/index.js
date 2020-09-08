import React from 'react';
import { ContentContainer } from '../../components/shared/content-container';
import Grid from '@material-ui/core/Grid';
import { useMediaQuery } from '@material-ui/core';
import useTheme from '@material-ui/core/styles/useTheme';
import Hidden from '@material-ui/core/Hidden';
import FiltersForm from '../../components/home/rides/filters-form';
import Box from '@material-ui/core/Box';
import Paper from '@material-ui/core/Paper';
import Toolbar from '@material-ui/core/Toolbar';
import FlexBox from '../../components/shared/flex-box';
import Typography from '@material-ui/core/Typography';
import FiltersModal from '../../components/home/rides/filters-modal';
import Searchbar from '../../components/home/searchbar';
import RidesList from '../../components/home/rides/rides-list';

export default function Rides() {
  const theme = useTheme();
  const matches = useMediaQuery(theme.breakpoints.down('sm'));
  /*const router = useRouter()

  const handleRideClick = (rideId) => {
    router.push(
      '/rides/[id]',
      `/rides/${rideId}`
    );
  }*/

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
            <RidesList/>
          </Grid>
        </Grid>
      </ContentContainer>
      <Hidden mdUp>
        <Box height={66}/>
        <Paper
          variant='outlined'
          square
          style={{
            position: 'fixed',
            bottom: 0,
            left: 0,
            right: 0,
          }}
        >
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
