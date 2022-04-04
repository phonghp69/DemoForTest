import React, {  useState } from "react";
import { useNavigate } from 'react-router-dom';
import authService from "../../Services/auth-service";
import 'bootstrap/dist/css/bootstrap.min.css';
import { Button, Form, Col } from 'react-bootstrap';
import './login.css';
import Paper from '@mui/material/Paper';
const Login = () => {
    const [userName, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [errMessage, setErrMessage] = useState("");

    const navigate = useNavigate();


    const handleLogin = async (e) => {
        e.preventDefault();
        try {
            await authService.login(userName, password).then(
                (response) => {
                    localStorage.setItem("token", response.token);                 
                    localStorage.setItem("userName",response.userName);
                    localStorage.setItem("role", response.role);
                    localStorage.setItem("isFirstLogin",response.isFistLogin);
                   
                    navigate('/');
                    window.location.reload();
                },
                (error) => {
                    if (error?.response.status === 400) { setErrMessage("Username or password is incorrect. Please try again?") }
                }
            )
        } catch (err) {
            console.log(err)
        }
    }

    return (
       
        <div className="App">
           <div className="card-body">
            {localStorage.getItem("token") ?
                (<div style={{ color: 'red', fontSize: '30px', fontWeight: 'bold' }}>You're Login</div>) :
                ( 
                <Form onSubmit={handleLogin}>
                   <lable style={{ fontSize: '30px', fontWeight: 'bold'}}>Login</lable>
                    <Form.Group className="mb-3" controlId="formBasicEmail">
                        <div className="center_Form">
                            <Col sm={3}>
                               
                                <Form.Control
                                    placeholder="Enter Username"
                                    type="text"
                                    name="username"
                                    value={userName}
                                    onChange={(e) => setUsername(e.target.value)}
                                    required />
                            </Col>
                        </div>
                    </Form.Group>

                    <Form.Group className="mb-3" controlId="formBasicPassword">
                        <div className="center_Form">
                            <Col sm={3} >
                                <Form.Control
                                    type="password"
                                    name="password"
                                    value={password}
                                    onChange={(e) => setPassword(e.target.value)}
                                    placeholder="Password"
                                    required />
                            </Col>
                        </div>
                    </Form.Group>
                    <label style={{ color: 'red', fontSize: '15px', fontWeight: 'bold' }}>{errMessage}</label>
                    <div>
                        <Button variant="primary" type="submit">
                            Login
                        </Button>
                    </div>
                </Form>
                 )}
        </div>
        </div>
       
    )
}
export default Login;