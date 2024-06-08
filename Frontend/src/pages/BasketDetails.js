import React from "react";
import { connect } from "react-redux";
import { Nav, Navbar } from "react-bootstrap";
// import { useHistory } from "react-router-dom";
import { Col, Container, Image, Row, Button } from "react-bootstrap";
import { addToCart, removeFromCart } from "../state/actions";
import "../index.css"; // Ensure the CSS file is imported

function BasketDetails({ cartProducts, addToCart, removeFromCart }) {
    // const history = useHistory();

    const handleAdd = (product) => {
        addToCart(product);
    };

    const handleDelete = (productId) => {
        removeFromCart(productId);
    };

    // Calculate total cost
    const totalCost = cartProducts.reduce((acc, curr) => acc + (curr.rate * curr.quantity), 0);

    // Function to handle redirection to the payment page
    const goToPayment = () => {
        // history.push("/payment");
    };

    return (
        <Container>
            <Row>
                <Col>
                    <h2>Shopping Cart</h2>
                    {cartProducts.length === 0 ? (
                        <p>Your cart is empty</p>
                    ) : (
                        <>
                            {cartProducts.map((product) => (
                                <div key={product.id} className="mb-3">
                                    <Row>
                                        <Col xs={3}>
                                            <Image
                                                src={product.picture || "./photos/image.png"}
                                                thumbnail
                                                className="small-image"
                                            />
                                        </Col>
                                        <Col xs={6}>
                                            <h4>{product.name}</h4>
                                            <p>Price: {product.rate} PLN</p>
                                            <p>Quantity: {product.quantity}</p>
                                        </Col>
                                        <Col xs={3}>
                                            <Button variant="primary" size="sm" onClick={() => handleAdd(product)}>ADD</Button>
                                            <Button variant="danger" size="sm" onClick={() => handleDelete(product.id)}>DELETE</Button>
                                        </Col>
                                    </Row>
                                </div>
                            ))}
                            <hr />
                            <p>Total Cost: {totalCost.toFixed(2)} PLN</p>
                            <Nav.Link href="/payment">PROCEED TO PAYMENT</Nav.Link>
                        </>
                    )}
                </Col>
            </Row>
        </Container>
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

export default connect(mapStateToProps, mapDispatchToProps)(BasketDetails);
