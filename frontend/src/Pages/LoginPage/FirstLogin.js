import axios from "axios";
import React, { useState } from "react";
import "./login.css";
import { Button, Form } from "react-bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";
import Popup from "../../Components/Modal/Popup";
import Paper from "@mui/material/Paper";

const FirstLogin = () => {
  const [setIsModalVisible] = useState(true);
  const [openPopup, setOpenPopup] = useState(true);
  const token = localStorage.getItem("token");
  const username = localStorage.getItem("userName");
  const [data, setData] = useState({
    username: username,
    password: "",
  });
  const submit = () => {
    axios({
      method: "PUT",
      url: `${process.env.Backend_URI}/first-login`,
      data: data,
      headers: {
        Authorization: `Bearer ${token}`,
      },
    })
      .then((res) => {
        console.log(res);
        setIsModalVisible(false);
      })
      .catch((err) => console.error(err));
  };
  const handle = (e) => {
    const newdata = { ...data };
    newdata[e.target.name] = e.target.value;
    setData(newdata);
  };
  return (
    <div className="App">
      <Paper elevation={3}>
        <Popup
          color="error"
          title="You must change password in first login !"
          openPopup={openPopup}
          setOpenPopup={setOpenPopup}
        >
          <p>This is the first time you logged in </p>
          <p>You have to change password to continue</p>
          <div>
            <Form.Control
              type="password"
              placeholder="New Password"
              className="form-control"
              id="title"
              name="password"
              value={data.password}
              onChange={(e) => handle(e)}
              required
            />
          </div>
          <br />
          <Button
            className="btn btn-danger"
            onClick={() => {
              setOpenPopup(false);
              submit();
            }}
          >
            Save
          </Button>
        </Popup>
      </Paper>
    </div>
  );
};
export default FirstLogin;
