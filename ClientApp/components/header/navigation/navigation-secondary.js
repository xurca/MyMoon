import React from 'react';
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

const OfferButton = styled(Button)(({ theme }) => ({
  marginLeft: theme.spacing(1.5),
  marginRight: theme.spacing(1.5),
}));

const NavigationSecondary = () => {

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
          <Button>
            შესვლა
          </Button>
          <Button>
            რეგისტრაცია
          </Button>
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
