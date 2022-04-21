import React, {useContext} from 'react';
import Table from 'react-bootstrap/Table';
import { Context } from "../../index";
import { Container, Row } from 'react-bootstrap';
import { useHistory } from "react-router-dom";
import { MANUFACTURER_ROUTE, SEASONS_ROUTE } from '../../utils/Constants';
import TitleSmall from '../Titles/TitleSmall';

const TableRacerSeasons = () => {
    const {mockData} = useContext(Context)
    const history = useHistory()

    return (
        <Container>
            <Row>
                <TitleSmall name="Seasons"/>
                <Table striped bordered hover size="sm">
                    <thead>
                        <tr className="text-center">
                            <th>Season</th>
                            <th>Chassis</th>
                            <th>Points</th>
                            <th>Position</th>
                            <th>Wins</th>
                            <th>Pole positions</th>
                            <th>Fast laps</th>
                            <th>Top start</th>
                            <th>Top finished</th>
                            <th>Grand prix</th>
                        </tr>
                    </thead>
                    <tbody>
                        {mockData.racerResult.map(mockData =>
                            <tr key={mockData.idSeason} className="text-center">
                                <td style={{cursor: 'pointer'}} onClick={() => history.push(SEASONS_ROUTE + '/' + mockData.idSeason)}>{mockData.season}</td>
                                <td className="text-left">
                                    {mockData.chaises.map(mockDataChassis =>
                                        <p style={{cursor: 'pointer'}} onClick={() => history.push(MANUFACTURER_ROUTE + '/' + mockDataChassis.idChassis)}>{mockDataChassis.chasses}</p>
                                    )}
                                 </td>
                                <td>{mockData.points}</td>
                                <td>{mockData.positions}</td>
                                <td>{mockData.win}</td>
                                <td>{mockData.polePosition}</td>
                                <td>{mockData.fastLap}</td>
                                <td>{mockData.topStart}</td>
                                <td>{mockData.topFinish}</td>
                                <td>{mockData.grandPrixes}</td>
                            </tr>
                        )}
                    </tbody>
                </Table>
            </Row>
        </Container>
    );
}

export default TableRacerSeasons;