import React from 'react';
import SyncAlt from '@material-ui/icons/SyncAlt';
import * as S from './styles';

export const SwapCitiesButton = ({ onClick }) => (
  <S.ChangeButton variant='outlined' onClick={onClick}>
    <SyncAlt/>
  </S.ChangeButton>
);

