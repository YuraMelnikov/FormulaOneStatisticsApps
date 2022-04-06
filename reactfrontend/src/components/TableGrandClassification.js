import React, {useContext} from 'react';
import Table from 'react-bootstrap/Table';
import { Context } from "../index";
import { Container, Row } from 'react-bootstrap';
import { useHistory } from "react-router-dom";
import { RACER_ROUTE, MANUFACTURER_ROUTE } from '../utils/Constants';
import TitleSmall from './TitleSmall';

const TableGrandClassification = () => {
    const {mockData} = useContext(Context)
    const history = useHistory()

    return (
        <Container>
            <Row>
                <TitleSmall name="Classification"/>
                <Table striped bordered hover size="sm">
                    <thead>
                        <tr className="text-center">
                            <th>Position</th>
                            <th>Racer</th>
                            <th>Chassis</th>
                            <th>Circles</th>
                            <th>Time</th>
                            <th>Avr speed</th>
                            <th>Points</th>
                            <th>Note</th>
                        </tr>
                    </thead>
                    <tbody>
                        {mockData.gpClassification.map(mockData =>
                            <tr>
                                <td className="text-center">{mockData.position}</td>
                                <td style={{cursor: 'pointer'}} onClick={() => history.push(RACER_ROUTE + '/' + mockData.idRacer)}>{mockData.racer}</td>
                                <td style={{cursor: 'pointer'}} onClick={() => history.push(MANUFACTURER_ROUTE + '/' + mockData.idChassis)}>{mockData.chassis}</td>
                                <td>{mockData.circles}</td>
                                <td>{mockData.time}</td>
                                <td>{mockData.avrSpeed}</td>
                                <td>{mockData.points}</td>
                                <td>{mockData.note}</td>
                            </tr>
                        )}
                    </tbody>
                </Table>
            </Row>
        </Container>
    );
}

export default TableGrandClassification;