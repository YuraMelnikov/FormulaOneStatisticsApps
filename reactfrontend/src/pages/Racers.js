import React from "react";
import { Container, Row } from "react-bootstrap";
import RacersList from "../components/RacersList";

const Racers = () => {
    return (
        <Container>
            <Row>
                <RacersList/>
            </Row>
        </Container>
    );
}

export default Racers;