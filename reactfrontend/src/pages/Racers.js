import React from "react";
import { Container, Row } from "react-bootstrap";
import RacersList from "../components/Lists/RacersList";
import Title from "../components/Titles/Title";

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