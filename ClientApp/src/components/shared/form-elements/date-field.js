import React from 'react';
import { DatePicker } from '@material-ui/pickers';
import InputAdornment from '@material-ui/core/InputAdornment';
import { CalendarToday } from '@material-ui/icons';

const DateField = ({ value, name, label, onChange, ...rest }) => (
  <DatePicker
    label={label}
    error={false}
    size='small'
    helperText={null}
    format='d/m/y'
    value={value}
    onChange={date => {
      onChange(name, date)
    }}
    autoOk
    disableToolbar
    inputVariant='outlined'
    variant='inline'
    fullWidth
    InputProps={{
      startAdornment: (
        <InputAdornment position="start">
          <CalendarToday color='primary'/>
        </InputAdornment>
      )
    }}
    {...rest}
  />
)

export default DateField
