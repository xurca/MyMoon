import styled from '@material-ui/core/styles/styled'
import Paper from '@material-ui/core/Paper'
import Avatar from '@material-ui/core/Avatar'
import Box from '@material-ui/core/Box'

export const RideItem = styled(Paper)(({ theme }) => ({
  height: 180,
  marginBottom: theme.spacing(2),
  marginTop: theme.spacing(1),
  display: 'flex',
  cursor: 'pointer'
}))

export const DriverAvatar = styled(Avatar)(({ theme }) => ({
  width: theme.spacing(10),
  height: theme.spacing(10),
}))

export const InfoItemsWrapper = styled(Box)(({ theme }) => ({
  padding: theme.spacing(2),
  position: 'absolute',
  top: 5,
  right: 5,
  display: 'flex',
  alignItems: 'center'
}))

export const InfoItem = styled(Box)(({ theme }) => ({
  marginLeft: theme.spacing(1),
}))
