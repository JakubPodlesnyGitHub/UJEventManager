import React, { useContext } from "react";
import { connect } from "react-redux";
import { Container, Nav, Navbar, Button } from "react-bootstrap";
import Basket from "./Basket";
import { AuthContext } from "../context/AuthContext";
import { useNavigate, useLocation } from "react-router-dom";

const Bar = ({ cartProducts }) => {
    const { userData, logout } = useContext(AuthContext);
    const navigate = useNavigate();
    const location = useLocation();

    const handleLogout = () => {
        logout();
        if (location.pathname === "/admin") {
            navigate("/");
        }
      };

    return (
        <Navbar className="navbar">
            <Container >
                <Nav.Link className="tabs" href="/">HOME</Nav.Link>
                {userData ? (
                    <Nav.Link className="tabs" href="/admin">MANAGE</Nav.Link>
                ) : undefined}
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
                            <Nav.Link className="logout-btn" onClick={handleLogout}>LOG OUT</Nav.Link>
                        </div>
                    ) : (
                        <Nav.Link className="user-info" href="/auth">LOG IN / SIGN UP</Nav.Link>
                    )}
        </Navbar>
    );
};

const mapStateToProps = (state) => ({
    cartProducts: state.cartProducts,
});

export default connect(mapStateToProps)(Bar);
