import React from "react";
import InfoConstructor from "../components/Info/InfoConstructor";
import Title from "../components/Titles/Title";
import { Container } from 'react-bootstrap';
import TableConstructorSeasons from '../components/Tables/TableConstructorSeasons';
import TableConstructorChamp from "../components/Tables/TableConstructorChamp";
import ImagesConstructor from "../components/Carousels/ImagesConstructor";

const Constructor = () =>{
    return (
        <Container>
            <Title name="Chassis"/>
            <InfoConstructor/>
			<TableConstructorSeasons/>
            <TableConstructorChamp/>
            <ImagesConstructor/>
        </Container>
    );
}

export default Constructor;