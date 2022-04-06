import React, {useContext} from 'react';
import Table from 'react-bootstrap/Table';
import {Context} from "../index";
import { Container, Row } from 'react-bootstrap';
import { useHistory } from "react-router-dom";
import { RACER_ROUTE, MANUFACTURER_ROUTE, TRACK_ROUTE, GRANDPRIX_ROUTE } from '../utils/Constants';
import TitleSmall from './TitleSmall';

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
                            <tr key={mockData.idGrandPrix}>
                                <td style={{cursor: 'pointer'}} onClick={() => history.push(GRANDPRIX_ROUTE + '/' + mockData.idGrandPrix)} className="text-center">{mockData.date}</td>
                                <td style={{cursor: 'pointer'}} onClick={() => history.push(TRACK_ROUTE + '/' + mockData.idTrack)}>{mockData.trackName}</td>
                                <td className="text-center">{mockData.lap}</td>
                                <td style={{cursor: 'pointer'}} onClick={() => history.push(RACER_ROUTE + '/' + mockData.idWinnerRacer)}>{mockData.racerWinner}</td>
                                <td style={{cursor: 'pointer'}} onClick={() => history.push(MANUFACTURER_ROUTE + '/' + mockData.idWinnerTeam)}>{mockData.teamWinner}</td>
                            </tr>
                        )}
                    </tbody>
                </Table>
            </Row>
        </Container>
    );
}

export default TableGrandPrixParticipant;