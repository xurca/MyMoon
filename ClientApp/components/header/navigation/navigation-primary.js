import React from 'react';
import { t } from '../../../lib/helpers';
import Link from 'next/link';
import styled from '@material-ui/core/styles/styled';
import { useRouter } from 'next/router';

const StyledNav = styled('nav')(({ theme }) => ({
  background: '#fff',
  height: '100%',
  padding: '0',
  '& ul': {
    listStyle: 'none',
    textAlign: 'center',
    display: 'flex',
    height: '100%',
    margin: 0,
    padding: 0,
    '& li': {
      display: 'flex',
      height: '100%',
      alignItems: 'center',
      position: 'relative',
      transition: 'all .4s',
      '& a': {
        height: '100%',
        display: 'flex',
        alignItems: 'center',
        padding: '5px',
        textDecoration: 'none',
        color: theme.palette.primary.main,
        margin: '0 10px',
        position: 'relative',
        whiteSpace: 'nowrap',
      },
      '&:after, &:before': {
        transition: 'all .4s',
      },
      '&:after': {
        position: 'absolute',
        bottom: 0,
        left: 0,
        right: 0,
        margin: 'auto',
        width:' 0%',
        content: '"."',
        color: 'transparent',
        background: theme.palette.primary.main,
        height: 2,
      },
      '&:hover, &.active': {
        color: '#555',
        background: 'rgba(7, 112, 155, 0.04)'
      },
      '&:hover:after, &.active:after': {
        width: '100%',
      }
    }
  }
}));

const NavigationPrimary = () => {
  const router = useRouter()

  console.log(router.pathname)

  return (
    <StyledNav>
      <ul>
        <li className={router.pathname === '/rides' ? 'active' : ''}>
          <Link href="/rides">
            <a>{t('Find a ride')}</a>
          </Link>
        </li>
        <li className={router.pathname === '/contact' ? 'active' : ''}>
          <Link href="/contact">
            <a>{t('Contact us')}</a>
          </Link>
        </li>
      </ul>
    </StyledNav>
    /*<FlexBox alignSelf='stretch'>
      <Link href="/rides">

        <a><NavigationItem>{t('Find a ride')}</NavigationItem></a>
      </Link>
      <NavigationItem>{t('Contact us')}</NavigationItem>
    </FlexBox>*/
  );
};

export default NavigationPrimary;
