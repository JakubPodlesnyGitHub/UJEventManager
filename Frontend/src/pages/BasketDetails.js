import React from "react";
import { connect } from "react-redux";
import { Nav, Navbar } from "react-bootstrap";
// import { useHistory } from "react-router-dom";
import { Col, Container, Image, Row, Button, Card } from "react-bootstrap";
import { addToCart, removeFromCart } from "../state/actions";
import "../index.css"; // Ensure the CSS file is imported
import "./BasketDetails.css";

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
            <Row className="my-4">
                <Col>
                    <h2>Shopping Cart</h2>
                    {cartProducts.length === 0 ? (
                        <p>Your cart is empty</p>
                    ) : (
                        <>
                            {cartProducts.map((product) => (
                                <Card key={product.id} className="mb-3">
                                    <Card.Body>
                                        <Row className="align-items-center">
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
                                            <Col xs={2} className="d-flex justify-content-around">
                                                <Button
                                                    variant="primary"
                                                    // size="lg"
                                                    // className="mb-4"
                                                    className="custom-btn"
                                                    style={{ width: "40%", height: "60px" }}
                                                    onClick={() => handleAdd(product)}
                                                >
                                                    Add
                                                </Button>
                                                <Button
                                                    variant="danger"
                                                    // size="lg"
                                                    className="custom-btn"
                                                    style={{ width: "40%", height: "60px" }}
                                                    onClick={() => handleDelete(product.id)}
                                                >
                                                    Delete
                                                </Button>
                                            </Col>
                                        </Row>
                                    </Card.Body>
                                </Card>
                            ))}
                            <hr />
                            <div className="d-flex justify-content-between align-items-center">
                                <h3>Total Cost: {totalCost.toFixed(2)} PLN</h3>
                                <Nav.Link href="/payment" className="btn btn-success btn-lg btn-payment">
                                    PROCEED TO PAYMENT
                                </Nav.Link>
                            </div>
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
