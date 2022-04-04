import axios from "axios";
import React, { useState } from "react";
import "../LoginPage/login.css";
import { Button, Form } from "react-bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";
import Popup from "../../Components/Modal/Popup";

const ChangePass = () => {
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
      url: "",
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
      <Popup
        title="Change Password !"
        openPopup={openPopup}
        setOpenPopup={setOpenPopup}
      >
        <div>
          <Form.Control
            type="password"
            placeholder="Old Password"
            className="form-control"
            id="title"
            name="password"
            value={data.password}
            onChange={(e) => handle(e)}
            required
          />
        </div>

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
        <div>
          <Form.Control
            type="password"
            placeholder="Confirm New Password"
            className="form-control"
            id="title"
            name="password"
            value={data.password}
            onChange={(e) => handle(e)}
            required
          />
        </div>

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
    </div>
  );
};
export default ChangePass;
