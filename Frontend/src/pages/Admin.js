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
    const [newProductName, setNewProductName] = useState(""); // Add state for new product name
    const [newProductCodeNumber, setNewProductCodeNumber] = useState("");
    const [newProductDescription, setNewProductDescription] = useState("");
    const [newProductRate, setNewProductRate] = useState("");

    // Function to create a new product
    const createNewProduct = async () => {
        const response = await fetch("http://localhost:5164/api/Product/create", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify({
                name: newProductName,
                codeNumber: newProductCodeNumber, // Add other properties as needed
                seriesNumber: "string",
                description: newProductDescription,
                picture: "string",
                rate: newProductRate,
                releaseDate: new Date().toISOString(),
            }),
        });
        if (response.ok) {
            const updatedData = await response.json();
        } else {
            console.error("Failed to create new product");
        }
    };

    const putProduct = async (id, oldName, oldCategory, oldCodeNumber, oldSeriesNumber, oldDescription, oldPicture) => {
        const response = await fetch("http://localhost:5164/api/Product/update", {
            method: "PUT",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify({
                id: id,
                name: newProductName || oldName,
                category: "string",
                codeNumber: newProductCodeNumber || oldCodeNumber, // Add other properties as needed
                seriesNumber: oldSeriesNumber,
                description: newProductDescription || oldDescription,
                picture: "string",
                rate: newProductRate,
                releaseDate: new Date().toISOString(),
            }),
        });
        if (response.ok) {
        } else {
            console.error("Failed to put product");
        }
    };

    const deleteProduct = async (id) => {
        const response = await fetch(`http://localhost:5164/api/Product/` + id + '/delete', {
            method: "DELETE",
        });
        if (response.ok) {
        } else {
            console.error("Failed to delete product " + id);
        }
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
            <Form>
 
                {/* Input field for new product name */}
                <Row>
                    <Col>
                        <Form.Group controlId="newProductName">
                            <Form.Label>New Product Name:</Form.Label>
                            <Form.Control
                                type="text"
                                placeholder="Enter product name"
                                value={newProductName}
                                onChange={(e) => setNewProductName(e.target.value)}
                            />
                        </Form.Group>
                    </Col>
                    <Col>
                        <Form.Group controlId="newProductCodeNumber">
                            <Form.Label>New Product Code Number:</Form.Label>
                            <Form.Control
                                type="text"
                                placeholder="Enter code number"
                                value={newProductCodeNumber}
                                onChange={(e) => setNewProductCodeNumber(e.target.value)}
                            />
                        </Form.Group>
                    </Col>
                    <Col>
                        <Form.Group controlId="newProductDescription">
                            <Form.Label>New Product Description:</Form.Label>
                            <Form.Control
                                type="text"
                                placeholder="Enter description"
                                value={newProductDescription}
                                onChange={(e) => setNewProductDescription(e.target.value)}
                            />
                        </Form.Group>
                    </Col>
                </Row>
                <Row>
                    <Col>
                        <Form.Group controlId="newProductRate">
                            <Form.Label>New Product Rate:</Form.Label>
                            <Form.Control
                                type="number"
                                placeholder="Enter price"
                                value={newProductRate}
                                onChange={(e) => setNewProductRate(e.target.value)}
                            />
                        </Form.Group>
                        <Button variant="primary" onClick={createNewProduct}>
                            Add New Product
                        </Button>
                    </Col>
                </Row>
            </Form>
            <Row style={{ padding: '5px' }} xs={1} md={2} className="g-4">
                {data.map((product) => (
                    <Col key={product.id}>
                        <Card onClick={() => handleCardClick(product)}>
                            <CardImg src={product.picture || "./photos/image.png"} />
                            <Card.Body>
                                <Form>
                                    <Row className="align-items-center">
                                        <Col>
                                            <CardText>{product.name}</CardText>
                                        </Col>
                                    </Row>
                                    <Row className="align-items-center">
                                        <Col>
                                            <CardText>{product.codeNumber}</CardText>
                                        </Col>
                                    </Row>
                                    <Row className="align-items-center">
                                        <Col>
                                            <CardText>Price: {product.rate} PLN</CardText>
                                        </Col>
                                    </Row>
                                    <Row className="align-items-center">
                                        <Col>
                                            <CardText>{product.description}</CardText>
                                        </Col>
                                    </Row>
                                    <Button variant="primary" onClick={() => putProduct(product.id, product.name, product.category, product.codeNumber, product.seriesNumber, product.description, product.picture)}>
                                        Change product data
                                    </Button>
                                    <Button variant="danger" onClick={() => deleteProduct(product.id)}>Delete</Button>
                                </Form>
                            </Card.Body>
                        </Card>
                    </Col>
                ))}
            </Row>
        </>
    );
}

const mapDispatchToProps = {
    addToCart,
};

export default connect(null, mapDispatchToProps)(ProductsView);
