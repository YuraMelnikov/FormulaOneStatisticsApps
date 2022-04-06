import React from "react";
import { Container } from "react-bootstrap";
import Title from "../components/Title";
import TableGrandPrixParticipant from '../components/TableGrandPrixParticipant';
import TableGrandPrixQualification from '../components/TableGrandPrixQualification';
import TableGrandClassification from '../components/TableGrandClassification';

const GrandPrix = () => {
    return (
        <Container>
                <Title name="Grand Prix"/>
                <TableGrandPrixParticipant/>
                <TableGrandPrixQualification/>
                <TableGrandClassification/>
        </Container>
    );
}

export default GrandPrix;