import React from 'react';
import styled from '@material-ui/core/styles/styled';
import IconWithTooltip from '../../../shared/icon-with-tooltip';
import { Group, Whatshot } from '@material-ui/icons';
import orange from '@material-ui/core/colors/orange';
import blue from '@material-ui/core/colors/blue';
import { Box } from '@material-ui/core';

const rideInfoItemsMap = {
  notRequireAcceptance: {
    text: 'დასაჯავშნად არ საჭიროებს მძღოლის თანხმობას',
    icon: <Whatshot style={{ color: orange[900] }}/>
  },
  onlyTwoPassengers: {
    text: 'უკანა სავარძელზე მხოლოდ ორი მგზავრი',
    icon: <Group style={{ color: blue[500] }}/>
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
      <Box mr={0.5} key={item}>
        <IconWithTooltip
          icon={rideInfoItemsMap[item].icon}
          tooltipText={rideInfoItemsMap[item].text}
        />
      </Box>
    )}
  </Wrapper>
);

export default RideInfo;
