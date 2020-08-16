import React from 'react';
import FlexBox from '../../../shared/flex-box';
import { Lens } from '@material-ui/icons';
import green from '@material-ui/core/colors/green';
import red from '@material-ui/core/colors/red';

const RideSeats = ({ booked, free }) => {

  const seats = [];

  if (free && free > 0) {
    for (let i = 0; i < free; i++) {
      seats.push(<Lens style={{ color: green['A400'] }} fontSize='small'/>);
    }
  }

  if (booked && booked > 0) {
    for (let i = 0; i < booked; i++) {
      seats.push(<Lens style={{ color: red['A100'] }} fontSize='small'/>);
    }
  }

  return (
    <FlexBox>
      {seats}
    </FlexBox>
  );
};

export default RideSeats;
