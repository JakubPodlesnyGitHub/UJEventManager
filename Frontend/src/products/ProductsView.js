import React, { useState } from "react";
import { connect } from "react-redux";
import useGetRequest from "../api/Requests";
import { Row, Col, Card, CardImg, CardTitle, CardSubtitle, CardText, Button, Form, Modal } from "react-bootstrap";
import { addToCart } from "../state/actions";
import "../index.css"; // Ensure the CSS file is imported

function ProductsView({ addToCart }) {
    const [sortCriteria, setSortCriteria] = useState('name/asc');
    const [filterMin, setFilterMin] = useState('0');
    const [filterMax, setFilterMax] = useState('0');
    const [filterMinTemp, setFilterMinTemp] = useState('0');
    const [filterMaxTemp, setFilterMaxTemp] = useState('0');
    const data = useGetRequest(`http://localhost:5164/api/Product/sort/${sortCriteria}/${filterMin}/${filterMax}`);
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

    const handleSortChange = (event) => {
        setSortCriteria(event.target.value);
    };

    const handleMinChange = (event) => {
        setFilterMinTemp(event.target.value); 
    };

    const handleMaxChange = (event) => {
        setFilterMaxTemp(event.target.value);
    };

    const handleMinSubmit = () => {
        if (filterMinTemp == '') {
            setFilterMin(0);
        } else {
            setFilterMin(filterMinTemp);
        }
    };

    const handleMaxSubmit = () => {
        if (filterMaxTemp == '') {
            setFilterMax(0);
        } else {
            setFilterMax(filterMaxTemp);
        }
    };
    const SortForm = () => {
        return (
            <Form>
                <Row>
                    <Col>
                        <Form.Group controlId="sortCriteria">
                            <Form.Label>Sort by:</Form.Label>
                            <Form.Control as="select" value={sortCriteria} onChange={handleSortChange}>
                                <option value="name/asc">Name (Ascending)</option>
                                <option value="rate/asc">Price (Ascending)</option>
                                <option value="name/desc">Name (Descending)</option>
                                <option value="rate/desc">Price (Descending)</option>
                            </Form.Control>
                        </Form.Group>
                    </Col>
                    <Col>
                        <Form.Group controlId="doubleInput">
                            <Form.Label>Set minimum price:</Form.Label>
                            <Form.Control
                                type="number"
                                step="any"
                                value={filterMinTemp} 
                                onChange={handleMinChange}
                                required
                            />
                        </Form.Group>
                        <Button variant="primary" onClick={handleMinSubmit}>Accept</Button>
                    </Col>
                    <Col>
                        <Form.Group controlId="doubleInput">
                            <Form.Label>Set maximum price:</Form.Label>
                            <Form.Control
                                type="number"
                                step="any"
                                value={filterMaxTemp} 
                                onChange={handleMaxChange} 
                                required
                            />
                        </Form.Group>
                        <Button variant="primary" onClick={handleMaxSubmit}>Accept</Button>
                    </Col>
                </Row>
            </Form>
        );
    };

    return (
        <>
            <SortForm />
            <Row style={{ padding: '5px' }} xs={1} md={2} className="g-4">
                {data.map((product) => (
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
