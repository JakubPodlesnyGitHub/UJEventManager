import React from "react";
import { connect } from "react-redux";
import { Container, Nav, Navbar } from "react-bootstrap";
import Basket from "./Basket";

const Bar = ({ cartProducts }) => {
    return (
        <Navbar className="navbar">
            <Container>
                <Nav.Link href="/">HOME</Nav.Link>
                <Navbar.Collapse className="justify-content-end">
                    <Nav.Link href="/shopping-cart">
                        <Basket cartProducts={cartProducts} />
                    </Nav.Link>
                    <div className="bar_line"></div>
                    <Nav.Link href="/auth">LOG IN / SIGN UP</Nav.Link>
                </Navbar.Collapse>
            </Container>
        </Navbar>
    );
};

const mapStateToProps = (state) => ({
    cartProducts: state.cartProducts,
});

export default connect(mapStateToProps)(Bar);
