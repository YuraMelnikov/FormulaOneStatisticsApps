import React from "react";
import { Container, Row } from "react-bootstrap";
import TracksList from "../components/TracksList";
import Title from "../components/Title";

const Tracks = () => {
    return (
        <Container fluid>
            <Row>
                <Title name="Tracks"/>
                <TracksList/>
            </Row>
        </Container>
    );
}

export default Tracks;