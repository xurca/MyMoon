import styled from '@material-ui/core/styles/styled'
import Toolbar from '@material-ui/core/Toolbar'
import Box from '@material-ui/core/Box'
import Button from '../../shared/button';
import SubmitButton from '../../shared/form-elements/submit-button';

export const SearchFormWrapper = styled(Box)(({ theme }) => ({
  display: 'flex',
}))

export const Searchbar = styled(Toolbar)(({ theme }) => ({
  borderBottom: '1px solid #c4c4c4',
  backgroundColor: '#fff'
}))

export const SearchFormButton = styled(SubmitButton)(({ theme }) => ({
  paddingTop: theme.spacing(1.1),
  paddingBottom: theme.spacing(1.1),
  marginRight: theme.spacing(0.5),
  marginLeft: theme.spacing(0.5),
}))

export const ChangeButton = styled(Button)(({ theme }) => ({
  padding: `${theme.spacing(0.8)}px 0`,
  marginRight: theme.spacing(0.5),
  marginLeft: theme.spacing(0.5),
  minWidth: 45,
}))

export const CitiesRangeWrapper = styled(Box)(({ theme }) => ({
  flex: 1,
  display: 'flex',
  alignItems: 'center',
  position: 'relative',
  marginRight: theme.spacing(0.5),
  '& > div': {
    flex: 1,
    margin: `0 ${theme.spacing(0.5)}px`,
    '&:first-child': {
      marginLeft: 0,
    },
  },
}))
