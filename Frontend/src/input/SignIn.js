import React, { useState, useContext } from "react";
import { Button, Form, Container, Alert } from "react-bootstrap";



export default function SignIn() {

  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [message, setMessage] = useState('');
  const [variant, setVariant] = useState('');

  const handleLogin = async () => {
    const response = await fetch("http://localhost:5164/api/Auth/login", {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify({
            email: {email},
            password: {password}
        }),
    });
    // setMessage('Login successful!');
    // setVariant('success');
    // if (response.ok) {
    //     // const updatedData = await response.json();
    //     setMessage('Login successful!');
    //     setVariant('success');
    //     // alert('Login successful!');
    // } else {
    //     // console.error("Failed to create new product");
    //     setMessage('Login failed!');
    //     setVariant('danger');
    //     // alert('Login failed!');
    // }
};

  
  return (
    <Container>
      <div className="frame_spacing">
        {/* {message && <Alert variant={variant}>{message}</Alert>} */}
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
