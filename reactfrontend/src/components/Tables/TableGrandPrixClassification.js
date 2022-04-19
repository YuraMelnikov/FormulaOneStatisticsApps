import React, { useEffect, useContext } from 'react';
import { useParams } from 'react-router-dom';
import { observer } from "mobx-react-lite";
import Table from 'react-bootstrap/Table';
import { Context } from "../../index";
import { Container, Row } from 'react-bootstrap';
import TitleSmall from '../Titles/TitleSmall';
import { fetchGpClassification } from "../../http/API";
import { useHistory } from "react-router-dom";
import { RACER_ROUTE, MANUFACTURER_ROUTE } from '../../utils/Constants';

const TableGrandPrixClassification = observer(() => {
    const history = useHistory()
    const {openApiData} = useContext(Context)
    const {id} = useParams()

    useEffect(() => {
        fetchGpClassification(id).then(data => openApiData.setGpClassification(data))
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [])

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
                        {openApiData.gpClassification.map(result =>
                            <tr key={result.idRacer}>
                                <td className="text-center">{result.position}</td>
                                <td style={{cursor: 'pointer'}} onClick={() => history.push(RACER_ROUTE + '/' + result.idRacer)}>{result.racer}</td>
                                <td style={{cursor: 'pointer'}} onClick={() => history.push(MANUFACTURER_ROUTE + '/' + result.idChassis)}>{result.chassis}</td>
                                <td>{result.circles}</td>
                                <td>{result.time}</td>
                                <td>{result.avrSpeed}</td>
                                <td>{result.points}</td>
                                <td>{result.note}</td>
                            </tr>
                        )}
                    </tbody>
                </Table>
            </Row>
        </Container>
    );
});

export default TableGrandPrixClassification;