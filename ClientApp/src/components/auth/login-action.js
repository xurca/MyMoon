import React from 'react';
import useToggle from '../../hooks/use-toggle';
import Button from '@material-ui/core/Button';
import AuthModal from './auth-modal';

const LoginAction = ({ type }) => {
  const { open, handleOpen, handleClose } = useToggle()

  return (
    <>
      <Button onClick={handleOpen}>
        შესვლა
      </Button>
      <AuthModal
        open={open}
        onClose={handleClose}
      />
    </>
  );
};

export default LoginAction;
