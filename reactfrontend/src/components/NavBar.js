import React from "react";
import { Nav, Navbar, Container }  from "react-bootstrap";
import { ABOUTAPI_ROUTE, ABOUTUS_ROUTE, MANUFACTURERS_ROUTE, RACERS_ROUTE, SEASONS_ROUTE, STATISTICS_ROUTE, TRACKS_ROUTE } from "../utils/Constants";
import { Link } from "react-router-dom";
import { ABOUTUS_TITLE, MANUFACTURERS_TITLE, RACERS_TITLE, SEASONS_TITLE, STATISTICS_TITLE, TRACKS_TITLE, ABOUTAPI_TITLE } from "../utils/TitleNameConst";

const NavBar = () => {
    return (
        <Navbar sticky="top" collapseOnSelect expand="lg" bg="dark" variant="dark">
        <Container>
            <Navbar.Brand>LOGO</Navbar.Brand>
                <Navbar.Toggle aria-controls="responsive-navbar-nav"/>
                <Navbar.Collapse id="responsive-navbar-nav">
                <Nav className="me-auto">
                    <Nav.Link as={Link} to={SEASONS_ROUTE} >{SEASONS_TITLE}</Nav.Link>
                    <Nav.Link as={Link} to={MANUFACTURERS_ROUTE} >{MANUFACTURERS_TITLE}</Nav.Link>
                    <Nav.Link as={Link} to={RACERS_ROUTE} >{RACERS_TITLE}</Nav.Link>
                    <Nav.Link as={Link} to={TRACKS_ROUTE} >{TRACKS_TITLE}</Nav.Link>
                    <Nav.Link as={Link} to={STATISTICS_ROUTE} >{STATISTICS_TITLE}</Nav.Link>
                    <Nav.Link as={Link} to={ABOUTAPI_ROUTE} >{ABOUTAPI_TITLE}</Nav.Link>
                    <Nav.Link as={Link} to={ABOUTUS_ROUTE} >{ABOUTUS_TITLE}</Nav.Link>
                </Nav>
                </Navbar.Collapse>
        </Container>
    </Navbar>
    );
}

export default NavBar;