import React from "react";
import { Container, Row } from "react-bootstrap";
import SeasonsList from "../components/SeasonsList";

const Seasons = () => {
    return (
        <Container>
            <Row>
                <SeasonsList/>
            </Row>
        </Container>
    );
}

export default Seasons;