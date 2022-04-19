import React from "react";
import Title from "../components/Titles/Title";
import { Container } from 'react-bootstrap';
import TableRacerSeasons from "../components/Tables/TableRacerSeasons";

const Racer = () => { 
    return (
        <Container>
            <Title name="Racer"/>
            <TableRacerSeasons/>
        </Container>
    );
}

export default Racer;