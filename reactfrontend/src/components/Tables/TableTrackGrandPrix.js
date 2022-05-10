import React, { useEffect, useContext } from 'react';
import { useParams } from 'react-router-dom';
import { observer } from "mobx-react-lite";
import Table from 'react-bootstrap/Table';
import { Context } from "../../index";
import { Container, Row } from 'react-bootstrap';
import TitleSmall from '../Titles/TitleSmall';
import { fetchTrackGrandPrix } from "../../http/API";
import { useHistory } from "react-router-dom";
import { RACER_ROUTE, CHASSIS_ROUTE, GRANDPRIX_ROUTE } from '../../utils/Constants';
import { 
    TRACKS_TITLE,
    NAME,
    WEATHER,
    CHASSIS,
    RACER,
    WIN,
    DATE,
    NUMBER} 
from "../../utils/TitleNameConst";

const TableTrackGrandPrix = observer(() => {
    const history = useHistory()
    const {openApiData} = useContext(Context)
    const {id} = useParams()

    useEffect(() => {
        fetchTrackGrandPrix(id).then(data => openApiData.setTrackGrandPrix(data))
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [])

    return(
        <Container>
            <Row>
                <TitleSmall name={TRACKS_TITLE}/>
                <Table striped bordered hover size="sm">
                    <thead>
                        <tr className="text-center">
                            <th>{NUMBER}</th>
                            <th>{DATE}</th>
                            <th>{NAME}</th>
                            <th>{WEATHER}</th>
                            <th>{WIN + " " + RACER}</th>
                            <th>{WIN + " " + CHASSIS}</th>
                        </tr>
                    </thead>
                    <tbody>
                        {openApiData.trackGrandPrix.map(grandPrix =>
                            <tr key={ grandPrix.id }>
                                <td className="text-center" style={{cursor: 'pointer'}} onClick={() => history.push(GRANDPRIX_ROUTE + '/' + grandPrix.id)}>{grandPrix.number}</td>
                                <td className="text-center" style={{cursor: 'pointer'}} onClick={() => history.push(GRANDPRIX_ROUTE + '/' + grandPrix.id)}>{grandPrix.date}</td>
                                <td className="text-center" style={{cursor: 'pointer'}} onClick={() => history.push(GRANDPRIX_ROUTE + '/' + grandPrix.id)}>{grandPrix.name}</td>
                                <td className="text-center">{grandPrix.weather}</td>
                                <td className="text-center" style={{cursor: 'pointer'}} onClick={() => history.push(RACER_ROUTE + '/' + grandPrix.idWinnerRacer)}>{grandPrix.racerWinner}</td>
                                <td className="text-center" style={{cursor: 'pointer'}} onClick={() => history.push(CHASSIS_ROUTE + '/' + grandPrix.idWinnerTeam)}>{grandPrix.teamWinner}</td>
                            </tr>
                        )}
                    </tbody>
                </Table>
            </Row>
        </Container>
    );
});

export default TableTrackGrandPrix;