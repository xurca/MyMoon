import React from 'react';
import TimelineItem from '@material-ui/lab/TimelineItem';
import TimelineOppositeContent from '@material-ui/lab/TimelineOppositeContent';
import Typography from '@material-ui/core/Typography';
import TimelineSeparator from '@material-ui/lab/TimelineSeparator';
import TimelineDot from '@material-ui/lab/TimelineDot';
import { FlightLand, FlightTakeoff } from '@material-ui/icons';
import TimelineConnector from '@material-ui/lab/TimelineConnector';
import TimelineContent from '@material-ui/lab/TimelineContent';
import Timeline from '@material-ui/lab/Timeline';
import styled from '@material-ui/core/styles/styled';

const StyledTimeline = styled(Timeline)({
  margin: 0,
  padding: 0,
  '& .time': {
    flex: 0,
    marginRight: 0,
    minWidth: 80
  },
  '& .place': {
    flex: 0,
    minWidth: 300
  },
  '& .MuiTimelineSeparator-root': {
    height: 90
  }
})

const RideDirectionsTimeline = () => (
  <div>
    <StyledTimeline align="alternate">
      <TimelineItem>
        <TimelineOppositeContent className='time'>
          <Typography color="textSecondary" style={{ paddingTop: 8 }}>09:30</Typography>
        </TimelineOppositeContent>
        <TimelineSeparator>
          <TimelineDot color="primary" variant="outlined">
            <FlightTakeoff color='primary'/>
          </TimelineDot>
          <TimelineConnector/>
        </TimelineSeparator>
        <TimelineContent className='place'>
          <Typography>გორი</Typography>
          <Typography color="textSecondary" variant='body2'>სტალინის ძეგლი</Typography>
        </TimelineContent>
      </TimelineItem>
      <TimelineItem style={{height: 70}}>
        <TimelineOppositeContent className='place'>
          <Typography>ხაშური</Typography>
          <Typography color="textSecondary" variant='body2'>ნაზუქებთან</Typography>
        </TimelineOppositeContent>
        <TimelineSeparator>
          <TimelineDot color="primary" variant="outlined">
            <FlightLand color='primary'/>
          </TimelineDot>
        </TimelineSeparator>
        <TimelineContent className='time'>
          <Typography color="textSecondary" style={{ paddingTop: 8 }}>10:00</Typography>
        </TimelineContent>
      </TimelineItem>
    </StyledTimeline>
  </div>
);

export default RideDirectionsTimeline;
