import React from 'react';
import useToggle from '../../hooks/use-toggle';
import Button from '@material-ui/core/Button';
import AuthModal from './auth-modal';

const SignupAction = ({ type, setType }) => {
  const { open, handleOpen, handleClose } = useToggle()

  const handleSignupOpen = () => {
    setType('signup');
    handleOpen()
  }

  return (
    <>
      <Button onClick={handleSignupOpen}>
        რეგისტრაცია
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

export default SignupAction;
