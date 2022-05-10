import React from "react";
import { Container, Row } from "react-bootstrap";
import TracksList from "../components/Lists/TracksList";
import Title from "../components/Titles/Title";
import { TRACKS_TITLE } from "../utils/TitleNameConst";

const Tracks = () => {
    return (
        <Container fluid>
            <Row>
                <Title name={TRACKS_TITLE}/>
                <TracksList/>
            </Row>
        </Container>
    );
}

export default Tracks;