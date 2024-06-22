import React, { useContext } from "react";
import { connect } from "react-redux";
import { Container, Nav, Navbar, Button } from "react-bootstrap";
import Basket from "./Basket";
import { AuthContext } from "../context/AuthContext";

const Bar = ({ cartProducts }) => {
    const { userData, logout } = useContext(AuthContext);


    return (
        <Navbar className="navbar">
            <Container >
                <Nav.Link className="home" href="/">HOME</Nav.Link>
                <Navbar.Collapse className="justify-content-end">
                    <Nav.Link className="shopping-cart" href="/shopping-cart">
                        <Basket cartProducts={cartProducts} />
                    </Nav.Link>
                </Navbar.Collapse>
            </Container>
            <div className="bar_line"></div>
            {userData ? (
                        <div className="user-info">
                            <span className="username">{`You are logged with role ${userData.role} as: ${userData.username}`}</span>
                            <div className="bar_line"></div>
                            <Nav.Link className="logout-btn" onClick={logout}>LOG OUT</Nav.Link>
                        </div>
                    ) : (
                        <Nav.Link href="/auth">LOG IN / SIGN UP</Nav.Link>
                    )}
        </Navbar>
    );
};

const mapStateToProps = (state) => ({
    cartProducts: state.cartProducts,
});

export default connect(mapStateToProps)(Bar);
