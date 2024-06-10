import React, { useState } from "react";
import { connect } from "react-redux";
import useGetRequest from "../api/Requests";
import { Row, Col, Card, CardImg, CardTitle, CardSubtitle, CardText, Button, Form, Modal } from "react-bootstrap";
import { addToCart } from "../state/actions";
import "../index.css"; // Ensure the CSS file is imported

function ProductsView({ addToCart }) {
    const data = useGetRequest("http://localhost:5164/api/Product");
    const [sortCriteria, setSortCriteria] = useState("name");
    const [minPrice, setMinPrice] = useState("");
    const [maxPrice, setMaxPrice] = useState("");
    const [showModal, setShowModal] = useState(false);
    const [selectedProduct, setSelectedProduct] = useState(null);

    const handleCardClick = (product) => {
        setSelectedProduct(product);
        setShowModal(true);
    };

    const handleClose = () => {
        setShowModal(false);
        setSelectedProduct(null);
    };

    const handleBuyClick = (event, product) => {
        event.stopPropagation(); // Stop the event from propagating to the card's onClick
        addToCart(product);
    };

    const filteredData = data.filter(product => {
        const isAboveMin = minPrice === "" || product.rate >= parseFloat(minPrice);
        const isBelowMax = maxPrice === "" || product.rate <= parseFloat(maxPrice);
        return isAboveMin && isBelowMax;
    });

    const sortedData = filteredData.sort((a, b) => {
        if (sortCriteria === "name") {
            return a.name.localeCompare(b.name);
        } else if (sortCriteria === "price") {
            return a.rate - b.rate;
        }
        return 0;
    });

    return (
        <>
            <Form>
                <Row>
                    <Col>
                        <Form.Group controlId="sortCriteria">
                            <Form.Label>Sort by:</Form.Label>
                            <Form.Control
                                as="select"
                                value={sortCriteria}
                                onChange={(e) => setSortCriteria(e.target.value)}
                            >
                                <option value="name">Name</option>
                                <option value="price">Price</option>
                            </Form.Control>
                        </Form.Group>
                    </Col>
                    <Col>
                        <Form.Group controlId="minPrice">
                            <Form.Label>Min Price:</Form.Label>
                            <Form.Control
                                type="number"
                                placeholder="Min Price"
                                value={minPrice}
                                onChange={(e) => setMinPrice(e.target.value)}
                            />
                        </Form.Group>
                    </Col>
                    <Col>
                        <Form.Group controlId="maxPrice">
                            <Form.Label>Max Price:</Form.Label>
                            <Form.Control
                                type="number"
                                placeholder="Max Price"
                                value={maxPrice}
                                onChange={(e) => setMaxPrice(e.target.value)}
                            />
                        </Form.Group>
                    </Col>
                </Row>
            </Form>
            <Row style={{ padding: '5px' }} xs={1} md={2} className="g-4">
                {sortedData.map((product) => (
                    <Col key={product.id}>
                        <Card onClick={() => handleCardClick(product)}>
                            <CardImg src={product.picture || "./photos/image.png"} />
                            <Card.Body>
                                <CardTitle>{product.name}</CardTitle>
                                <CardSubtitle>{product.codeNumber}</CardSubtitle>
                                <Row className="align-items-center">
                                    <Col>
                                        <CardText>Price: {product.rate} PLN</CardText>
                                    </Col>
                                    <Col>
                                        <Button
                                            variant="primary"
                                            size="sm"
                                            onClick={(e) => handleBuyClick(e, product)}
                                        >
                                            BUY
                                        </Button>
                                    </Col>
                                </Row>
                                <CardText>Availability: {product.productAvailabilities?.[0]?.availability || 'N/A'}</CardText>
                                {/*<CardText className="small-text">{product.description}</CardText>*/}
                            </Card.Body>
                        </Card>
                    </Col>
                ))}
            </Row>

            {selectedProduct && (
                <Modal show={showModal} onHide={handleClose} size="lg">
                    <Modal.Header closeButton>
                        <Modal.Title>{selectedProduct.name}</Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <CardImg src={selectedProduct.picture || "./photos/image.png"} className="img-fluid" />
                        <Card.Body>
                            <CardTitle>{selectedProduct.name}</CardTitle>
                            <CardSubtitle>{selectedProduct.codeNumber}</CardSubtitle>
                            <CardText>Price: {selectedProduct.rate} PLN</CardText>
                            <CardText>Availability: {selectedProduct.productAvailabilities?.[0]?.availability || 'N/A'}</CardText>
                            <CardText>{selectedProduct.description}</CardText>
                        </Card.Body>
                    </Modal.Body>
                    <Modal.Footer>
                        <Button variant="secondary" onClick={handleClose}>
                            Close
                        </Button>
                        <Button variant="primary" onClick={() => { addToCart(selectedProduct); handleClose(); }}>
                            Add to Cart
                        </Button>
                    </Modal.Footer>
                </Modal>
            )}
        </>
    );
}

const mapDispatchToProps = {
    addToCart,
};

export default connect(null, mapDispatchToProps)(ProductsView);
