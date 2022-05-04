import React from 'react';
import Title from "../components/Titles/Title";
import TitleSmall from "../components/Titles/TitleSmall";
import { Container } from "react-bootstrap";
import TableAdminSeasons from '../components/Tables/TableAdminSeasons';

import TableAdminRacers from '../components/Tables/TableAdminRacers';
import TableAdminConstructors from '../components/Tables/TableAdminConstructors';
import TableAdminManufacturers from '../components/Tables/TableAdminManufacturers';
import TableAdminTracks from '../components/Tables/TableAdminTracks';

//<TableAdminManufacturers/>
//<TableAdminTracks/>

//<TableAdminRacers/>

const Admin = () =>{

    return (
        <Container className="d-flex flex-column">
            <Title name="Admin panel"/>
            <TitleSmall name="Seasons"/>
            <TableAdminSeasons/>


            <TableAdminConstructors/>
 
        </Container>
    );
}

export default Admin;