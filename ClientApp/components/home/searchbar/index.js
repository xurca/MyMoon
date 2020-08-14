import React from 'react';
import Container from '@material-ui/core/Container';
import * as S from './styles';
import AppBar from '@material-ui/core/AppBar';
import SearchForm from './search-form';
import { MuiPickersUtilsProvider } from '@material-ui/pickers';
import DateFnsUtils from '@date-io/date-fns';

const Searchbar = () => {

  return (
    <AppBar position='sticky' elevation={0}>
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
