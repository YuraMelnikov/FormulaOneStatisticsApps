import React from "react";
import { Container } from "react-bootstrap";
import Title from "../components/Titles/Title";
import TableGrandPrixParticipant from '../components/Tables/TableGrandPrixParticipant';
import TableGrandPrixQualification from '../components/Tables/TableGrandPrixQualification';
import TableGrandPrixClassification from '../components/Tables/TableGrandPrixClassification';
import InfoGrandPrix from "../components/Info/InfoGrandPrix";
import TableGrandPrixChampRacers from '../components/Tables/TableGrandPrixChampRacers';
import TableGrandPrixChampConstructors from '../components/Tables/TableGrandPrixChampConstructors';
import ImagesGrandPrix from '../components/Carousels/ImagesGrandPrix';
import {GRAND_PRIX} from '../utils/TitleNameConst';

const GrandPrix = () => {
    return (
        <Container>
            <Title name={GRAND_PRIX}/>
            <InfoGrandPrix/>
            <TableGrandPrixParticipant/>
            <TableGrandPrixQualification/>
            <TableGrandPrixClassification/>
            <ImagesGrandPrix/>
            <TableGrandPrixChampRacers/>
            <TableGrandPrixChampConstructors/>
        </Container>
    );
}

export default GrandPrix;