import React from 'react'
import * as S from './styles'
import Grid from '@material-ui/core/Grid'
import AvatarArea from './avatar-area';
import DescArea from './desc-area';
import DetailsArea from './details-area';

const RideItem = ({ onClick }) => {
  return (
    <S.RideItem onClick={onClick}>
      <Grid xs={3} item style={{ borderRight: '1px solid #f1f1f1' }}>
        <AvatarArea/>
      </Grid>
      <Grid xs={7} item>
        <DescArea/>
      </Grid>
      <Grid xs={2} item style={{ borderLeft: '1px solid #f1f1f1', display: 'flex', flexDirection: 'column' }}>
        <DetailsArea/>
      </Grid>
    </S.RideItem>
  )
}

export default RideItem
