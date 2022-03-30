import React from "react";
import { Container, Row } from "react-bootstrap";
import RacersList from "../components/RacersList";
import Title from "../components/Title";

const Racers = () => {
    return (
        <Container fluid>
            <Row>
                <Title name="Racers"/>
                <RacersList/>
            </Row>
        </Container>
    );
}

export default Racers;