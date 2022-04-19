import React from 'react';
import { Container } from "react-bootstrap";
import TableSeasonCalendar from '../components/Tables/TableSeasonCalendar';
import TableSeasonPercipient from '../components/Tables/TableSeasonPercipient';
import TableSeasonChampRacers from '../components/Tables/TableSeasonChampRacers';
import TableSeasonChampConstructors from '../components/Tables/TableSeasonChampConstructors';
import Title from "../components/Titles/Title";

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