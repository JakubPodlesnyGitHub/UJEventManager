import React from "react";
import { connect } from "react-redux";
// import { useHistory } from "react-router-dom";
import {Col, Container, Image, Row, Button, Nav} from "react-bootstrap";
import { addToCart, removeFromCart } from "../state/actions";
import "../index.css";
import FormWindow from "../input/FormWindow";
import ShippingData from "../input/ShippingData";
import PaymentData from "../input/PaymentData";

function Payment({ cartProducts}) {
  
    const totalCost = cartProducts.reduce((acc, curr) => acc + (curr.rate * curr.quantity), 0);

    return <>{FormWindow(Array.from([<ShippingData />, <PaymentData />]))}</>;
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

export default connect(mapStateToProps, mapDispatchToProps)(Payment);
