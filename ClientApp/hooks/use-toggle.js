import { useState } from 'react'

const useToggle = (openState = false) => {
  const [open, setOpen] = useState(openState)

  const handleOpen = () => {
    setOpen(true)
  }

  const handleClose = () => {
    setOpen(false)
  }

  return { open, handleOpen, handleClose }
}

export default useToggle
