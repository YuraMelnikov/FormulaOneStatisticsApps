import React, {useContext} from 'react';
import Table from 'react-bootstrap/Table';
import {Context} from "../index";
import { Container, Row } from 'react-bootstrap';
import { useHistory } from "react-router-dom";
import {RACER_ROUTE } from '../utils/Consts';

const TableSeasonChampRacers = () => {
    const {mockData} = useContext(Context)
    const history = useHistory()

    return(
        <Container>
            <Row>
                <Table striped bordered hover size="sm">
                    <thead>
                        <tr classname="text-center">
                            <th>Position</th>
                            <th>Driver</th>
                            <th>Grand prix</th>
                            <th>Points</th>
                        </tr>
                    </thead>
                    <tbody>
                        {mockData.seasonCalendar.map(mockData =>
                            <tr key={ mockData.id }>
                                <td>{mockData.position}</td>
                                <td style={{cursor: 'pointer'}} onClick={() => history.push(RACER_ROUTE + '/' + mockData.id)} classname="text-center">{mockData.name}</td>
                                {mockData.result.map(mockDataResult =>
                                    <td>{mockDataResult.racePosition}</td>
                                )}
                                <td>{mockData.points}</td>
                            </tr>
                        )}
                    </tbody>
                </Table>
            </Row>
        </Container>
    );
}

export default TableSeasonChampRacers;