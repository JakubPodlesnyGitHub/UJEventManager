import React, { useState } from "react";
import { connect } from "react-redux";
import { addToBasket } from "../state/actions";
import { Card, Modal, Button, Row, Col } from "react-bootstrap";
import ProductDescription from "./ProductDescription";
import "../index.css"; // Ensure the CSS file is imported

function Product(props) {
  const [show, setShow] = useState(false);

  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  const handleAddToBasket = () => {
    props.addToBasket(props.product.id);
    setShow(false);
  };

  const availability = props.product.productAvailabilities?.[0]?.availability || 'N/A';

  return (
      <Card style={{ width: "30rem", height: "35rem" }} className="text-center">
        <Card.Body>
          <Button variant="secondary" size="lg" onClick={handleShow}>
            <Card.Img variant="top" src={props.product.picture || "./photos/image.png"} />
          </Button>

          <Card.Title>{props.product.name}</Card.Title>
          <Card.Subtitle>{props.product.codeNumber}</Card.Subtitle>
          <Row className="align-items-center">
            <Col>
              <Card.Text>Rate: {props.product.rate}</Card.Text>
            </Col>
            <Col>
              <Button variant="primary" size="sm" onClick={handleAddToBasket}>
                BUY
              </Button>
            </Col>
          </Row>
          <Card.Text>Availability: {availability}</Card.Text>
          <Card.Text className="small-text">{props.product.description}</Card.Text>
        </Card.Body>

        <Modal
            show={show}
            onHide={handleClose}
            className="text-center"
            size="lg"
            centered
        >
          <Modal.Header closeButton>
            <Modal.Title>{props.product.name}</Modal.Title>
          </Modal.Header>
          <Modal.Body>
            <Card.Img variant="top" src={props.product.picture || "./photos/image.png"} />
            <ProductDescription id={props.product.id}></ProductDescription>
            <Card.Text>Price: {props.product.rate} PLN</Card.Text>
            <Card.Text>Availability: {availability}</Card.Text>
            <Card.Text className="small-text">{props.product.description}</Card.Text>
          </Modal.Body>
          <Modal.Footer className="align-centrally">
            <Button variant="primary" onClick={handleAddToBasket} size="xl">
              BUY NOW
            </Button>
          </Modal.Footer>
        </Modal>
      </Card>
  );
}

const mapStateToProps = (state) => {
  return {
    items_in_basket: state.items_in_basket,
  };
};

const mapDispatchToProps = {
  addToBasket,
};

export default connect(mapStateToProps, mapDispatchToProps)(Product);
