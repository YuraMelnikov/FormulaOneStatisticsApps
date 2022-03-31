import React, {useContext} from 'react';
import Table from 'react-bootstrap/Table';
import {Context} from "../index";
import { Container, Row } from 'react-bootstrap';
import { useHistory } from "react-router-dom";
import {RACER_ROUTE, MANUFACTURER_ROUTE } from '../utils/Consts';

const TableSeasonParcipiant = () => {
    const {mockData} = useContext(Context)
    const history = useHistory()

    return (
        <Container>
            <Row>
                <Table striped bordered hover size="sm">
                    <thead>
                        <tr className="text-center">
                            <th>Team</th>
                            <th>Chassies</th>
                            <th>Engines</th>
                            <th>Racers</th>
                            <th>Tyres</th>
                        </tr>
                    </thead>
                    <tbody >
                        {mockData.seasonParcipient.map(mockData =>
                            <tr key={mockData.idTeam} >
                                <td classname="col-sm-3" style={{cursor: 'pointer'}} onClick={() => history.push(MANUFACTURER_ROUTE + '/' + mockData.idTeam)}>{mockData.name}</td>
                                <td classname="col-sm-3">
                                    {mockData.chassies.map(mockDataChassies =>
                                        <p style={{cursor: 'pointer'}} onClick={() => history.push(MANUFACTURER_ROUTE + '/' + mockDataChassies.id)}>{mockDataChassies.name}</p>
                                    )}
                                </td>
                                <td classname="col-sm-3">
                                    {mockData.engines.map(mockDataEngines =>
                                        <p style={{cursor: 'pointer'}} onClick={() => history.push(MANUFACTURER_ROUTE + '/' + mockDataEngines.id)}>{mockDataEngines.name}</p>
                                    )}
                                </td>
                                <td classname="col-sm-2">
                                    {mockData.racers.map(mockDataRacers =>
                                        <p style={{cursor: 'pointer' }} onClick={() => history.push(RACER_ROUTE + '/' + mockDataRacers.id)}>{mockDataRacers.name}</p>
                                    )}
                                </td>
                                <td classname="col-sm-1">
                                    {mockData.tyres.map(mockDataTyres =>
                                        <p style={{cursor: 'pointer'}} onClick={() => history.push(RACER_ROUTE + '/' + mockDataTyres.id)}>{mockDataTyres.name}</p>
                                    )}
                                </td>
                            </tr>
                        )}
                    </tbody>
                </Table>
            </Row>
        </Container>
    );
}

export default TableSeasonParcipiant;