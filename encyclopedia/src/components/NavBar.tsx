import React, { ReactNode, useState, useEffect } from "react";
import { Col, Container, Nav, Navbar, Row }  from "react-bootstrap";
import { 
    CONSTRUCTORS_ROUTE, 
    INDEX_ROUTE, 
    MANUFACTURERS_ROUTE, 
    RACERS_ROUTE, 
    SEASONS_ROUTE,
    TRACKS_ROUTE
} from "../utils/Links";
import { Link, useLocation } from "react-router-dom";
import { useTranslation } from 'react-i18next';
import LanguageSelect from "./LanguageSelect";

interface INavBar {
    children?: ReactNode;
}

const NavBar: React.FC<INavBar> = ({ children }: INavBar) => {
        let location = useLocation();
        const { t } = useTranslation();
        const [background, setBackground] = useState('navbar-background-no-active')

        useEffect(() => {
            if(location.pathname !== '/'){
                setBackground('navbar-background-is-active');
            }
        // eslint-disable-next-line react-hooks/exhaustive-deps
        }, [])

        return (
            <Container>
            <Row>
                <Col className='col-7'>
                <Navbar 
                    collapseOnSelect expand="lg" 
                    className={background}
                >
                        <Navbar.Brand>
                            <Nav.Link as={Link} onClick={() => background !== 'navbar-background-no-active' ? setBackground('navbar-background-no-active') : null} to={INDEX_ROUTE} >LOGO</Nav.Link>
                        </Navbar.Brand>
                        <Navbar.Toggle aria-controls="responsive-navbar-nav" className="custom-toggler"/>
                        <Navbar.Collapse id="responsive-navbar-nav">
                            <Nav className="me-auto">
                                <Nav.Link as={Link} onClick={() => background !== 'navbar-background-is-active' ? setBackground('navbar-background-is-active') : null} to={SEASONS_ROUTE} >{t('seasons.label')}</Nav.Link>
                                <Nav.Link as={Link} onClick={() => background !== 'navbar-background-is-active' ? setBackground('navbar-background-is-active') : null} to={CONSTRUCTORS_ROUTE} >{t('constructors.label')}</Nav.Link>
                                <Nav.Link as={Link} onClick={() => background !== 'navbar-background-is-active' ? setBackground('navbar-background-is-active') : null} to={RACERS_ROUTE} >{t('racers.label')}</Nav.Link>
                                <Nav.Link as={Link} onClick={() => background !== 'navbar-background-is-active' ? setBackground('navbar-background-is-active') : null} to={MANUFACTURERS_ROUTE} >{t('manufacturers.label')}</Nav.Link>
                                <Nav.Link as={Link} onClick={() => background !== 'navbar-background-is-active' ? setBackground('navbar-background-is-active') : null} to={TRACKS_ROUTE} >{t('tracks.label')}</Nav.Link>
                                <LanguageSelect/>
                            </Nav>
                        </Navbar.Collapse>
                </Navbar>
                </Col>
                </Row>
                </Container>
    );
}

export default NavBar;