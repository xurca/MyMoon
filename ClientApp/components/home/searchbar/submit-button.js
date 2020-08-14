import React from 'react';
import Search from '@material-ui/icons/Search';
import Button from '@material-ui/core/Button';
import Typography from '@material-ui/core/Typography';

export const SubmitButton = ({ onSubmit, isSubmitting, ...rest }) => (
  <Button
    startIcon={<Search/>}
    variant='contained'
    color='primary'
    disabled={isSubmitting}
    onClick={onSubmit}
    style={{
      minWidth: 100,
      padding: '8px 15px 10px 15px',
      marginLeft: 4
    }}
    {...rest}
  >
    <Typography variant='body2' noWrap>
      ძებნა
    </Typography>
  </Button>
);

