import React from "react";
import { Button, Form, Row, Col } from "react-bootstrap";

export default function PaymentData() {
  return (
    <div className="frame_spacing">
      <h2 className="form_title">Payment Data</h2>
      <Form className="between_fields_spacing">
        <Row className="mb-3">
          <Col>
            <Form.Group controlId="cardnumber">
              <Form.Label>Card Number</Form.Label>
              <Form.Control type="text" placeholder="Card Number" />
            </Form.Group>
          </Col>
          <Col>
            <Form.Group controlId="expirydate">
              <Form.Label>Expiry Date</Form.Label>
              <Form.Control type="text" placeholder="MM/YYYY" />
            </Form.Group>
          </Col>
        </Row>

        <Row className="mb-3">
          <Col>
            <Form.Group controlId="cvv">
              <Form.Label>CVV</Form.Label>
              <Form.Control type="text" placeholder="CVV" />
            </Form.Group>
          </Col>
        </Row>

        <div className="centered">
          <Button variant="primary" size="lg" type="submit">
            PAY
          </Button>
        </div>
      </Form>
    </div>
  );
}
