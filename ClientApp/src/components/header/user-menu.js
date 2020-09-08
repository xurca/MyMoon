import React from 'react'
import ExitToApp from '@material-ui/icons/ExitToApp'
import UserMenuItem from './user-menu-item';
import UserMenuButton from './user-menu-button';
import styled from '@material-ui/core/styles/styled';
import Menu from '@material-ui/core/Menu';
import useContextMenu from '../../hooks/use-context-menu';

const StyledMenu = styled(Menu)(({ theme }) => ({
  '& ul': {
    paddingTop: 0,
    paddingBottom: 0
  }
}))

const UserMenu = () => {
  const { anchorEl, handleMenuOpen, handleMenuClose } = useContextMenu()

  return (
    <>
      <UserMenuButton
        userName='gela'
        onMenuOpen={handleMenuOpen}
      />
      <StyledMenu
        anchorEl={anchorEl}
        open={Boolean(anchorEl)}
        onClose={handleMenuClose}
      >
        <UserMenuItem
          icon={<ExitToApp color='primary'/>}
          text='logout'
          onClick={() => void 0}
          onMenuClose={handleMenuClose}
        />
      </StyledMenu>
    </>
  )
}

export default UserMenu
