import DialogContent from '@material-ui/core/DialogContent/DialogContent'
import DialogTitle from '@material-ui/core/DialogTitle'
import DialogActions from '@material-ui/core/DialogActions'
import styled from '@material-ui/core/styles/styled'
import IconButton from '@material-ui/core/IconButton'

export const Actions = styled(DialogActions)({
  paddingRight: 16,
  paddingBottom: 10,
})

export const ModalTitle = styled(DialogTitle)({
  padding: '7px 15px',
  '&:hover': {
    cursor: 'move'
  },
  '& h2': {
    fontSize: 15,
    width: '100%',
    display: 'flex',
    justifyContent: 'space-between',
    alignItems: 'center',
  }
})

export const ModalCloseIcon = styled(IconButton)({
  padding: 4,
  '& icon': {
    fontSize: 15,
  }
})

export const ModalContent = styled(DialogContent)({
  padding: 0
})
