import React from 'react';
import { Formik } from 'formik';

const Form = ({
  children,
  onSubmit,
  initialValues,
}) => {
  const validate = (values) => {

  };

  const handleSubmit = (values, { setSubmitting }) => {
    setTimeout(() => {
      onSubmit(values);
      setSubmitting(false);
      console.log(values);
    }, 1000);
  };

  return (
    <Formik
      initialValues={initialValues}
      validate={validate}
      onSubmit={handleSubmit}
    >
      {({
        handleSubmit,
      }) => (
        <form onSubmit={handleSubmit}>
          {children}
        </form>
      )}
    </Formik>
  );
};

export default Form;
