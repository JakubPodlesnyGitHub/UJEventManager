import React from "react";
import { connect } from "react-redux";
import useGetRequest from "../api/Requests";
import { Row, Col, Card, CardImg, CardTitle, CardSubtitle, CardText, Button } from "react-bootstrap";
import { addToCart } from "../state/actions";
import "../index.css"; // Ensure the CSS file is imported

function ProductsView({ addToCart }) {
    const data = useGetRequest("http://localhost:5164/api/Product");

    return (
        <Row style={{ padding: '5px' }} xs={1} md={2} className="g-4">
            {data.map((product) => (
                <Col key={product.id}>
                    <Card>
                        <CardImg src={product.picture || "./photos/image.png"} />
                        <Card.Body>
                            <CardTitle>{product.name}</CardTitle>
                            <CardSubtitle>{product.codeNumber}</CardSubtitle>
                            <Row className="align-items-center">
                                <Col>
                                    <CardText>Price: {product.rate} PLN</CardText>
                                </Col>
                                <Col>
                                    <Button variant="primary" size="sm" onClick={() => addToCart(product)}>
                                        BUY
                                    </Button>
                                </Col>
                            </Row>
                            <CardText>Availability: {product.productAvailabilities?.[0]?.availability || 'N/A'}</CardText>
                            <CardText className="small-text">{product.description}</CardText>
                        </Card.Body>
                    </Card>
                </Col>
            ))}
        </Row>
    );
}

const mapDispatchToProps = {
    addToCart,
};

export default connect(null, mapDispatchToProps)(ProductsView);
