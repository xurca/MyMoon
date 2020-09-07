import React, {useEffect, useState} from 'react';
import Dialog from '@material-ui/core/Dialog'
import Signup from './signup'
import Container from '@material-ui/core/Container'
import makeStyles from '@material-ui/core/styles/makeStyles'
import Login from './login'
import RecoverPassword from './recover-password'

const useStyles = makeStyles((theme) => ({
  paper: {
    paddingTop: 16,
    paddingBottom: 16,
    display: 'flex',
    flexDirection: 'column',
    alignItems: 'center',
    minWidth: 400
  },
}));

const AuthModal = ({open, onClose, type = 'login', setType}) => {
  const classes = useStyles();
  let authComponent;

  if (type === 'login') {
    authComponent = <Login setType={setType}/>
  } else if (type === 'signup') {
    authComponent = <Signup setType={setType}/>
  } else {
    authComponent = <RecoverPassword setType={setType}/>
  }

  return (
      <Dialog
          open={open}
          onClose={onClose}
          onExited={() => setType('login')}
      >
        <Container maxWidth="xs">
          <div className={classes.paper}>
            {authComponent}
          </div>
        </Container>
      </Dialog>
  );
};

export default AuthModal;
