import React from "react";
import Title from "../components/Titles/Title";
import { Container } from 'react-bootstrap';
import TableRacerSeasons from "../components/Tables/TableRacerSeasons";
import InfoRacer from "../components/Info/InfoRacer";
import TableRacerChamp from "../components/Tables/TableRacerChamp";
import ImagesRacer from "../components/Carousels/ImagesRacer";

const Racer = () => { 
    return (
        <Container>
            <Title name="Racer"/>
            <InfoRacer/>
            <TableRacerSeasons/>
            <TableRacerChamp/>
            <ImagesRacer/>
        </Container>
    );
}

export default Racer;