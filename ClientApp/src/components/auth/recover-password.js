import React from 'react';
import Typography from '@material-ui/core/Typography'
import TextField from '@material-ui/core/TextField'
import Button from '@material-ui/core/Button'
import {FaLongArrowAltLeft} from 'react-icons/fa'
import Box from '@material-ui/core/Box'

const RecoverPassword = ({ setType }) => {

  const handleSubmit = event => {
    event.preventDefault()
  }

  return (
      <>
        <div style={{position: 'absolute', top: 16, left: 16}}>
          <Button
              startIcon={<FaLongArrowAltLeft/>}
              color='primary'
              onClick={() => setType('login')}
          >
            login
          </Button>
        </div>
        <Box mb={2} width='100%'>
          <Typography component="h1" variant="h6" align='center' gutterBottom>
            პაროლის აღდგენა
          </Typography>
        </Box>
        <form noValidate style={{width: '100%'}} onSubmit={handleSubmit}>
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
          <Button
              type="submit"
              fullWidth
              variant="contained"
              color="primary"
              size='large'
          >
            გაგზავნა
          </Button>
        </form>
      </>
  );
};

export default RecoverPassword;