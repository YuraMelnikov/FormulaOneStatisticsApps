import React from "react";
import { Container, Row } from "react-bootstrap";
import ManufacturersList from "../components/ManufacturersList";

const Manufacturers = () => {
    return (
        <Container>
            <Row>
                <ManufacturersList/>
            </Row>
        </Container>
    );
}

export default Manufacturers;