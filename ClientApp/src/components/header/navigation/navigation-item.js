import React from 'react'
import styled from '@material-ui/core/styles/styled';
import MenuItem from '@material-ui/core/MenuItem';

const NavItem = styled(MenuItem)(({ theme }) => ({
  color: theme.palette.text.secondary,
  '&:hover': {
    color: theme.palette.primary.main
  }
}))

const NavigationItem = ({ children, ...rest }) => (
  <NavItem {...rest}>{children}</NavItem>
)

export default NavigationItem
