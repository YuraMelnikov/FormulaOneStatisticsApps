import React from "react";
import { Container, Row } from "react-bootstrap";
import ManufacturersList from "../components/ManufacturersList";
import Title from "../components/Title";

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