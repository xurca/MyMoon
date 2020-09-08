import React from 'react';
import FlexBox from '../../../shared/flex-box';
import { Lens } from '@material-ui/icons';
import green from '@material-ui/core/colors/green';
import red from '@material-ui/core/colors/red';

const RideSeats = ({ booked, free }) => {
  const bookedIconStyles = Array(booked).fill({ color: red['A100'] });
  const freeIconStyles = Array(free).fill({ color: green['A400'] });

  const seatsIconStyles = [...freeIconStyles, ...bookedIconStyles];
  return (
    <FlexBox>
      {seatsIconStyles.map((style, index) =>
        <Lens
          key={index}
          style={style}
          fontSize='small'
        />)}
    </FlexBox>
  );
};

export default RideSeats;
