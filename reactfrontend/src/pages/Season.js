import React from "react";
import { Container } from "react-bootstrap";
import TableSeasonCalendar from '../components/TableSeasonCalendar';
import TableSeasonPercipient from '../components/TableSeasonPercipient';
import TableSeasonChampRacers from '../components/TableSeasonChampRacers';
import TableSeasonChampConstructors from '../components/TableSeasonChampConstructors';
import Title from "../components/Title";

const Season = (name) => {

    return (
        <Container>
            <Title name={ name.location.state +  " Formula One Season"}/>
            <TableSeasonCalendar/>
            <TableSeasonPercipient/>
            <TableSeasonChampRacers/>
            <TableSeasonChampConstructors/>
        </Container>
    );
}

export default Season;