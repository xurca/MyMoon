import React from 'react';
import Box from '@material-ui/core/Box';
import blueGrey from '@material-ui/core/colors/blueGrey';
import Container from '@material-ui/core/Container';
import FlexBox from '../shared/flex-box';
import Typography from '@material-ui/core/Typography';

const Footer = () => (
  <Box height={200} bgcolor={blueGrey[500]} mt={10}>
    <Container maxWidth='md' style={{ height: '100%' }}>
      <FlexBox flexDirection='column' height='100%'>
        <Box flex={1}>

        </Box>
        <Box flex={1}>

        </Box>
        <Box height={40}>
          <Typography variant='subtitle2' style={{ color: '#fff' }}>
            &#169; 2020
          </Typography>
        </Box>
      </FlexBox>
    </Container>
  </Box>
);

export default Footer;
