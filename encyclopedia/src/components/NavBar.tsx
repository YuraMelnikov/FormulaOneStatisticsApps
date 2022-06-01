import React, { ReactNode } from "react";
import { Nav, Navbar, Container }  from "react-bootstrap";
import { 
    CONSTRUCTORS_ROUTE, 
    INDEX_ROUTE, 
    MANUFACTURERS_ROUTE, 
    RACERS_ROUTE, 
    SEASONS_ROUTE,
    TRACKS_ROUTE
} from "../utils/Links";
import { Link } from "react-router-dom";
import { 
    CONSTRUCTORS,
    MANUFACTURERS,
    RACERS,
    SEASONS,
    TRACKS
    
} from "../utils/Constants";

interface INavBar {
    children?: ReactNode;
}

const NavBar: React.FC<INavBar> = ({ children }: INavBar) => {
        return (
            <>
                <Navbar collapseOnSelect expand="lg">
                    <Container>
                        <Navbar.Brand>
                            <Nav.Link as={Link} to={INDEX_ROUTE} >{SEASONS}</Nav.Link>
                        </Navbar.Brand>
                        <Navbar.Toggle aria-controls="responsive-navbar-nav"/>
                        <Navbar.Collapse id="responsive-navbar-nav">
                            <Nav className="me-auto">
                                <Nav.Link as={Link} to={SEASONS_ROUTE} >{SEASONS}</Nav.Link>
                                <Nav.Link as={Link} to={CONSTRUCTORS_ROUTE} >{CONSTRUCTORS}</Nav.Link>
                                <Nav.Link as={Link} to={RACERS_ROUTE} >{RACERS}</Nav.Link>
                                <Nav.Link as={Link} to={MANUFACTURERS_ROUTE} >{MANUFACTURERS}</Nav.Link>
                                <Nav.Link as={Link} to={TRACKS_ROUTE} >{TRACKS}</Nav.Link>
                            </Nav>
                        </Navbar.Collapse>
                        <div>{children}</div>
                    </Container>
                </Navbar>
            </>
    );
}

export default NavBar;