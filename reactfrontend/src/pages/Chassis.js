import React from "react";
import Title from "../components/Titles/Title";
import { Container } from 'react-bootstrap';
import InfoChassis from '../components/Info/InfoChassis';
import TableChassisSeasons from "../components/Tables/TableChassisSeasons";
import ImagesChassis from "../components/Carousels/ImagesChassis";
import TableChassisChamp from "../components/Tables/TableChassisChamp";
import {CHASSIS} from '../utils/TitleNameConst';

const Chassis = () =>{
    return (
        <Container>
            <Title name={CHASSIS}/>
            <InfoChassis/>
            <TableChassisSeasons/>
            <TableChassisChamp/>
            <ImagesChassis/>
        </Container>
    );
}

export default Chassis;