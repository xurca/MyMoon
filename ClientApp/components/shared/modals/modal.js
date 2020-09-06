import React from 'react';
import Dialog from '@material-ui/core/Dialog';
import Box from '@material-ui/core/Box';
import Divider from '@material-ui/core/Divider';
import * as S from './styles';
import Button from '@material-ui/core/Button';
import Draggable from 'react-draggable';
import Close from '@material-ui/icons/Close';
import Tooltip from '@material-ui/core/Tooltip';
import SubmitButton from '../form-elements/submit-button';
import Typography from '@material-ui/core/Typography';

const Modal = ({
  title,
  height,
  width,
  minWidth = 400,
  minHeight = 200,
  maxWidth = 600,
  maxHeight = 600,
  padding = 2,
  hasActions = true,
  saveText = 'შენახვა',
  cancelText = 'გაუქმება',
  submitting = false,
  onClose,
  onSubmit,
  error,
  children,
  ...rest
}) => {

  return (
    <Dialog
      onClose={onClose}
      maxWidth={false}
      TransitionComponent={Draggable}
      TransitionProps={{ handle: '.modalTitle' }}
      disableScrollLock={true}
      {...rest}
    >
      <S.ModalTitle classes={{ root: 'modalTitle' }}>
        {title}
        <Tooltip title='Close'>
          <S.ModalCloseIcon autoFocus onClick={onClose}>
            <Close/>
          </S.ModalCloseIcon>
        </Tooltip>
      </S.ModalTitle>
      <Divider/>
      <S.ModalContent autoFocus>
        <Box
          p={padding}
          height={height}
          width={width}
          maxWidth={maxWidth}
          minWidth={minWidth}
          minHeight={minHeight}
          maxHeight={maxHeight}
        >
          {children}
        </Box>
      </S.ModalContent>
      {hasActions && (
        <>
          <Divider/>
          <S.Actions>
            <SubmitButton
              onClick={onSubmit}
              text={saveText}
              pending={submitting}
              disabled={!!error}
            />
            <Button
              onClick={onClose}
              variant="outlined"
              color="secondary"
              disabled={submitting}
            >
              <Typography variant='caption' noWrap>
                {cancelText}
              </Typography>
            </Button>
          </S.Actions>
        </>)}
    </Dialog>
  );
};

export default Modal;
