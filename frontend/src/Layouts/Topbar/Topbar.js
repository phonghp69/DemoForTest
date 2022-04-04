
import {useNavigate} from 'react-router-dom';
import AppBar from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import Button from '@mui/material/Button';
import Popup from "../../Components/Modal/Popup";
import React, { useEffect, useState } from "react";
function Topbar() {
  const token = localStorage.getItem('token');
  const [openPopup, setOpenPopup] = useState(false);
  
  const navigate = useNavigate();
  function onLogoutClicked() {
    localStorage.setItem('token', '');
    localStorage.setItem('role', '');
    localStorage.setItem('userName', '');
    localStorage.setItem('isFirstLogin', '');
    navigate('/');
    window.location.reload();

  
  }
    return (
    <div>
        <AppBar position="static" color="error">
        <Toolbar sx={{ display: "flex", justifyContent: "space-between" }}>
          <Typography variant="h6" component="div" >
            Home
          </Typography>
          {!token ? (
          <Button color="inherit" href="/login">Login</Button>
           
        ) : (
         
          <Button color="inherit"  onClick={() => setOpenPopup(true)} >
            Logout
          </Button>
         
        )}
         
        </Toolbar>
      </AppBar>
      <Popup
        title="Are you sure?"
        openPopup={openPopup}
        setOpenPopup={setOpenPopup}
      >
        <div>
          <p>Do you want to Log out ?</p>
        </div>
        <Button
          variant="contained"
          color="error"
          onClick={() => {
            setOpenPopup(false);
            onLogoutClicked();
          }}
        >
          Yes
        </Button>
        <Button
          color="secondary"
          onClick={() => {
            setOpenPopup(false);
          }}
        >
          No
        </Button>
      </Popup>
    </div>  
    );
}

export default Topbar;