import React, { useContext } from 'react';
import Table from 'react-bootstrap/Table';
import { Context } from "../index";
import { Container, Row } from 'react-bootstrap';
import { useHistory } from "react-router-dom";
import { RACER_ROUTE, GRANDPRIX_ROUTE } from '../utils/Constants';
import TitleSmall from './TitleSmall';

const TableSeasonChampConstructors = () => {
    const {mockData} = useContext(Context)
    const history = useHistory()
    let step = 0

    return(
        <Container>
            <Row>
                <TitleSmall name="World Championship for Constructors"/>
                <Table striped bordered hover size="sm">
                    <thead>
                        <tr className="text-center">

                            
                            <th>Position</th>
                            <th>Driver</th>
                            {mockData.seasonCalendar.map(mockData => 
                                <th style={{cursor: 'pointer'}} onClick={() => history.push(GRANDPRIX_ROUTE + '/' + mockData.idGrandPrix)} className="text-center">{step += 1}</th>
                            )}
                            <th>Points</th>
                        </tr>
                    </thead>
                    <tbody>
                        {mockData.seasonChampTeams.map(mockData =>
                            <tr key={ mockData.id }>
                                <td className="text-center">{mockData.position}</td>
                                <td style={{cursor: 'pointer'}} onClick={() => history.push(RACER_ROUTE + '/' + mockData.id)}>{mockData.name}</td>
                                {mockData.result.map(mockDataResult =>
                                    <td className="text-center">{mockDataResult.racePosition}</td>
                                )}
                                <td className="text-center">{mockData.points}</td>
                            </tr>
                        )}
                    </tbody>
                </Table>
            </Row>
        </Container>
    );
}

export default TableSeasonChampConstructors;