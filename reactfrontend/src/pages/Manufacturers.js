import React from "react";
import { Container, Row } from "react-bootstrap";
import ManufacturersList from "../components/Lists/ManufacturersList";
import Title from "../components/Titles/Title";

const Manufacturers = () => {
    return (
        <Container fluid>
            <Row>
                <Title name="Manufacturers"/>
                <ManufacturersList/>
            </Row>
        </Container>
    );
}

export default Manufacturers;