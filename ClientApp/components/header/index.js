import AppBar from '@material-ui/core/AppBar';
import styled from '@material-ui/core/styles/styled';
import Toolbar from '@material-ui/core/Toolbar';
import Logo from './logo';
import React, { useState } from 'react';
import Hidden from '@material-ui/core/Hidden';
import FlexBox from '../shared/flex-box';
import NavigationPrimary from './navigation/navigation-primary';
import NavigationSecondary from './navigation/navigation-secondary';
import { NavigationButton } from './navigation/navigation-button';
import { NavigationResponsive } from './navigation/navigation-responsive';

const TopBar = styled(Toolbar)(({ theme }) => ({
  borderBottom: '1px solid #f1f1f1',
  backgroundColor: '#fff',
  display: 'flex',
  justifyContent: 'space-between',
  alignItems: 'center',
}));

const Header = () => {
  const [mobileNavOpen, setMobileNavOpen] = useState(false);

  const handleDrawerToggle = () => {
    setMobileNavOpen(prevState => !prevState);
  };

  return (
    <AppBar position='static' elevation={0}>
      <TopBar>
        <FlexBox alignSelf='stretch' alignItems='center'>
          <Logo/>
          <Hidden smDown>
            <NavigationPrimary/>
          </Hidden>
        </FlexBox>
        <Hidden smDown>
          <NavigationSecondary/>
        </Hidden>
        <Hidden mdUp>
          <NavigationButton onClick={handleDrawerToggle}/>
        </Hidden>
        <NavigationResponsive
          open={mobileNavOpen}
          onToggle={handleDrawerToggle}
        />
      </TopBar>
    </AppBar>
  );
};

export default Header;
