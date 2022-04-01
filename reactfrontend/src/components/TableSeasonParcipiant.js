import React, {useContext} from 'react';
import Table from 'react-bootstrap/Table';
import {Context} from "../index";
import { Container, Row } from 'react-bootstrap';
import { useHistory } from "react-router-dom";
import {RACER_ROUTE, MANUFACTURER_ROUTE } from '../utils/Constants';

const TableSeasonPercipient = () => {
    const {mockData} = useContext(Context)
    const history = useHistory()

    return (
        <Container>
            <Row>
                <Table striped bordered hover size="sm">
                    <thead>
                        <tr className="text-center">
                            <th>Team</th>
                            <th>Chassis</th>
                            <th>Engines</th>
                            <th>Racers</th>
                            <th>Tyres1333</th>
                        </tr>
                    </thead>
                    <tbody>
                        {mockData.seasonPercipient.map(mockData =>
                            <tr key={mockData.idTeam} >
                                <td className="col-sm-3">{mockData.name}</td>
                                <td className="col-sm-3">
                                    {mockData.chassis.map(mockDataChassis =>
                                        <p style={{cursor: 'pointer'}} onClick={() => history.push(MANUFACTURER_ROUTE + '/' + mockDataChassis.id)}>{mockDataChassis.name}</p>
                                    )}
                                </td>
                                <td className="col-sm-3">
                                    {mockData.engines.map(mockDataEngines =>
                                        <p style={{cursor: 'pointer'}} onClick={() => history.push(MANUFACTURER_ROUTE + '/' + mockDataEngines.id)}>{mockDataEngines.name}</p>
                                    )}
                                </td>
                                <td className="col-sm-2">
                                    {mockData.racers.map(mockDataRacers =>
                                        <p style={{cursor: 'pointer' }} onClick={() => history.push(RACER_ROUTE + '/' + mockDataRacers.id)}>{mockDataRacers.name}</p>
                                    )}
                                </td>
                                <td className="col-sm-1">
                                    {mockData.tyres.map(mockDataTyres =>
                                        <p style={{cursor: 'pointer'}} onClick={() => history.push(MANUFACTURER_ROUTE + '/' + mockDataTyres.id)}>{mockDataTyres.name}</p>
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

export default TableSeasonPercipient;