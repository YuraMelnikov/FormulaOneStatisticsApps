import React from 'react';
import Title from "../components/Titles/Title";
import TitleSmall from "../components/Titles/TitleSmall";
import { Container } from "react-bootstrap";
import TableAdminSeasons from '../components/Tables/TableAdminSeasons';
import TableAdminImages from '../components/Tables/TableAdminImages';

const Admin = () =>{
    
    //<TitleSmall name="Seasons"/>
    //<TableAdminSeasons/>
    return (
        <Container className="d-flex flex-column">
            <Title name="Admin panel"/>

            <TitleSmall name="Images"/>
            <TableAdminImages/>
        </Container>
    );
}

export default Admin;