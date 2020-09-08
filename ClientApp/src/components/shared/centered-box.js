import React from 'react'
import Box from '@material-ui/core/Box'

const CenteredBox = ({
  children,
  justifyContent = 'center',
  alignItems = 'center',
  ...rest
}) => (
  <Box
    display='flex'
    width='100%'
    justifyContent={justifyContent}
    alignItems={alignItems}
    {...rest}
  >
    {children}
  </Box>
)

CenteredBox.propTypes = {}

export default CenteredBox
