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
        if (location.pathname === "/p5/admin/") {
            navigate("/p5/");
        }
      };

    return (
        <Navbar className="navbar">
            <Container >
                <Nav.Link className="tabs" href="/p5/">HOME</Nav.Link>
                {userData ? (
                    <Nav.Link className="tabs" href="/p5/admin/">MANAGE</Nav.Link>
                ) : undefined}
                <Navbar.Collapse className="justify-content-end">
                    <Nav.Link className="shopping-cart" href="/p5/shopping-cart/">
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
                        <Nav.Link className="user-info" href="/p5/auth/">LOG IN / SIGN UP</Nav.Link>
                    )}
        </Navbar>
    );
};

const mapStateToProps = (state) => ({
    cartProducts: state.cartProducts,
});

export default connect(mapStateToProps)(Bar);
