import React, { ReactNode, useState } from "react";
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
import { useTranslation } from 'react-i18next';
import LanguageSelect from "./LanguageSelect";

interface INavBar {
    children?: ReactNode;
}

const NavBar: React.FC<INavBar> = ({ children }: INavBar) => {
        const { t } = useTranslation();
        const [background, setBackground] = useState(false)

        return (
            <>
                <Navbar 
                    collapseOnSelect expand="lg" 
                    onClick={() => background !== false ? setBackground(false) : null}
                    style={ {backgroundColor: background ? '#000' : 'null' }}
                >
                    <Container>
                        <Navbar.Brand>
                            <Nav.Link as={Link} onClick={() => background !== false ? setBackground(false) : null} to={INDEX_ROUTE} >LOGO</Nav.Link>
                        </Navbar.Brand>
                        <Navbar.Toggle aria-controls="responsive-navbar-nav" className="custom-toggler"/>
                        <Navbar.Collapse id="responsive-navbar-nav">
                            <Nav className="me-auto">
                                <Nav.Link as={Link} onClick={() => background !== true ? setBackground(true) : null} to={SEASONS_ROUTE} >{t('seasons.label')}</Nav.Link>
                                <Nav.Link as={Link} onClick={() => background !== true ? setBackground(true) : null} to={CONSTRUCTORS_ROUTE} >{t('constructors.label')}</Nav.Link>
                                <Nav.Link as={Link} onClick={() => background !== true ? setBackground(true) : null} to={RACERS_ROUTE} >{t('racers.label')}</Nav.Link>
                                <Nav.Link as={Link} onClick={() => background !== true ? setBackground(true) : null} to={MANUFACTURERS_ROUTE} >{t('manufacturers.label')}</Nav.Link>
                                <Nav.Link as={Link} onClick={() => background !== true ? setBackground(true) : null} to={TRACKS_ROUTE} >{t('tracks.label')}</Nav.Link>
                                <LanguageSelect/>
                            </Nav>
                        </Navbar.Collapse>
                    </Container>
                </Navbar>
            </>
    );
}

export default NavBar;