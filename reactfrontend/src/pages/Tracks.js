import React from "react";
import { Container, Row } from "react-bootstrap";
import TracksList from "../components/TracksList";

const Tracks = () => {
    return (
        <Container>
            <Row>
                <TracksList/>
            </Row>
        </Container>
    );
}

export default Tracks;