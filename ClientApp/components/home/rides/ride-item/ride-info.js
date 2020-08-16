import React from 'react';
import CheckBox from '@material-ui/icons/CheckBox';
import styled from '@material-ui/core/styles/styled';
import IconWithTooltip from '../../../shared/icon-with-tooltip';

const rideInfoItemsMap = {
  notRequireAcceptance: {
    text: 'დასაჯავშნად არ საჭიროებს მძღოლის თანხმობას',
    icon: <CheckBox color='primary'/>
  },
  onlyTwoPassengers: {
    text: 'უკანა სავარძელზე მხოლოდ ორი მგზავრი',
    icon: <CheckBox color='primary'/>
  }
};

export const Wrapper = styled('div')(({ theme }) => ({
  padding: theme.spacing(1),
  display: 'flex',
  alignItems: 'center'
}));

const RideInfo = ({ infoItems }) => (
  <Wrapper>
    {infoItems.map(item =>
      <IconWithTooltip
        key={item}
        icon={rideInfoItemsMap[item].icon}
        tooltipText={rideInfoItemsMap[item].text}
      />)}
  </Wrapper>
);

export default RideInfo;
