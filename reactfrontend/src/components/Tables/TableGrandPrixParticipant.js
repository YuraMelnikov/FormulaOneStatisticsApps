import React, {useContext} from 'react';
import Table from 'react-bootstrap/Table';
import {Context} from "../../index";
import { Container, Row } from 'react-bootstrap';
import { useHistory } from "react-router-dom";
import { RACER_ROUTE, MANUFACTURER_ROUTE } from '../../utils/Constants';
import TitleSmall from '../TitleSmall';

const TableGrandPrixParticipant = () => {
    const {mockData} = useContext(Context)
    const history = useHistory()

    return (
        <Container>
            <Row>
                <TitleSmall name="Participant"/>
                <Table striped bordered hover size="sm">
                    <thead>
                        <tr className="text-center">
                            <th>No</th>
                            <th>Team</th>
                            <th>Racer</th>
                            <th>Chassis</th>
                            <th>Engine</th>
                            <th>Tyre</th>
                        </tr>
                    </thead>
                    <tbody>
                        {mockData.gpParticipant.map(mockData =>
                            <tr key={mockData.no}>
                                <td className="text-center">{mockData.no}</td>
                                <td>{mockData.teamName}</td>
                                <td style={{cursor: 'pointer'}} onClick={() => history.push(RACER_ROUTE + '/' + mockData.idRacer)}>{mockData.racer}</td>
                                <td style={{cursor: 'pointer'}} onClick={() => history.push(MANUFACTURER_ROUTE + '/' + mockData.idChassis)}>{mockData.chassis}</td>
                                <td style={{cursor: 'pointer'}} onClick={() => history.push(MANUFACTURER_ROUTE + '/' + mockData.idEngine)}>{mockData.engine}</td>
                                <td style={{cursor: 'pointer'}} onClick={() => history.push(MANUFACTURER_ROUTE + '/' + mockData.idTyre)}>{mockData.tyre}</td>
                            </tr>
                        )}
                    </tbody>
                </Table>
            </Row>
        </Container>
    );
}

export default TableGrandPrixParticipant;