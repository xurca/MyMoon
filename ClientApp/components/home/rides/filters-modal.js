import React from 'react';
import Slide from '@material-ui/core/Slide';
import Dialog from '@material-ui/core/Dialog';
import Paper from '@material-ui/core/Paper';
import Toolbar from '@material-ui/core/Toolbar';
import FlexBox from '../../shared/flex-box';
import Button from '@material-ui/core/Button';
import Filters from './filters';

const Transition = React.forwardRef(function Transition(props, ref) {
  return <Slide direction="up" ref={ref} {...props} />;
});

const FiltersModal = ({ handleFilter }) => {
  const [open, setOpen] = React.useState(false);

  const handleOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  return (
    <div>
      <Button
        variant='outlined'
        onClick={handleOpen}
      >
        ფილტრაცია
      </Button>
      <Dialog fullScreen open={open} onClose={handleClose} TransitionComponent={Transition}>
        <Filters/>
        <Paper square variant='outlined' style={{position: 'absolute', bottom: 0, left: 0, right: 0}}>
          <Toolbar>
            <FlexBox justifyContent='space-between' width='100%'>
              <Button
                variant='outlined'
                onClick={handleClose}
              >
                დახურვა
              </Button>
              <Button
                variant='contained'
                color='primary'
                onClick={handleFilter}
              >
                ფილტრაცია
              </Button>
            </FlexBox>
          </Toolbar>
        </Paper>
      </Dialog>
    </div>
  );
};

export default FiltersModal;
