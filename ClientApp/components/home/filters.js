import React from 'react';
import * as S from './styles';
import Slider from '@material-ui/core/Slider';
import IconButton from '@material-ui/core/IconButton';
import Work from '@material-ui/icons/Work';
import Box from '@material-ui/core/Box';
import Checkbox from '@material-ui/core/Checkbox';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import Button from '@material-ui/core/Button';
import Typography from '@material-ui/core/Typography';

const Filters = props => {

  const valuetext = (value) => {
    return `${value}`;
  };

  return (
    <S.Filters>
      <S.FilterItemWrapper>
        <S.FilterItemTitle variant='body1' gutterBottom>
          Radius
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
          Lagguage
        </S.FilterItemTitle>
        <Box display='flex' justifyContent='space-between' px={1}>
          <Box align='center'>
            <Work style={{ fontSize: 16 }}/>
            <Typography variant='caption'>
              Small
            </Typography>
          </Box>
          <Box align='center'>
            <Work style={{ fontSize: 20 }}/>
            <Typography variant='caption'>
              Medium
            </Typography>
          </Box>
          <Box align='center'>
            <Work style={{ fontSize: 24 }}/>
            <Typography variant='caption'>
              Large
            </Typography>
          </Box>
        </Box>
      </S.FilterItemWrapper>
      <S.FilterItemWrapper>
        <S.FilterItemTitle variant='body1' gutterBottom>
          Rides
        </S.FilterItemTitle>
        <FormControlLabel
          control={
            <Checkbox
              value="hide"
              color="primary"
            />
          }
          label="Hide partial routes"
        />
      </S.FilterItemWrapper>
      <S.FilterItemWrapper>
        <S.FilterItemTitle variant='body1' gutterBottom>
          Rides
        </S.FilterItemTitle>
        <FormControlLabel
          control={
            <Checkbox
              value="hide"
              color="primary"
            />
          }
          label="Hide partial routes"
        />
      </S.FilterItemWrapper>
      <S.FilterItemWrapper>
        <S.FilterItemTitle variant='body1' gutterBottom>
          Preferences
        </S.FilterItemTitle>
        <Box display='flex' justifyContent='space-between'>
          <Box display='flex' flexDirection='column'>
            <FormControlLabel
              control={
                <Checkbox
                  value="hide"
                  color="primary"
                />
              }
              label="Music"
            />
            <FormControlLabel
              control={
                <Checkbox
                  value="hide"
                  color="primary"
                />
              }
              label="Music"
            />
          </Box>
          <Box display='flex' flexDirection='column'>
            <FormControlLabel
              control={
                <Checkbox
                  value="hide"
                  color="primary"
                />
              }
              label="Animals"
            />
            <FormControlLabel
              control={
                <Checkbox
                  value="hide"
                  color="primary"
                />
              }
              label="Smoking"
            />
          </Box>
        </Box>

      </S.FilterItemWrapper>
      <S.FilterItemWrapper>
        <Button
          variant='contained'
          color='primary'
          fullWidth
        >
          Update
        </Button>
      </S.FilterItemWrapper>
    </S.Filters>
  );
};

Filters.propTypes = {};

export default Filters;
