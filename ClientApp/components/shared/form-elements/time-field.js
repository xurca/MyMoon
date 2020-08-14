import React from 'react'
import { TimePicker } from '@material-ui/pickers'
import InputAdornment from '@material-ui/core/InputAdornment';
import { CalendarToday, Schedule } from '@material-ui/icons';

const TimeField = ({ value, name, onChange, ...rest }) => (
  <TimePicker
    error={false}
    size='small'
    value={value}
    helperText={null}
    format='H:m'
    clearable
    onChange={date => {
      onChange(name, date)
    }}
    inputVariant='outlined'
    ampm={false}
    label="Time"
    fullWidth
    InputProps={{
      startAdornment: (
        <InputAdornment position="start">
          <Schedule color='primary'/>
        </InputAdornment>
      )
    }}
    {...rest}
  />
)

export default TimeField
