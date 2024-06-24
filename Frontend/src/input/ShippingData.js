import React from "react";
import { Form, Col, Row } from "react-bootstrap";

export default function ShippingData() {
  return (
    <div className="frame_spacing">
      <h2 className="form_title">Shipping Data</h2>
      <Form className="between_fields_spacing">
        <Row className="mb-3">
          <Col>
            <Form.Group controlId="name">
              <Form.Label>Name</Form.Label>
              <Form.Control type="text" placeholder="Enter name" />
            </Form.Group>
          </Col>
          <Col>
            <Form.Group controlId="surname">
              <Form.Label>Surname</Form.Label>
              <Form.Control type="text" placeholder="Surname" />
            </Form.Group>
          </Col>
        </Row>

        <Row className="mb-3">
          <Col>
            <Form.Group controlId="phonenumber">
              <Form.Label>Phone Number</Form.Label>
              <Form.Control type="tel" placeholder="Phone Number" />
            </Form.Group>
          </Col>
          <Col>
            <Form.Group controlId="email">
              <Form.Label>Email</Form.Label>
              <Form.Control type="email" placeholder="Email" />
            </Form.Group>
          </Col>
        </Row>

        <Row className="mb-3">
          <Col>
            <Form.Group controlId="country">
              <Form.Label>Country</Form.Label>
              <Form.Control type="text" placeholder="Country" />
            </Form.Group>
          </Col>
          <Col>
            <Form.Group controlId="city">
              <Form.Label>City</Form.Label>
              <Form.Control type="text" placeholder="City" />
            </Form.Group>
          </Col>
        </Row>

        <Row className="mb-3">
          <Col>
            <Form.Group controlId="adress">
              <Form.Label>Address</Form.Label>
              <Form.Control type="text" placeholder="Address" />
            </Form.Group>
          </Col>
          <Col>
            <Form.Group controlId="flat">
              <Form.Label>Flat</Form.Label>
              <Form.Control type="text" placeholder="Flat" />
            </Form.Group>
          </Col>
        </Row>

        <Row className="mb-3">
          <Col>
            <Form.Group controlId="postalcode">
              <Form.Label>Postal Code</Form.Label>
              <Form.Control type="text" placeholder="Postal Code" />
            </Form.Group>
          </Col>
        </Row>
      </Form>
    </div>
  );
}
