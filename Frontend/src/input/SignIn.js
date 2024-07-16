import React, { useState, useContext } from "react";
import { Button, Form, Container, Alert } from "react-bootstrap";
import { AuthContext } from "../context/AuthContext";
import { useNavigate } from "react-router-dom";


export default function SignIn() {

  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  //login fail/success message
  const [message, setMessage] = useState('');
  const [variant, setVariant] = useState('');
  const [showAlert, setShowAlert] = useState(false);

  const { login } = useContext(AuthContext);
  const navigate = useNavigate();

  const handleLogin = async (e) => {
    e.preventDefault();
    const response = await fetch("http://localhost:5164/api/Auth/login", {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify({
            email: email,
            password: password
        }),
    });

    if (response.ok) {
        const data = await response.json();
        console.log(data)
        if (Boolean(data.isSucceded)) {
          setMessage('Login successful!');
          setVariant('success');
          setShowAlert(true);
          
          login(data.token);
          navigate("/p5/");
        } else {
          setMessage(data.errorDetails);
          setVariant('danger');
          setShowAlert(true);
        }
    } else {
        setMessage('Login failed!');
        setVariant('danger');
        setShowAlert(true);
    }
};

  
  return (
    <Container>
      <div className="frame_spacing">
        {message && <Alert variant={variant} onClose={() => setShowAlert(false)} dismissible>{message}</Alert>}
        <h2 className="form_title">Sign in</h2>
        <Form className="between_fields_spacing" onSubmit={handleLogin}>
          <Form.Group className="between_fields_spacing" controlId="email">
            <Form.Label className="text-center">Email address</Form.Label>
            <Form.Control type="email" placeholder="Enter email" value={email} onChange={(e) => setEmail(e.target.value)} required/>
          </Form.Group>
          <Form.Group className="between_fields_spacing" controlId="password">
            <Form.Label>Password</Form.Label>
            <Form.Control type="password" placeholder="Password" value={password} onChange={(e) => setPassword(e.target.value)} required/>
          </Form.Group>
          <div className="centered">
            <Button variant="primary" size="lg" type="submit">
              SIGN IN
            </Button>
          </div>
        </Form>
      </div>
    </Container>
  );
}
