import React, { useEffect, useContext } from 'react';
import { useParams } from 'react-router-dom';
import { observer } from "mobx-react-lite";
import Table from 'react-bootstrap/Table';
import { Context } from "../../index";
import { Container, Row } from 'react-bootstrap';
import TitleSmall from '../Titles/TitleSmall';
import { fetchChassisSeasons } from "../../http/API";
import { useHistory } from "react-router-dom";
import { SEASON_ROUTE, RACER_ROUTE, MANUFACTURER_ROUTE } from '../../utils/Constants';
import { 
    SEASONS_TITLE,
    TEAMS,
    ENGINES,
    TYRES,
    RACERS_TITLE} 
from "../../utils/TitleNameConst";

const TableChassisSeasons = observer(() => {
    const history = useHistory()
    const {openApiData} = useContext(Context)
    const {id} = useParams()

    useEffect(() => {
        fetchChassisSeasons(id).then(data => openApiData.setChassisSeasons(data))
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [])

    return (
        <Container>
            <Row>
                <TitleSmall name={SEASONS_TITLE}/>
                <Table striped bordered hover size="sm">
                    <thead>
                        <tr className="text-center">
                            <th>{SEASONS_TITLE}</th>
                            <th>{TEAMS}</th>
                            <th>{RACERS_TITLE}</th>
                            <th>{ENGINES}</th>
                            <th>{TYRES}</th>
                        </tr>
                    </thead>
                    <tbody>
                        {openApiData.chassisSeasons.map(item =>
                            <tr>
                                <td>
                                    {item.seasons.map(season =>
                                        <p style={{cursor: 'pointer'}} onClick={() => history.push(SEASON_ROUTE + '/' + season.id)}>{season.name}</p>
                                    )}
                                </td>
                                <td>
                                    {item.teams.map(team =>
                                        <p>{team.name}</p>
                                    )}
                                </td>
                                <td>
                                    {item.drivers.map(driver =>
                                        <p style={{cursor: 'pointer'}} onClick={() => history.push(RACER_ROUTE + '/' + driver.id)}>{driver.name}</p>
                                    )}
                                </td>
                                <td>
                                    {item.engines.map(engine =>
                                        <p style={{cursor: 'pointer'}} onClick={() => history.push(MANUFACTURER_ROUTE + '/' + engine.id)}>{engine.name}</p>
                                    )}
                                </td>
                                <td>
                                    {item.tyres.map(tyre =>
                                        <p style={{cursor: 'pointer'}} onClick={() => history.push(MANUFACTURER_ROUTE + '/' + tyre.id)}>{tyre.name}</p>
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

export default TableChassisSeasons;