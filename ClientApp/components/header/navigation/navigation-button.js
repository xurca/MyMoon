import React from 'react';
import MenuIcon from '@material-ui/icons/Menu';
import IconButton from '@material-ui/core/IconButton';

export const NavigationButton = ({ onClick }) => (
  <IconButton
    color='primary'
    onClick={onClick}
  >
    <MenuIcon/>
  </IconButton>
);

