import React from "react";
import { Container, Image, Row, Col } from "react-bootstrap";

function Basket({ cartProducts }) {
    // Calculate total cost
    const totalCost = cartProducts.reduce((acc, curr) => acc + (curr.rate * curr.quantity), 0);

    return (
        <Container>
            <Row className="align-items-center">
                <Col xs="auto" className="pr-1">
                    {/* Use the correct path to the image */}
                    <Image src="/photos/card.svg" alt="Basket Icon" />
                </Col>
                <Col>
                    {/* Display the total cost */}
                    <p className="allign_centrally">Total Cost: {totalCost.toFixed(2)} PLN</p>
                </Col>
            </Row>
        </Container>
    );
}

export default Basket;
