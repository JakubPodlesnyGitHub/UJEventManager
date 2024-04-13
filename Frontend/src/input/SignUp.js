import React from "react";
import { Button, Form } from "react-bootstrap";

export default function SignUp() {
  return (
    <div className="frame_spacing">
      <h2 className="form_title">Sign up</h2>
      <Form className="between_fields_spacing">
        <Form.Group className="between_fields_spacing" controlId="name">
          <Form.Label className="text-center">Name</Form.Label>
          <Form.Control type="text" placeholder="Enter Your name" />
        </Form.Group>
        <Form.Group className="between_fields_spacing" controlId="email">
          <Form.Label className="text-center">Email address</Form.Label>
          <Form.Control type="email" placeholder="Enter email" />
        </Form.Group>
        <Form.Group className="between_fields_spacing" controlId="password">
          <Form.Label>Password</Form.Label>
          <Form.Control type="password" placeholder="Password" />
        </Form.Group>
        <div className="centered">
          <Button variant="primary" size="lg" type="submit">
            SIGN UP
          </Button>
        </div>
      </Form>
    </div>
  );
}
