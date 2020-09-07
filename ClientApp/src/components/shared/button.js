import React from 'react'
import MTButton from '@material-ui/core/Button'

const Button = ({
  children,
  variant = 'outlined',
  size = 'medium',
  color = 'primary',
  ...rest
}) => (
  <MTButton
    variant={variant}
    size={size}
    color={color}
    {...rest}
  >
    {children}
  </MTButton>
)

Button.propTypes = {}

export default Button
