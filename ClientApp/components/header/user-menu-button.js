import React from 'react'
import Button from '@material-ui/core/Button'
import Avatar from '@material-ui/core/Avatar';
import styled from '@material-ui/core/styles/styled';

export const UserAvatar = styled(Avatar)(({ theme }) => ({
  backgroundColor: theme.palette.primary.main,
  width: theme.spacing(4),
  height: theme.spacing(4),
}))

const UserMenuButton = ({ userName, onMenuOpen }) => {
  return (
    <Button onClick={onMenuOpen} style={{ paddingLeft: 5, paddingRight: 5, minWidth: 50 }}>
      <UserAvatar/>
    </Button>
  )
}

export default UserMenuButton
