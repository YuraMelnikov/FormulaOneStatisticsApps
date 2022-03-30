import React from "react";
import { Container } from "react-bootstrap";
import SeasonsList from "../components/SeasonsList";
import Title from "../components/Title";

const Seasons = () => {
    return (
        <Container fluid>
            <Title name="Seasons"/>
            <SeasonsList/>
        </Container>
    );
}

export default Seasons;