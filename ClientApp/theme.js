import { createMuiTheme } from '@material-ui/core/styles';
import { red } from '@material-ui/core/colors';

const theme = createMuiTheme({
  typography: {
    fontFamily: `"Roboto", "DejaVu Sans"`,
  },
  palette: {
    primary: {
      main: '#07709b',
      // contrastText: '#e6ebf0',
    },
    secondary: {
      main: '#4DB6AC',
    },
    accent: {
      main: '#32afa9'
    },
    error: {
      main: red.A400,
    },
    background: {
      default: '#F7F8FA',
    },
    text: {
      secondary: '#608496'
    }
  },
})

export default theme;
