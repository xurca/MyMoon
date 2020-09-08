import React from 'react';
import * as S from './styles';
import Filters from './filters';
import Button from '@material-ui/core/Button';

const FiltersForm = () => (
  <S.Filters>
    <Filters/>
    <S.FilterItemWrapper>
      <Button
        variant='contained'
        color='primary'
        fullWidth
      >
        ფილტრაცია
      </Button>
    </S.FilterItemWrapper>
  </S.Filters>
);

export default FiltersForm;
