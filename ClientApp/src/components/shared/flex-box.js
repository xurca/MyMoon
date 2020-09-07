import React from 'react'
import Box from '@material-ui/core/Box'

const FlexBox = ({ children, ...rest }) => (
  <Box display='flex' {...rest}>
    {children}
  </Box>
)

export default FlexBox
