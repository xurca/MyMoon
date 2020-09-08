import React from 'react';
import Typography from '@material-ui/core/Typography';
import Button from '@material-ui/core/Button';
import { FaLongArrowAltLeft } from 'react-icons/fa';
import Box from '@material-ui/core/Box';
import Link from '@material-ui/core/Link';
import { useSignup } from './hooks/useSignup';
import { Form, Formik } from 'formik';
import FormikTextField from '../shared/form-elements/FormikTextField';
import * as Yup from 'yup';

const initialValues = {
  firstName: '',
  lastName: '',
  email: '',
  password: '',
  confirmPassword: ''
};

const SignupSchema = Yup.object().shape({
  firstName: Yup.string()
    .min(2, 'ძალიან მოკლეა')
    .max(50, 'ძალიან გრძელია')
    .required(' '),
  lastName: Yup.string()
    .min(2, 'ძალიან მოკლეა')
    .max(50, 'ძალიან გრძელია')
    .required(' '),
  email: Yup.string()
    .email('მეილის ფორმატი არასწორია')
    .required(' '),
  password: Yup.string()
    .required(' ')
    .min(8, 'პაროლი უნდა შედგებოდეს მინიმუმ 8 სიმბოლოსგან'),
  confirmPassword: Yup.string()
    .oneOf([Yup.ref('password'), null], 'პაროლი არ ემთხვევა')
    .required(' ')
});

const Signup = ({ setType }) => {
  const [handleSignup] = useSignup();

  const handleSubmit = values => {
    handleSignup(values);
  };

  return (
    <Formik
      initialValues={initialValues}
      onSubmit={handleSubmit}
    >
      <Form>
        <div style={{ position: 'absolute', top: 16, left: 16 }}>
          <Button
            startIcon={<FaLongArrowAltLeft/>}
            color='primary'
            onClick={() => setType('login')}
          >
            login
          </Button>
        </div>
        <Box mb={2} width='100%'>
          <Typography component="h1" variant="h6" align='center' gutterBottom>
            რეგისტრაცია
          </Typography>
        </Box>
        <FormikTextField
          name="email"
          id="email"
          label="ელ. ფოსტა"
          autoComplete="email"
          autoFocus
          required
          style={{ marginBottom: 12 }}
        />
        <FormikTextField
          name="password"
          label="პაროლი"
          type="password"
          id="password"
          autoComplete="current-password"
          required
          style={{ marginBottom: 12 }}
        />
        <FormikTextField
          name="confirmPassword"
          label="გაიმეორეთ პაროლი"
          type="password"
          id="repeatPassword"
          autoComplete="current-password"
          required
          style={{ marginBottom: 12 }}
        />
        <Box mb={1}>
          <Typography variant='body2' align='center'>
            საიტზე რეგისტრაციით თქვენ ეთახმებით ჩვენს <br/>
            <Link href='#' underline='always'>წესებსა და პირობებს</Link>
          </Typography>
        </Box>
        <Button
          type="submit"
          fullWidth
          variant="contained"
          color="primary"
          size='large'
        >
          რეგისტრაცია
        </Button>
      </Form>
    </Formik>
  );
};

export default Signup;
