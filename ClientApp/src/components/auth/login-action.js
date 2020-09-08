import React from 'react';
import useToggle from '../../hooks/use-toggle';
import Button from '@material-ui/core/Button';
import AuthModal from './auth-modal';

const LoginAction = ({ type, setType }) => {
  const { open, handleOpen, handleClose } = useToggle();

  const handleSignupOpen = () => {
    setType('login');
    handleOpen();
  }

  return (
    <>
      <Button onClick={handleSignupOpen}>
        შესვლა
      </Button>
      <AuthModal
        open={open}
        type={type}
        setType={setType}
        onClose={handleClose}
      />
    </>
  );
};

export default LoginAction;
