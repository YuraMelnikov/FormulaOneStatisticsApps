import React from "react";
import { Container, Row } from "react-bootstrap";
import ManufacturersList from "../components/Lists/ManufacturersList";
import Title from "../components/Titles/Title";
import {MANUFACTURERS_TITLE} from '../utils/TitleNameConst';

const Manufacturers = () => {
    return (
        <Container fluid>
            <Row>
                <Title name={MANUFACTURERS_TITLE}/>
                <ManufacturersList/>
            </Row>
        </Container>
    );
}

export default Manufacturers;