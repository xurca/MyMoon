import React from 'react'
import * as S from './styles'
import Typography from '@material-ui/core/Typography'
import Rating from '@material-ui/lab/Rating'
import CenteredBox from '../../../shared/centered-box';

const AvatarArea = () => (
  <CenteredBox
    flexDirection='column'
    style={{ height: '100%' }}
  >
    <S.DriverAvatar alt="Remy Sharp" src={''}/>
    <Typography variant='body1'>
      ჯონდი ბაღათურია
    </Typography>
    <Rating value={3} size='small' readOnly/>
  </CenteredBox>
)

export default AvatarArea
