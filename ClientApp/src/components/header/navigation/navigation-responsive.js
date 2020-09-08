import React from 'react';
import { NavigationDrawer } from './navigation-drawer';
import List from '@material-ui/core/List';
import { t } from '../../../lib/helpers';
import NavigationItem from './navigation-item';
import Logo from '../logo';
import Box from '@material-ui/core/Box';

export const NavigationResponsive = ({ open, onToggle }) => (
  <NavigationDrawer open={open} onToggle={onToggle}>
    <Box p={2} pl={4}>
      <Logo/>
    </Box>
    <List
      component="nav"
    >
      <NavigationItem href="">{t('Find a ride')}</NavigationItem>
      <NavigationItem href="">{t('Contact us')}</NavigationItem>
      <NavigationItem href="">{t('add a ride')}</NavigationItem>
      <NavigationItem href="">{t('Support')}</NavigationItem>
    </List>
  </NavigationDrawer>
);

