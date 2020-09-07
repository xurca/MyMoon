import React from 'react';
import Drawer from '@material-ui/core/Drawer';


export const NavigationDrawer = ({
  open,
  onToggle,
  window,
  ...rest
}) => {
  const container = window !== undefined ? () => window().document.body : undefined;

  return (
    <Drawer
      container={container}
      variant="temporary"
      anchor='left'
      open={open}
      onClose={onToggle}
      ModalProps={{
        keepMounted: true,
      }}
      {...rest}
    />
  );
};

