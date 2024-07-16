import React from "react";
import { connect } from "react-redux";
import { Button, Form, Row, Col } from "react-bootstrap";
import { useNavigate } from "react-router-dom";
import { addToCart, removeFromCart } from "../state/actions";

function PaymentData({ cartProducts, removeFromCart }) {

  const navigate = useNavigate();
  const handleProceedToPayment = async () => {
    for (const product of cartProducts) {
      const currentAvailability = product.availability;
      const newAvailability = currentAvailability - product.quantity;
      console.error("product availabilities:", newAvailability);
      const response = await fetch("http://localhost:5164/api/ProductAvailability/update", {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          availability: newAvailability,
          idProduct: product.id
        }),
      });
      for (let i = 0; i < product.quantity; i++) {
        removeFromCart(product.id)
      }
      if (response.ok) {
        const updatedData = await response.json();
      } else {
        console.error("Failed to update availability");
      }
    }
    navigate('/payment-result/', { state: { fromPayButton: true } });
};

  return (
      <div className="frame_spacing">
        <h2 className="form_title">Payment Data</h2>
        <Form className="between_fields_spacing">
          <Row className="mb-3">
            <Col>
              <Form.Group controlId="cardnumber">
                <Form.Label>Card Number</Form.Label>
                <Form.Control type="text" placeholder="Card Number"/>
              </Form.Group>
            </Col>
            <Col>
              <Form.Group controlId="expirydate">
                <Form.Label>Expiry Date</Form.Label>
                <Form.Control type="text" placeholder="MM/YYYY"/>
              </Form.Group>
            </Col>
          </Row>

          <Row className="mb-3">
            <Col>
              <Form.Group controlId="cvv">
                <Form.Label>CVV</Form.Label>
                <Form.Control type="text" placeholder="CVV"/>
              </Form.Group>
            </Col>
          </Row>
        </Form>
        <div className="centered">
          <Button onClick={handleProceedToPayment} variant="primary" size="lg" type="submit">
            PAY
          </Button>
        </div>
      </div>
  );
}

const mapStateToProps = (state) => {
  return {
    cartProducts: state.cartProducts,
  };
};

const mapDispatchToProps = {
  addToCart,
  removeFromCart,
};
export default connect(mapStateToProps, mapDispatchToProps)(PaymentData);