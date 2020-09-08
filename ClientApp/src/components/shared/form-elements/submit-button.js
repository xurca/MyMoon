import Button from '@material-ui/core/Button/Button';
import React from 'react';
import * as S from './styles';
import Typography from '@material-ui/core/Typography';

const SubmitButton = ({
  text,
  pending,
  disabled,
  color = 'primary',
  onClick,
  ...rest
}) => {
  return (
    <S.SubmitButtonWrapper>
      <Button
        type="submit"
        variant="contained"
        color={color}
        disabled={disabled || pending}
        onClick={onClick}
        {...rest}
      >
        <Typography variant='caption' noWrap>
          {text}
        </Typography>
      </Button>
      {pending && <S.SubmitButtonProgress size={24}/>}
    </S.SubmitButtonWrapper>
  );
};

export default SubmitButton;
