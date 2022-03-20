import React from "react";
import { Container, Row } from "react-bootstrap";
import ManufacturersList from "../components/ManufacturersList";

const Manufacturers = () => {
    return (
        <Container fluid>
            <Row>
                <ManufacturersList/>
            </Row>
        </Container>
    );
}

export default Manufacturers;