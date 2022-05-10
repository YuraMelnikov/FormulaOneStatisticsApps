import React, { useEffect, useContext } from 'react';
import { useParams } from 'react-router-dom';
import { observer } from "mobx-react-lite";
import Table from 'react-bootstrap/Table';
import { Context } from "../../index";
import { Container, Row } from 'react-bootstrap';
import NumberFormat from 'react-number-format';
import TitleSmall from '../Titles/TitleSmall';
import { fetchSeasonCalendar } from "../../http/API";
import { useHistory } from "react-router-dom";
import { RACER_ROUTE, MANUFACTURER_ROUTE, TRACK_ROUTE, GRANDPRIX_ROUTE } from '../../utils/Constants';
import { 
    CALENDAR,
    DATE,
    WIN,
    NAME,
    TRACK,
    LAPS,
    DISTANCE,
    RACER,
    CHASSIS} 
from "../../utils/TitleNameConst";

const TableSeasonCalendar = observer(() => {
    const history = useHistory()
    const {openApiData} = useContext(Context)
    const {id} = useParams()

    useEffect(() => {
        fetchSeasonCalendar(id).then(data => openApiData.setSeasonCalendar(data))
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [])

    return (
        <Container>
            <Row>
                <TitleSmall name={CALENDAR}/>
                <Table striped bordered hover size="sm">
                    <thead>
                        <tr className="text-center">
                            <th>{DATE}</th>
                            <th>{NAME}</th>
                            <th>{TRACK}</th>
                            <th>{LAPS}</th>
                            <th>{DISTANCE}</th>
                            <th>{RACER + " " + WIN}</th>
                            <th>{CHASSIS + " " + WIN}</th>
                        </tr>
                    </thead>
                    <tbody>
                        {openApiData.seasonCalendar.map(calendar =>
                            <tr key={calendar.idGrandPrix}>
                                <td style={{cursor: 'pointer'}} onClick={() => history.push(GRANDPRIX_ROUTE + '/' + calendar.idGrandPrix)} className="text-center">{calendar.date}</td>
                                <td >{calendar.name}</td>
                                <td style={{cursor: 'pointer'}} onClick={() => history.push(TRACK_ROUTE + '/' + calendar.idTrack)}>{calendar.trackName}</td>
                                <td className="text-center">{calendar.lap}</td>
                                <td className="text-center">
                                    <NumberFormat 
                                        value={calendar.distance} 
                                        displayType={'text'} 
                                        thousandsGroupStyle="thousand"
                                        thousandSeparator={true}
                                        allowNegative={true}
                                        decimalScale={2}
                                    />
                                </td>
                                <td style={{cursor: 'pointer'}} onClick={() => history.push(RACER_ROUTE + '/' + calendar.idWinnerRacer)}>{calendar.racerWinner}</td>
                                <td style={{cursor: 'pointer'}} onClick={() => history.push(MANUFACTURER_ROUTE + '/' + calendar.idWinnerTeam)}>{calendar.teamWinner}</td>
                            </tr>
                        )}
                    </tbody>
                </Table>
            </Row>
        </Container>
    );
});

export default TableSeasonCalendar;