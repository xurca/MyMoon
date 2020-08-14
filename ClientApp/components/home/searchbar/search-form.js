import React, { useState } from 'react';
import Hidden from '@material-ui/core/Hidden';
import Form from '../../shared/form-elements/form';
import SearchFormView from './search-form-view';
import { SearchFormViewResponsive } from './search-form-view-responsive';

const SearchForm = () => {
  const [values, setValues] = useState({
    from: '',
    to: '',
    date: '',
    time: ''
  })

  const handleSubmit = event => {
    event.preventDefault()
    console.log(values)
  }

  const setFieldValue = (name, value) => {
    setValues(prevState => ({
      ...prevState,
      [name]: value
    }))

    console.log(name, value)
  }

  const handleChange = event => {
    const { name, value } = event.target
    console.log(name, value)
    setFieldValue(name, value)
  }

  return (
    <form onSubmit={handleSubmit}>
      <Hidden smDown>
        <SearchFormView
          values={values}
          setFieldValue={setFieldValue}
          onChange={handleChange}
        />
      </Hidden>
      <Hidden mdUp>
        <SearchFormViewResponsive
          values={values}
          setFieldValue={setFieldValue}
          onChange={handleChange}
        />
      </Hidden>
    </form>
  );
};

export default SearchForm;
