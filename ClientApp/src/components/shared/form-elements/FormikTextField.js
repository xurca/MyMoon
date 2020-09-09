import React from 'react';
import { useField } from 'formik';
import TextField from '@material-ui/core/TextField';
import { t } from '../../../lib/helpers'

const FormikTextField = ({ label, required = false, ...props }) => {
  const [field, meta] = useField(props);
  const errorText = meta.error && meta.touched ? meta.error : '';

  return (
    <TextField
      variant="outlined"
      fullWidth
      InputLabelProps={{ required }}
      helperText={errorText !== ' ' && errorText}
      error={!!errorText}
      label={label || t(props.name)}
      {...field}
      value={field.value || ''}
      {...props}
    />
  );
};

export default FormikTextField;
