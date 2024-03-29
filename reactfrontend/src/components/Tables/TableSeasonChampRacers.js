import React, { useEffect, useContext } from 'react';
import { useParams } from 'react-router-dom';
import { observer } from "mobx-react-lite";
import Table from 'react-bootstrap/Table';
import { Context } from "../../index";
import { Container, Row } from 'react-bootstrap';
import TitleSmall from '../Titles/TitleSmall';
import { fetchSeasonRacersResult } from "../../http/API";
import { useHistory } from "react-router-dom";
import { RACER_ROUTE, GRANDPRIX_ROUTE } from '../../utils/Constants';
import { 
    RACERS_TITLE,
    POINTS,
    POSITION,
    RACER,
    WORLD_TITLE} 
from "../../utils/TitleNameConst";

const TableSeasonChampRacers = observer(() => {
    let numGrandPrix = 0

    const history = useHistory()
    const {openApiData} = useContext(Context)
    const {id} = useParams()

    useEffect(() => {
        fetchSeasonRacersResult(id).then(data => openApiData.setSeasonRacersResult(data))
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [])

    return(
        <Container>
            <Row>
                <TitleSmall name={WORLD_TITLE + RACERS_TITLE}/>
                <Table striped bordered hover size="sm">
                    <thead>
                        <tr className="text-center">
                            <th>{POSITION}</th>
                            <th>{RACER}</th>
                            {openApiData.seasonCalendar.map(season => 
                                <th style={{cursor: 'pointer'}} onClick={() => history.push(GRANDPRIX_ROUTE + '/' + season.idGrandPrix)} className="text-center">{numGrandPrix += 1}</th>
                            )}
                            <th>{POINTS}</th>
                        </tr>
                    </thead>
                    <tbody>
                        {openApiData.seasonRacersResult.map(racer =>
                            <tr key={ racer.id }>
                                <td className="text-center">{racer.position}</td>
                                <td style={{cursor: 'pointer'}} onClick={() => history.push(RACER_ROUTE + '/' + racer.id)}>{racer.name}</td>
                                {racer.result.map(resultGrandPrix =>
                                    <td className="text-center">{resultGrandPrix.racePosition}</td>
                                )}
                                <td className="text-center">{racer.points}</td>
                            </tr>
                        )}
                    </tbody>
                </Table>
            </Row>
        </Container>
    );
});

export default TableSeasonChampRacers;