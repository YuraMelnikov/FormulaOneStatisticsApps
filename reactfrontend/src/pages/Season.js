import React from "react";
import { Container } from "react-bootstrap";
import TableSeasonCalendar from '../components/TableSeasonCalendar';
import TableSeasonParcipiant from '../components/TableSeasonParcipiant';
import TableSeasonChampRacers from '../components/TableSeasonChampRacers';
import Title from "../components/Title";

const Season = (name) => {

    return (
        <Container fluid>
            <Title name={ name.location.state +  " Formula One Season"}/>
            <Title name="Calendar"/>
            <TableSeasonCalendar/>
            <Title name="Parcipiant"/>
            <TableSeasonParcipiant/>
            <Title name="World Championship for Drivers"/>

            <Title name="World Championship for Constructors"/>

        </Container>
    );
}

export default Season;