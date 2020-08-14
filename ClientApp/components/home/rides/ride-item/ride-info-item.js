import React from 'react'
import * as S from './styles'
import IconWithTooltip from '../../../shared/icon-with-tooltip';

const RideInfoItem = ({ icon, tooltipText }) => (
  <S.InfoItem>
    <IconWithTooltip
      icon={icon}
      tooltipText={tooltipText}
    />
  </S.InfoItem>
)

export default RideInfoItem
