import React from 'react'
import Typography from '@material-ui/core/Typography'
import Rating from '@material-ui/lab/Rating'
import CenteredBox from '../../../shared/centered-box';

const DetailsArea = () => (
  <>
    <CenteredBox flex={1} style={{ borderBottom: '1px solid #f1f1f1' }}>
      <Typography variant='subtitle2'>
        ANZ-224
      </Typography>
    </CenteredBox>
    <CenteredBox flex={1}>
      <Typography variant='h6' gutterBottom>
        <Rating value={3} max={3} size='small' readOnly/>
      </Typography>
    </CenteredBox>
  </>
)

export default DetailsArea
