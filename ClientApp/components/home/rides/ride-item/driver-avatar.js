import React from 'react';
import styled from '@material-ui/core/styles/styled';
import Avatar from '@material-ui/core/Avatar';

export const StyledAvatar = styled(Avatar)(({ size, theme }) => {
  let avatarPadding;
  switch (size) {
    case 'small':
      avatarPadding = 5;
      break;
    case 'medium':
      avatarPadding = 8;
      break;
    case 'large':
      avatarPadding = 12;
      break;
    default:
      avatarPadding = 8;
  }
  return ({
    width: theme.spacing(avatarPadding),
    height: theme.spacing(avatarPadding),
  });
});

const DriverAvatar = ({ size }) => (
  <StyledAvatar alt="" src='/assets/images/avatar.jpg' size={size}/>
);

export default DriverAvatar;
