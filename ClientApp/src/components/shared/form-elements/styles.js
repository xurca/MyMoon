import styled from '@material-ui/core/styles/styled'
import CircularProgress from '@material-ui/core/CircularProgress'

export const SubmitButtonWrapper = styled('div')({
  position: 'relative',
})

export const SubmitButtonProgress = styled(CircularProgress)(({ theme }) => ({
  color: theme.palette.secondary.main,
  position: 'absolute',
  top: '50%',
  left: '50%',
  marginTop: -12,
  marginLeft: -12,
}))
