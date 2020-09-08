import { ENDPOINT_REGISTER } from '../../../lib/endpoints';
import axios from 'axios';
import { useMutation } from 'react-query';

const signup = user => {
  axios.post(ENDPOINT_REGISTER, user)
}

export const useSignup = () => useMutation(signup)
