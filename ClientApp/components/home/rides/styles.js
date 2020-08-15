import styled from '@material-ui/core/styles/styled';
import Paper from '@material-ui/core/Paper';
import Box from '@material-ui/core/Box';
import Typography from '@material-ui/core/Typography';

export const Filters = styled(Paper)(({ theme }) => ({
  position: 'sticky',
  top: 84
}))

export const FilterItemWrapper = styled(Box)(({ theme }) => ({
  borderBottom: '1px solid #eee',
  padding: `${theme.spacing(1)}px ${theme.spacing(2)}px`,
  fontSize: 13
}))

export const FilterItemTitle = styled(Typography)(({ theme }) => ({
  color: theme.palette.text.secondary
}))
