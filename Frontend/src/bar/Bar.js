import { Container, Image, Nav, Navbar } from "react-bootstrap";
import Basket from "./Basket";
import React from "react";

export default function Bar(props) {
  return (
    <Navbar className="navbar">
      <Container>
        <Nav.Link href="/">HOME</Nav.Link>

        <Navbar.Collapse className="justify-content-end">
          <Nav.Link href="/shopping-cart">
            <Basket />
          </Nav.Link>
          <div className="bar_line"></div>
          <Nav.Link href="/auth">LOG IN / SIGN UP</Nav.Link>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
}
