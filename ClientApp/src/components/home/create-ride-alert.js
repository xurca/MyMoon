import React from 'react'
import useToggle from '../../hooks/use-toggle';
import Button from '../shared/button';
import Modal from '../shared/modals/modal';

const CreateRideAlert = () => {
  const { open, handleClose, handleOpen } = useToggle()
  return (
    <>
      <Button
        onClick={handleOpen}
      >
        Create ride alert
      </Button>
      <Modal
        open={open}
        title='Create ride alert'
        onClose={handleClose}
      />
    </>
  )
}

export default CreateRideAlert
