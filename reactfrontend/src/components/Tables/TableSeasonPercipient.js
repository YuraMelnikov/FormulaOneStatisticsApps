import React, { useEffect, useContext } from 'react';
import { useParams } from 'react-router-dom';
import Table from 'react-bootstrap/Table';
import { Context } from "../../index";
import { Container, Row } from 'react-bootstrap';
import { useHistory } from "react-router-dom";
import { RACER_ROUTE, MANUFACTURER_ROUTE } from '../../utils/Constants';
import TitleSmall from '../Titles/TitleSmall';
import { fetchSeasonPercipient } from "../../http/API";
import { observer } from "mobx-react-lite";
import { 
    RACERS_TITLE,
    PARTICIPANT,
    TEAM,
    CHASSIS,
    ENGINES,
    TYRES} 
from "../../utils/TitleNameConst";

const TableSeasonPercipient = observer(() => {
    const history = useHistory()
    const { openApiData } = useContext(Context)
    const { id } = useParams()

    useEffect(() => {
        fetchSeasonPercipient(id).then(data => openApiData.setSeasonPercipient(data))
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [])

    return (
        <Container>
            <Row>
                <TitleSmall name={PARTICIPANT}/>
                <Table striped bordered hover size="sm">
                    <thead>
                        <tr className="text-center">
                            <th>{TEAM}</th>
                            <th>{CHASSIS}</th>
                            <th>{ENGINES}</th>
                            <th>{RACERS_TITLE}</th>
                            <th>{TYRES}</th>
                        </tr>
                    </thead>
                    <tbody >
                        {openApiData.seasonPercipient.map(percipient =>
                            <tr key={percipient.idTeam} >
                                <td className="col-sm-3">{percipient.name}</td>
                                <td className="col-sm-3">
                                    {percipient.chassis.map(percipientChassis =>
                                        <p style={{cursor: 'pointer'}} onClick={() => history.push(MANUFACTURER_ROUTE + '/' + percipientChassis.id)}>{percipientChassis.name}</p>
                                    )}
                                </td>
                                <td className="col-sm-3">
                                    {percipient.engines.map(percipientEngines =>
                                        <p style={{cursor: 'pointer'}} onClick={() => history.push(MANUFACTURER_ROUTE + '/' + percipientEngines.id)}>{percipientEngines.name}</p>
                                    )}
                                </td>
                                <td className="col-sm-2">
                                    {percipient.racers.map(percipientRacers =>
                                        <p style={{cursor: 'pointer' }} onClick={() => history.push(RACER_ROUTE + '/' + percipientRacers.id)}>{percipientRacers.name}</p>
                                    )}
                                </td>
                                <td className="col-sm-1">
                                    {percipient.tyres.map(percipientTyres =>
                                        <p style={{cursor: 'pointer'}} onClick={() => history.push(MANUFACTURER_ROUTE + '/' + percipientTyres.id)}>{percipientTyres.name}</p>
                                    )}
                                </td>
                            </tr>
                        )}
                    </tbody>
                </Table>
            </Row>
        </Container>
    );
});

export default TableSeasonPercipient;