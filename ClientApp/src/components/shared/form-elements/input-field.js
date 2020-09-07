import React from 'react'
import TextField from '@material-ui/core/TextField'
import InputAdornment from '@material-ui/core/InputAdornment'

const InputField = ({
  variant = 'outlined',
  margin = 'dense',
  label,
  startIcon,
  fullWidth = true,
  ...rest
}) => {
  return (
    <TextField
      variant={variant}
      margin={margin}
      label={label}
      fullWidth={fullWidth}
      InputProps={startIcon && {
        startAdornment: (
          <InputAdornment position="start">
            {startIcon}
          </InputAdornment>
        ),
      }}
      {...rest}
    />
  )
}

export default InputField
