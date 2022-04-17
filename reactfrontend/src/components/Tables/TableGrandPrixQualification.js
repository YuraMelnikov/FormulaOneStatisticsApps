import React, { useEffect, useContext } from 'react';
import { useParams } from 'react-router-dom';
import { observer } from "mobx-react-lite";
import Table from 'react-bootstrap/Table';
import { Context } from "../../index";
import { Container, Row } from 'react-bootstrap';
import TitleSmall from '../TitleSmall';
import { fetchGpQualification } from "../../http/API";
import { useHistory } from "react-router-dom";
import { RACER_ROUTE, MANUFACTURER_ROUTE } from '../../utils/Constants';

const TableGrandPrixQualification = observer(() => {
    const history = useHistory()
    const {openApiData} = useContext(Context)
    const {id} = useParams()

    useEffect(() => {
        fetchGpQualification(id).then(data => openApiData.setGpQualification(data))
    }, [])

    return (
        <Container>
            <Row>
                <TitleSmall name="Qualification"/>
                <Table striped bordered hover size="sm">
                    <thead>
                        <tr className="text-center">
                            <th>Position</th>
                            <th>Racer</th>
                            <th>Chassis</th>
                            <th>Engine</th>
                            <th>Time</th>
                            <th>Gap</th>
                        </tr>
                    </thead>
                    <tbody>
                        {openApiData.gpQualification.map(result =>
                            <tr key={result.position}>
                                <td className="text-center">{result.position}</td>
                                <td style={{cursor: 'pointer'}} onClick={() => history.push(RACER_ROUTE + '/' + result.idRacer)}>{result.racer}</td>
                                <td style={{cursor: 'pointer'}} onClick={() => history.push(MANUFACTURER_ROUTE + '/' + result.idChassis)}>{result.chassis}</td>
                                <td style={{cursor: 'pointer'}} onClick={() => history.push(MANUFACTURER_ROUTE + '/' + result.idEngine)}>{result.engine}</td>
                                <td>{result.time}</td>
                                <td>{result.gap}</td>
                            </tr>
                        )}
                    </tbody>
                </Table>
            </Row>
        </Container>
    );
});

export default TableGrandPrixQualification;