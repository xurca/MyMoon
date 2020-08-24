import React from 'react';
import { ContentContainer } from '../../../shared/content-container';
import RideDirections from './ride-directions';
import Box from '@material-ui/core/Box';
import RideDirectionsTimeline from './ride-directions-timeline';
import { Check, Place } from '@material-ui/icons';
import Button from '@material-ui/core/Button';
import DriverAvatar from '../ride-item/driver-avatar';
import DriverName from '../ride-item/driver-name';
import FlexBox from '../../../shared/flex-box';
import DriverRating from '../ride-item/driver-rating';
import Typography from '@material-ui/core/Typography';
import green from '@material-ui/core/colors/green';

const RideView = () => (
  <ContentContainer maxWidth='lg'>
    <RideDirections/>
    <Box mt={2} mb={1}>
      <RideDirectionsTimeline/>
    </Box>
    <Button
      variant='outlined'
      color='primary'
      startIcon={<Place/>}
    >
      მარშრუტის რუკაზე ნახვა
    </Button>
    <FlexBox py={2} mt={3}>
      <DriverAvatar size='large'/>
      <Box ml={3}>
        <DriverName/>
        <FlexBox mt={1}>
          <DriverRating rating={3}/>
          <Typography variant='subtitle2' color='textSecondary' style={{ marginLeft: 8}}>
            (4 შეფასება)
          </Typography>
        </FlexBox>
        <Box mt={1}>
          <Typography variant='body2' color='textSecondary' style={{display: 'flex', alignItems: 'center'}}>
            <Check style={{ color: green['A400'], marginRight: 8 }}/> ნომერი ვერიფიცირებული
          </Typography>
        </Box>
        <Box mt={3}>
          <Button
            variant='outlined'
            color='primary'
          >
            შეტყბოინების გაგზავნა
          </Button>
        </Box>
      </Box>
    </FlexBox>
    <Box mt={3}>
      <Typography variant='h6'>
        დეტალები
      </Typography>
    </Box>
  </ContentContainer>
);

export default RideView;
