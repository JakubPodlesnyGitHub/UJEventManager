import React from "react";
import { Button, Form } from "react-bootstrap";

export default function SignIn() {
  return (
    <>
      <div className="frame_spacing">
        <h2 className="form_title">Payment Data</h2>
        <Form className="between_fields_spacing">
          <Form.Group className="between_fields_spacing" controlId="cardnumber">
            <Form.Label className="text-center">Card Number</Form.Label>
            <Form.Control type="cardnumber" placeholder="Card Number" />
          </Form.Group>
          <Form.Group className="between_fields_spacing" controlId="expirydate">
            <Form.Label>Expiry Date</Form.Label>
            <Form.Control type="expirydate" placeholder="Expiry Date" />
          </Form.Group>
          <Form.Group className="between_fields_spacing" controlId="cvv">
            <Form.Label>CVV</Form.Label>
            <Form.Control type="cvv" placeholder="CVV" />
          </Form.Group>
          <div className="centered">
            <Button variant="primary" size="lg" type="submit">
              PAY
            </Button>
          </div>
        </Form>
      </div>
    </>
  );
}
