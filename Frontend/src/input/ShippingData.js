import React from "react";
import { Button, Form } from "react-bootstrap";

export default function ShippingData() {
  return (
    <>
      <div className="frame_spacing">
        <h2 className="form_title">Shipping Data</h2>
        <Form className="between_fields_spacing">
          <Form.Group className="between_fields_spacing" controlId="name">
            <Form.Label className="text-center">Name</Form.Label>
            <Form.Control type="name" placeholder="Enter name" />
          </Form.Group>
          <Form.Group className="between_fields_spacing" controlId="surname">
            <Form.Label>Surname</Form.Label>
            <Form.Control type="surname" placeholder="Surname" />
          </Form.Group>
          <Form.Group className="between_fields_spacing" controlId="phonenumber">
            <Form.Label>Phone Number</Form.Label>
            <Form.Control type="phonenumber" placeholder="Phone Number" />
          </Form.Group>
          <Form.Group className="between_fields_spacing" controlId="email">
            <Form.Label>E-mail</Form.Label>
            <Form.Control type="email" placeholder="E-mail" />
          </Form.Group>
          <Form.Group className="between_fields_spacing" controlId="country">
            <Form.Label>Country</Form.Label>
            <Form.Control type="country" placeholder="Country" />
          </Form.Group>
          <Form.Group className="between_fields_spacing" controlId="city">
            <Form.Label>City</Form.Label>
            <Form.Control type="city" placeholder="City" />
          </Form.Group>
          <Form.Group className="between_fields_spacing" controlId="adress">
            <Form.Label>Adress</Form.Label>
            <Form.Control type="adress" placeholder="Adress" />
          </Form.Group>
          <Form.Group className="between_fields_spacing" controlId="flat">
            <Form.Label>Flat</Form.Label>
            <Form.Control type="flat" placeholder="Flat" />
          </Form.Group>
          <Form.Group className="between_fields_spacing" controlId="postalcode">
            <Form.Label>Postal Code</Form.Label>
            <Form.Control type="postalcode" placeholder="Postal Code" />
          </Form.Group>
          
        </Form>
      </div>
    </>
  );
}
