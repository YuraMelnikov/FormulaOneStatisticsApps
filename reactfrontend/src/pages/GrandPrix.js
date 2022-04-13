import React from "react";
import { Container } from "react-bootstrap";
import Title from "../components/Title";
import TableGrandPrixParticipant from '../components/Tables/TableGrandPrixParticipant';
import TableGrandPrixQualification from '../components/Tables/TableGrandPrixQualification';
import TableGrandClassification from '../components/Tables/TableGrandClassification';

const GrandPrix = () => {
    return (
        <Container>
                <Title name="Grand Prix"/>
                <TableGrandClassification/>
                <TableGrandPrixParticipant/>
                <TableGrandPrixQualification/>
        </Container>
    );
}

export default GrandPrix;