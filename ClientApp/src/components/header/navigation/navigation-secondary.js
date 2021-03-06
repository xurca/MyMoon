import React, {useState} from 'react';
import Divider from '@material-ui/core/Divider';
import Box from '@material-ui/core/Box';
import FlexBox from '../../shared/flex-box';
import styled from '@material-ui/core/styles/styled';
import Button from '@material-ui/core/Button';
import { t } from '../../../lib/helpers';
import Link from 'next/link';
import Flag from '../../shared/flag';
import IconButton from '@material-ui/core/IconButton';
import UserMenu from '../user-menu';
import LoginAction from '../../auth/login-action';
import SignupAction from '../../auth/signup-action'

const OfferButton = styled(Button)(({ theme }) => ({
  marginLeft: theme.spacing(1.5),
  marginRight: theme.spacing(1.5),
}));

const NavigationSecondary = () => {
  const [type, setType] = useState()

  const authenticated = false;

  return (
    <FlexBox alignItems='center'>
      <Link href='/rides/new'>
        <OfferButton variant='outlined' color='primary' href='#'>
          {t('add a ride')}
        </OfferButton>
      </Link>
      <Box mx={1} height={40}>
        <Divider orientation='vertical'/>
      </Box>
      {authenticated ?
        <UserMenu/> :
        <>
          <LoginAction type={type} setType={setType}/>
          <SignupAction type={type} setType={setType}/>
        </>
      }
      <FlexBox alignItems='center' ml={1}>
        <IconButton size='small'>
          <Flag countryCode='ge' width={25}/>
        </IconButton>
      </FlexBox>
    </FlexBox>
  );
};

export default NavigationSecondary;
