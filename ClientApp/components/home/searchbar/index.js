import React from 'react';
import Container from '@material-ui/core/Container';
import * as S from './styles';
import AppBar from '@material-ui/core/AppBar';
import SearchForm from './search-form';
import { MuiPickersUtilsProvider } from '@material-ui/pickers';
import DateFnsUtils from '@date-io/date-fns';
import useTheme from '@material-ui/core/styles/useTheme';
import useMediaQuery from '@material-ui/core/useMediaQuery';

const Searchbar = () => {
  const theme = useTheme();
  const matches = useMediaQuery(theme.breakpoints.down('md'));

  return (
    <AppBar position={matches ? 'static' : 'sticky'} elevation={0}>
      <S.Searchbar>
        <Container maxWidth='lg'>
          <MuiPickersUtilsProvider utils={DateFnsUtils}>
            <SearchForm/>
          </MuiPickersUtilsProvider>
        </Container>
      </S.Searchbar>
    </AppBar>

  );
};

export default Searchbar;
