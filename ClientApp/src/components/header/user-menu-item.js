import React from 'react'
import ListItemIcon from '@material-ui/core/ListItemIcon'
import ListItemText from '@material-ui/core/ListItemText'
import MenuItem from '@material-ui/core/MenuItem'

const UserMenuItem = React.forwardRef(({ icon, text, onClick, onMenuClose }, ref) => {

  const handleClick = () => {
    onClick()
    onMenuClose()
  }

  return (
    <MenuItem onClick={handleClick} ref={ref}>
      <ListItemIcon style={{ minWidth: 30 }}>
        {icon}
      </ListItemIcon>
      <ListItemText>
        {text}
      </ListItemText>
    </MenuItem>
  )
})

export default UserMenuItem
