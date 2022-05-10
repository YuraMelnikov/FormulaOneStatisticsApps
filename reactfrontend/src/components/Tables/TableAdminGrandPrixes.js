import React, { useEffect, useContext, useState } from 'react';
import { observer } from "mobx-react-lite";
import Table from 'react-bootstrap/Table';
import { Context } from "../../index";
import { Container, Row, Button } from 'react-bootstrap';
import TitleSmall from '../Titles/TitleSmall';
import { fetchAdminConstructors, fetchCountries } from "../../http/API";
import { Card } from "react-bootstrap"; 
import { Pencil } from 'react-bootstrap-icons';
import CreateConstructor from '../../components/Modals/CreateConstructor';
import UpdateConstructor from '../../components/Modals/UpdateConstructor';
import { 
    IMAGE, 
    NAME, 
    DATE,
    NAME_SHORT, 
    GRAND_PRIX,
    SEASON,
    TRACK,
    NOTE,
    LAPS,
    NUMBER,
    WEATHER,
    BUTTON_ADD,
    CONSTRUCTOR,
    ID } 
from "../../utils/TitleNameConst";

const TableAdminGrandPrixes = observer(() => {
    const {openApiData} = useContext(Context)

    return (
        <Container>
            <Row>
                <TitleSmall name={GRAND_PRIX}/>
                <Table striped bordered hover size="sm">
                    <thead>
                        <tr className="text-center">
                            <th></th>
                            <th>{DATE}</th>
                            <th>{NAME}</th>
                            <th>{NAME_SHORT}</th>
                            <th>{ID}</th>
                            <th>{ID + " " + NAME}</th>
                            <th>{ID + " " + SEASON}</th>
                            <th>{ID + " " + TRACK}</th>
                            <th>{IMAGE}</th>
                            <th>{NUMBER}</th>
                            <th>{NUMBER + " " + SEASON}</th>
                            <th>{LAPS}</th>
                            <th>{SEASON}</th>
                            <th>{NOTE}</th>
                            <th>{WEATHER}</th>
                        </tr>
                    </thead>
                    <tbody>
                        {openApiData.grandPrix.map(gp =>
                            <tr key={constructor.id}>
                                <td onClick={function(){ 
                                    //setConstructorUpdateVisible(true); 
                                    //setId(constructor.id);
                                    //openApiData.setSelectedImage({link: constructor.image});
                                    //openApiData.setSelectedLogo({link: constructor.logo});
                                }}><Pencil /></td>
                                <td className="text-center">{gp.date}</td>
                                <td className="text-center">{gp.fullName}</td>
                                <td className="text-center">{gp.grandPrixNames}</td>
                                <td className="text-center">{gp.id}</td>
                                <td className="text-center">{gp.idGrandPrixNames}</td>
                                <td className="text-center">{gp.idSeason}</td>
                                <td className="text-center">{gp.idTrackСonfiguration}</td>
                                <td><Card.Img variant="top" src={gp.image}/></td>
                                <td className="text-center">{gp.number}</td>
                                <td className="text-center">{gp.numberInSeason}</td>
                                <td className="text-center">{gp.numberOfLap}</td>
                                <td className="text-center">{gp.season}</td>
                                <td className="text-center">{gp.text}</td>
                                <td className="text-center">{gp.weather}</td>

                                
                            </tr>
                        )}
                    </tbody>
                </Table>
            </Row>
        </Container>
    );
});

export default TableAdminGrandPrixes;