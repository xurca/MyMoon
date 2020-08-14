import React from 'react'
import Tooltip from '@material-ui/core/Tooltip'

const IconWithTooltip = ({ tooltipText, icon, tooltipPlacement = 'top' }) => (
  <Tooltip
    title={tooltipText}
    placement={tooltipPlacement}
    arrow
  >
    {icon}
  </Tooltip>
)

export default IconWithTooltip
