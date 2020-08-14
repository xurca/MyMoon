import React from 'react';
import Autocomplete from '@material-ui/lab/Autocomplete';
import makeStyles from '@material-ui/core/styles/makeStyles';
import TextField from '@material-ui/core/TextField';
import InputAdornment from '@material-ui/core/InputAdornment';

const useStyles = makeStyles({
  option: {
    fontSize: 15,
  },
});

const CitiesField = ({
  value,
  name,
  label,
  startIcon,
  onChange,
}) => {
  const classes = useStyles();

  return (
    <Autocomplete
      options={cities}
      name={name}
      value={value || null}
      classes={{
        option: classes.option,
      }}
      onChange={(_, value) => {
        onChange(name, value);
      }}
      autoHighlight
      renderOption={(option) => (
        <React.Fragment>
          {option}
        </React.Fragment>
      )}
      renderInput={(params) => (
        <TextField
          {...params}
          label={label}
          variant="outlined"
          size='small'

          InputProps={{
            ...params.InputProps,
            style: { paddingLeft: 14 },
            startAdornment: (
              <InputAdornment position="start">
                {startIcon}
              </InputAdornment>
            ),
          }}
          inputProps={{
            ...params.inputProps,
            autoComplete: 'new-password', // disable autocomplete and autofill
          }}
        />
      )}
    />
  );
};

const cities = [
  'ზესტაფონი',
  'ხაშური',
  'ბორჯომი',
  'რუსთავი',
];

export default CitiesField;
