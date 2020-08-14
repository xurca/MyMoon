import React from 'react'
import Weekend from '@material-ui/icons/Weekend'
import CheckBox from '@material-ui/icons/CheckBox'
import * as S from './styles'
import RideInfoItem from './ride-info-item';

const RideInfoItems = () => (
  <S.InfoItemsWrapper>
    <RideInfoItem
      icon={<CheckBox color='primary'/>}
      tooltipText='This ride dows not require drivers accaptance to be booked'
    />
    <RideInfoItem
      icon={<Weekend color='primary'/>}
      tooltipText='Driver guarantees a maximum of 2 passengers in the back seat'
    />
  </S.InfoItemsWrapper>
)

export default RideInfoItems
