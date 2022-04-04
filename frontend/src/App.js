import Topbar from "./Layouts/Topbar/Topbar";
import Leftbar from "./Layouts/Leftbar/Leftbar";

import { Grid, ThemeProvider  } from "@mui/material";
import React from "react";
import { Routes, Route } from "react-router-dom";
import "./App.css";
import LoginPage from "./Pages/LoginPage/LoginPage";
import ChangePass from "./Pages/UserPage/changepass";
import AssignmentPage from "./Pages/AssignmentPage/AssignmentPage";
import { theme } from "./Assets/Styles/theme";
import HomePage from "./Pages/HomePage/HomePage";
import AssetPage from "./Pages/AssetPage/AssetPage";
import PrivateRoute from './Routes/PrivateRoute'
import AssetDetail from "./Pages/AssetPage/AssetDetail";
function App() {

  return (
    <div className="App">

<ThemeProvider theme={theme}>
      <Topbar />

      <Grid container>
        <Grid item xs={3}>
          <Leftbar />
        </Grid>
        <Grid
          item
          xs={9}
        >         
          <Routes>
          <Route element={<PrivateRoute />}>
           <Route path="/asset-list" element={<AssetPage />} />
            <Route path="/assignment-list" element={<AssignmentPage />} />
        <Route path = "/asset/:id" element={<AssetDetail/>} />
            <Route path="/" element={<HomePage />} />
            <Route path="/changepassword" element={<ChangePass />} />
          </Route>
            <Route path="/login" element={<LoginPage />} />
          </Routes>

        </Grid>
        
      </Grid>
      </ThemeProvider>
    </div>
  )
}

export default App
