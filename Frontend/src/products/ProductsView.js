import React, { useState, useEffect } from "react";
import { connect } from "react-redux";
import useGetRequest from "../api/Requests";
import { Row, Col, Card, CardImg, CardTitle, CardSubtitle, CardText, Button, Form, Modal } from "react-bootstrap";
import { addToCart } from "../state/actions";
import "../index.css"; 

function ProductsView({ addToCart }) {
    const [sortCriteria, setSortCriteria] = useState('name/asc');
    const [filterMin, setFilterMin] = useState('0');
    const [filterMax, setFilterMax] = useState('0');
    const [filterMinTemp, setFilterMinTemp] = useState('0');
    const [filterMaxTemp, setFilterMaxTemp] = useState('0');
    
    const [showModal, setShowModal] = useState(false);
    const [selectedProduct, setSelectedProduct] = useState(null);
    const [products, setProducts] = useState([]);

    const data = useGetRequest(`http://localhost:5164/api/Product/sort/${sortCriteria}/${filterMin}/${filterMax}`);

    useEffect(() => {
        const fetchProductAvailabilities = async () => {
            try {
                const response = await fetch("http://localhost:5164/api/ProductAvailability");
                if (!response.ok) {
                    throw new Error("Failed to fetch product availabilities");
                }
                const availabilities = await response.json();
                updateProductsWithAvailability(availabilities);
            } catch (error) {
                console.error("Error fetching product availabilities:", error);
            }
        };

        fetchProductAvailabilities();
    }, [data]);

    const updateProductsWithAvailability = (availabilities) => {
        const updatedProducts = data.map((product) => {
            const availabilityInfo = availabilities.find((item) => item.product.id === product.id);
            const availability = availabilityInfo ? availabilityInfo.availability : 'N/A';
            return { ...product, availability };
        });
        setProducts(updatedProducts);
    };

    const handleCardClick = (product) => {
        
        setSelectedProduct(product);
        setShowModal(true);
    };

    const handleClose = () => {
        setShowModal(false);
        setSelectedProduct(null);
    };

    const handleBuyClick = (event, product) => {
        event.stopPropagation(); 
        if (product.availability > 0) {
            addToCart(product);
            setProducts((prevProducts) =>
                prevProducts.map((p) =>
                    p.id === product.id ? { ...p, availability: p.availability - 1 } : p
                )
            );
        } else {
            alert("No more products available");
        }
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

    const handleFilterSubmit = () => {
        setFilterMin(filterMinTemp || '0');
        setFilterMax(filterMaxTemp || '0');
    };

    const SortForm = () => {
        return (
            <Form>
                <Row className="align-items-center">
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
                    </Col>
                    <Col>
                        <Button variant="primary" size="lg" onClick={handleFilterSubmit} style={{ marginTop: '32px' }}>Filter</Button>
                    </Col>
                </Row>
            </Form>
        );
    };

    return (
        <div >
            <SortForm />
            <Row style={{ padding: '5px' }} xs={1} md={4} className="g-5">
                {products.map((product) => (
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
                                            size="lg"
                                            onClick={(e) => handleBuyClick(e, product)}
                                        >
                                            BUY
                                        </Button>
                                    </Col>
                                </Row>
                                <CardText>Availability: {product.availability !== undefined ? product.availability : 'N/A'}</CardText>
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
                            <CardText>Availability: {selectedProduct.availability !== undefined ? selectedProduct.availability : 'N/A'}</CardText>
                            <CardText>{selectedProduct.description}</CardText>
                        </Card.Body>
                    </Modal.Body>
                    <Modal.Footer>
                        <Button variant="secondary" onClick={handleClose}>
                            Close
                        </Button>
                        <Button variant="primary" size="lg" onClick={(e) => { handleBuyClick(e, selectedProduct); handleClose(); }}>
                            Add to Cart
                        </Button>
                    </Modal.Footer>
                </Modal>
            )}
        </div>
    );
}

const mapDispatchToProps = {
    addToCart,
};

export default connect(null, mapDispatchToProps)(ProductsView);
