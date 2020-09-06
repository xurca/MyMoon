import React from 'react';
import Modal from '../shared/modals/modal';
import Button from '@material-ui/core/Button';
import Box from '@material-ui/core/Box';
import Facebook from '@material-ui/icons/Facebook';
import TextField from '@material-ui/core/TextField';
import axios from 'axios';

const AuthModal = ({ open, onClose }) => {

  const handleGoogleLogin = async () => {
      window.location.href = 'https://localhost:5001/account/externallogin?provider=google&returnUrl=http://localhost:3000'
  };

  return (
    <Modal
      title='ავტორიზაცია'
      open={open}
      onClose={onClose}
      saveText='ავტორიზაცია'
    >
      <Box mb={2}>
        <Box mb={1}>
          <TextField
            label='მომხმარებელი'
            variant='outlined'
            size='small'
            fullWidth
          />
        </Box>
        <TextField
          type='password'
          label='პაროლი'
          variant='outlined'
          size='small'
          fullWidth
        />
      </Box>

      <Button
        style={{ backgroundColor: '#3b5998', color: '#fff' }}
        variant='contained'
        startIcon={<Facebook/>}
        fullWidth
      >
        Facebook Login
      </Button>
      <Box my={1}>
        <Button
          style={{ backgroundColor: '#DB4437', color: '#fff' }}
          variant='contained'
          startIcon={<Facebook/>}
          onClick={handleGoogleLogin}
          fullWidth
        >
          Google Login
        </Button>
      </Box>

    </Modal>
  );
};

export default AuthModal;
