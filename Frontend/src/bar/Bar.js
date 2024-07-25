import React, { useContext } from "react";
import { connect } from "react-redux";
import { Container, Navbar } from "react-bootstrap";
import Basket from "./Basket";
import { AuthContext } from "../context/AuthContext";
import { useNavigate, useLocation, Link } from "react-router-dom";

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
            <Container>
                <Link to="/p5/" className="nav-link tabs">HOME</Link>
                {userData && (
                    <Link to="/p5/admin/" className="nav-link tabs">MANAGE</Link>
                )}
                <Navbar.Collapse className="justify-content-end">
                    <Link to="/p5/shopping-cart/" className="shopping-cart">
                        <Basket cartProducts={cartProducts} />
                    </Link>
                </Navbar.Collapse>
            </Container>
            <div className="bar_line"></div>
            {userData ? (
                <div className="user-info">
                    <span className="username">
                        {`You are logged with role ${userData.role} as: ${userData.username}`}
                    </span>
                    <div className="bar_line"></div>
                    <span className="logout-btn" onClick={handleLogout}>LOG OUT</span>
                </div>
            ) : (
                <Link to="/p5/auth/" className="nav-link tabs login-signup-link">
                    LOG IN / SIGN UP
                </Link>
            )}
        </Navbar>
    );
};

const mapStateToProps = (state) => ({
    cartProducts: state.cartProducts,
});

export default connect(mapStateToProps)(Bar);
