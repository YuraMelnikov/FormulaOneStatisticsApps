import React, {useContext} from 'react';
import Table from 'react-bootstrap/Table';
import {Context} from "../index";
import { Container, Row } from 'react-bootstrap';
import NumberFormat from 'react-number-format';
import { useHistory } from "react-router-dom";
import {RACER_ROUTE, MANUFACTURER_ROUTE, TRACK_ROUTE, GRANDPRIX_ROUTE} from '../utils/Consts';

const TableSeasonCalendar = () => {
    const {mockData} = useContext(Context)
    const history = useHistory()

    return (
        <Container>
            <Row>
                <Table striped bordered hover size="sm">
                    <thead>
                        <tr classname="text-center">
                            <th>Date</th>
                            <th>Track</th>
                            <th>Lap</th>
                            <th>Distance</th>
                            <th>Winner</th>
                            <th>Team winner</th>
                        </tr>
                    </thead>
                    <tbody>
                        {mockData.seasonCalendar.map(mockData =>
                            <tr key={mockData.idGrandPrix}>
                                <td style={{cursor: 'pointer'}} onClick={() => history.push(GRANDPRIX_ROUTE + '/' + mockData.idGrandPrix)} classname="text-center">{mockData.date}</td>
                                <td style={{cursor: 'pointer'}} onClick={() => history.push(TRACK_ROUTE + '/' + mockData.idTrack)}>{mockData.trackName}</td>
                                <td classname="text-center">{mockData.lap}</td>
                                <td classname="text-center">
                                    <NumberFormat 
                                        value={mockData.distance} 
                                        displayType={'text'} 
                                        thousandsGroupStyle="thousand"
                                        thousandSeparator={true}
                                        allowNegative={true}
                                        decimalScale={2}
                                    />
                                </td>
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

export default TableSeasonCalendar;