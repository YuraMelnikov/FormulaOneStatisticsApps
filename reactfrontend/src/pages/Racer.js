import React from "react";
import Title from "../components/Title";
import { Container } from 'react-bootstrap';
import TableRacerSeasons from "../components/TableRacerSeasons";

const Racer = () => {
    return (
        <Container>
            <Title name="Racer"/>
            <TableRacerSeasons/>
        </Container>
    );
}

export default Racer;