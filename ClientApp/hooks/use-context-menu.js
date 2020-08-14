import { useState } from 'react'

const useContextMenu = () => {
  const [anchorEl, setAnchorEl] = useState(null)

  const handleMenuOpen = event => {
    setAnchorEl(event.currentTarget)
  }

  const handleMenuClose = () => {
    setAnchorEl(null)
  }

  return { anchorEl, handleMenuOpen, handleMenuClose }
}

export default useContextMenu
