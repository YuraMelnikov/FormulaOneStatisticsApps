import React, {useContext} from 'react';
import Table from 'react-bootstrap/Table';
import {Context} from "../index";
import { Row } from 'react-bootstrap';
import NumberFormat from 'react-number-format';
import { useHistory } from "react-router-dom";
import {RACER_ROUTE, MANUFACTURER_ROUTE, TRACK_ROUTE, GRANDPRIX_ROUTE} from '../utils/Consts';

const TableSeasonParcipiant = () => {
    const {mockData} = useContext(Context)
    const history = useHistory()

    return (
        <Row>
            <Table striped bordered hover size="sm">
                <thead>
                    <tr className="text-center">
                        <th>Team</th>
                        <th>Chassies</th>
                        <th>Racers</th>
                        <th>Engines</th>
                        <th>Tyres</th>
                    </tr>
                </thead>
                <tbody>
                    {mockData.seasonParcipient.map(mockData =>
                        <tr key={mockData.idTeam}>
                            <td style={{cursor: 'pointer'}} onClick={() => history.push(GRANDPRIX_ROUTE + '/' + mockData.idGrandPrix)} className="text-center">{mockData.date}</td>
                            <td style={{cursor: 'pointer'}} onClick={() => history.push(TRACK_ROUTE + '/' + mockData.idTrack)}>{mockData.trackName}</td>
                            <td className="text-center">{mockData.lap}</td>
                            <td className="text-center">
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
    );
}

export default TableSeasonParcipiant;