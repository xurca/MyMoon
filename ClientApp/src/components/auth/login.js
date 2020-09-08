import React from 'react';
import TextField from '@material-ui/core/TextField'
import Button from '@material-ui/core/Button'
import Link from '@material-ui/core/Link'
import Typography from '@material-ui/core/Typography'
import FlexBox from '../shared/flex-box'
import {FcGoogle} from "react-icons/fc";
import {FaFacebook} from "react-icons/fa";
import Box from '@material-ui/core/Box'

const Login = ({setType}) => {

  const handleGoogleLogin = async () => {
    window.location.href = 'https://localhost:5001/account/externallogin?provider=google&returnUrl=http://localhost:3000'
  };

  const handleSubmit = event => {
    event.preventDefault()
  }

  return (
      <div>
        <Box mb={2} width='100%'>
          <Typography component="h1" variant="h5" align='center' gutterBottom>
            Hi!
          </Typography>
          <Typography variant="body2" align='center'>
            არ ხარ ჩვენი წევრი? {' '}
            <Link component='button' onClick={() => setType('signup')} variant="body2">
              დარეგისტრირდი!
            </Link>
          </Typography>
        </Box>
        <form noValidate onSubmit={handleSubmit}>
          <TextField
              variant="outlined"
              required
              fullWidth
              id="email"
              label="ელ. ფოსტა"
              name="email"
              autoComplete="email"
              autoFocus
              style={{marginBottom: 12}}
          />
          <TextField
              variant="outlined"
              required
              fullWidth
              name="password"
              label="პაროლი"
              type="password"
              id="password"
              autoComplete="current-password"
          />
          <FlexBox width='100%' justifyContent='flex-end' mb={2} mt={0.5}>
            <Link component="button" variant="body2" onClick={() => setType('recover')} >
              დაგავიწყდა პაროლი?
            </Link>
          </FlexBox>
          <Button
              type="submit"
              fullWidth
              variant="contained"
              color="primary"
              size='large'
          >
            შესვლა
          </Button>
        </form>
        <FlexBox alignItems='center' width='100%' my={1}>
          <div style={{borderTop: '1px solid #ccc', flex: 1}}/>
          <Typography variant='body2' style={{margin: '0 8px'}}>
            ან
          </Typography>
          <div style={{borderTop: '1px solid #ccc', flex: 1}}/>
        </FlexBox>
        <Button
            style={{backgroundColor: '#FFF', marginBottom: 12}}
            variant='contained'
            startIcon={<FcGoogle/>}
            size='large'
            onClick={handleGoogleLogin}
            fullWidth
        >
          Google ავტორიზაცია
        </Button>
        <Button
            style={{backgroundColor: '#3b5998', color: '#fff'}}
            variant='contained'
            size='large'
            startIcon={<FaFacebook/>}
            fullWidth
        >
          Facebook ავტორიზაცია
        </Button>
      </div>
  );
};

export default Login;