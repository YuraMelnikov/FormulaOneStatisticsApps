import React, { useEffect, useContext } from 'react';
import { useParams } from 'react-router-dom';
import { observer } from "mobx-react-lite";
import Table from 'react-bootstrap/Table';
import { Context } from "../../index";
import { Container, Row } from 'react-bootstrap';
import TitleSmall from '../Titles/TitleSmall';
import { fetchGpParticipant } from "../../http/API";
import { useHistory } from "react-router-dom";
import { RACER_ROUTE, MANUFACTURER_ROUTE } from '../../utils/Constants';

const TableGrandPrixParticipant = observer(() => {
    const history = useHistory()
    const {openApiData} = useContext(Context)
    const {id} = useParams()

    useEffect(() => {
        fetchGpParticipant(id).then(data => openApiData.setGpParticipant(data))
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [])

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
                        {openApiData.gpParticipant.map(participant =>
                            <tr key={participant.no}>
                                <td className="text-center">{participant.no}</td>
                                <td>{participant.teamName}</td>
                                <td style={{cursor: 'pointer'}} onClick={() => history.push(RACER_ROUTE + '/' + participant.idRacer)}>{participant.racer}</td>
                                <td style={{cursor: 'pointer'}} onClick={() => history.push(MANUFACTURER_ROUTE + '/' + participant.idChassis)}>{participant.chassis}</td>
                                <td style={{cursor: 'pointer'}} onClick={() => history.push(MANUFACTURER_ROUTE + '/' + participant.idEngine)}>{participant.engine}</td>
                                <td style={{cursor: 'pointer'}} onClick={() => history.push(MANUFACTURER_ROUTE + '/' + participant.idTyre)}>{participant.tyre}</td>
                            </tr>
                        )}
                    </tbody>
                </Table>
            </Row>
        </Container>
    );
});

export default TableGrandPrixParticipant;