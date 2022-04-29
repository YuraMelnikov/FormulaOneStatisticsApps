import React from 'react';
import Title from "../components/Titles/Title";
import TitleSmall from "../components/Titles/TitleSmall";
import { Container } from "react-bootstrap";

import TableAdminSeasons from '../components/Tables/TableAdminSeasons';

const Admin = () =>{
    

    return (
        <Container className="d-flex flex-column">
            <Title name="Admin panel"/>
            <TitleSmall name="Seasons"/>
            <TableAdminSeasons/>
        </Container>
    );
}

export default Admin;