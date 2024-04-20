import React from "react";
import { connect } from "react-redux";
import { addToBasket } from "../state/actions";
import { Card, Modal } from "react-bootstrap";
import { useState } from "react";
import ProductDescription from "./ProductDescription";

import { Button } from "react-bootstrap";

function Product(props) {
  const [show, setShow] = useState(false);

  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  const handleAddToBasket = () => {
    props.addToBasket(props.product["id"]);
    setShow(false);
  };

  return (

    <Card style={{ width: "30rem", height: "35rem" }} className="text-center">
      <Button style={{ width: "30rem", height: "35rem" }} variant="secondary" size="lg" onClick={handleShow}>
      <Card.Body>
          <Card.Img variant="top" src={props.product["picture"]}  />
        <Card.Title >{props.product["name"]}</Card.Title>
      </Card.Body>
      </Button>


      <Modal
        show={show}
        onHide={handleClose}
        className="text-center"
        size="lg"
        centered
      >
        <Modal.Header closeButton>
          <Modal.Title>{props.product["name"]}</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Card.Img variant="top" src={props.product["picture"]} />
          <ProductDescription id={props.product["id"]}></ProductDescription>
        </Modal.Body>
        <Modal.Footer variant="centred" className="allign_centrally">
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
