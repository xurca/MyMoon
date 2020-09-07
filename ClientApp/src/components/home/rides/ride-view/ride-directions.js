import React from 'react';
import FlexBox from '../../../shared/flex-box';
import Typography from '@material-ui/core/Typography';
import { TrendingFlat } from '@material-ui/icons';

const RideDirections = () => (
  <>
    <FlexBox alignItems='center'>
      <Typography variant='h6'>
        გორი
      </Typography>
      <TrendingFlat style={{ margin: '0 5px' }}/>
      <Typography variant='h6'>
        ხაშური
      </Typography>
    </FlexBox>
    <Typography variant='subtitle2' color='textSecondary'>
      ორშაბათი, 17 აგვისტო 2020, 18:00 საათი
    </Typography>
  </>
);

export default RideDirections;
