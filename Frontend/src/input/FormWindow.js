import React from "react";
import { Col, Row, Container, Card } from "react-bootstrap";

export default function FormWindow(fields) {
  return (
    <Container className="centred_form">
      <Row className="centred_form">
        <Col>
          <div className="window_line" />
          <Card className="shadow">
            <Card.Body>{fields}</Card.Body>
          </Card>
        </Col>
      </Row>
    </Container>
  );
}
