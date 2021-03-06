import React, { useState } from 'react';
import * as S from './styles';
import Slider from '@material-ui/core/Slider';
import Work from '@material-ui/icons/Work';
import Box from '@material-ui/core/Box';
import Checkbox from '@material-ui/core/Checkbox';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import Button from '@material-ui/core/Button';
import ToggleButtonGroup from '@material-ui/lab/ToggleButtonGroup';
import ToggleButton from '@material-ui/lab/ToggleButton';
import { useMediaQuery } from '@material-ui/core';
import useTheme from '@material-ui/core/styles/useTheme';
import FlexBox from '../../shared/flex-box';

const Filters = () => {
  const [values, setValues] = useState({
    radius: '',
    luggageSize: '',
    preferences: [],
    comfort: []
  });
  const theme = useTheme()
  const matches = useMediaQuery(theme.breakpoints.down('md'))

  const valuetext = (value) => {
    return `${value}`;
  };

  return (
    <>
      <S.FilterItemWrapper>
        <S.FilterItemTitle variant='body1' gutterBottom>
          რადიუსი
        </S.FilterItemTitle>
        <Slider
          defaultValue={30}
          getAriaValueText={valuetext}
          aria-labelledby="discrete-slider"
          valueLabelDisplay="auto"
          step={10}
          marks
          min={10}
          max={110}
        />
      </S.FilterItemWrapper>
      <S.FilterItemWrapper>
        <S.FilterItemTitle variant='body1' gutterBottom>
          ბარგი
        </S.FilterItemTitle>
        <ToggleButtonGroup
          exclusive
          value={values.luggageSize}
          onChange={() => void 0}
          aria-label="lagguage size"
        >
          <ToggleButton value="small" aria-label="small">
            <Work color='primary' style={{ fontSize: 16 }}/>
          </ToggleButton>
          <ToggleButton value="medium" aria-label="medium">
            <Work color='primary' style={{ fontSize: 20 }}/>
          </ToggleButton>
          <ToggleButton value="large" aria-label="large">
            <Work color='primary' style={{ fontSize: 24 }}/>
          </ToggleButton>
        </ToggleButtonGroup>
      </S.FilterItemWrapper>
      <S.FilterItemWrapper>
        <S.FilterItemTitle variant='body1' gutterBottom>
          კომფორტი
        </S.FilterItemTitle>
        <FormControlLabel
          control={
            <Checkbox
              value="hide"
              color="primary"
            />
          }
          label="მაქს. ორი უკანა სავარელზე"
        />
      </S.FilterItemWrapper>
      <S.FilterItemWrapper>
        <S.FilterItemTitle variant='body1' gutterBottom>
          Preferences
        </S.FilterItemTitle>
        <FlexBox justifyContent='space-between' flexDirection={matches ? 'column' : 'row'}>
          <FlexBox flexDirection='column'>
            <FormControlLabel
              control={
                <Checkbox
                  value="hide"
                  color="primary"
                />
              }
              label="მუსიკა"
            />
            <FormControlLabel
              control={
                <Checkbox
                  value="hide"
                  color="primary"
                />
              }
              label="ცხოველები"
            />
          </FlexBox>
          <FlexBox flexDirection='column'>
            <FormControlLabel
              control={
                <Checkbox
                  value="hide"
                  color="primary"
                />
              }
              label="მოწევა"
            />
            <FormControlLabel
              control={
                <Checkbox
                  value="hide"
                  color="primary"
                />
              }
              label="გაგრილება"
            />
          </FlexBox>
        </FlexBox>
      </S.FilterItemWrapper>
    </>
  );
};

export default Filters;
