import React, { useEffect, useContext } from 'react';
import { useParams } from 'react-router-dom';
import { observer } from "mobx-react-lite";
import Table from 'react-bootstrap/Table';
import { Context } from "../../index";
import { Container, Row } from 'react-bootstrap';
import TitleSmall from '../Titles/TitleSmall';
import { fetchConstructorSeasons } from "../../http/API";
import { useHistory } from "react-router-dom";
import { SEASON_ROUTE, CHASSIS_ROUTE } from '../../utils/Constants';
import { Card } from "react-bootstrap"; 

const TableConstructorSeasons = observer(() => {
    const history = useHistory()
    const {openApiData} = useContext(Context)
    const {id} = useParams()

    useEffect(() => {
        fetchConstructorSeasons(id).then(data => openApiData.setConstructorSeasons(data))
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [])

    return (
        <Container>
            <Row>
                <TitleSmall name="Seasons"/>
                <Table striped bordered hover size="sm">
                    <thead>
                        <tr className="text-center">
                            <th>Season</th>
                            <th>Chassis</th>
                            <th>Livery</th>
                            <th>Points</th>
                            <th>Position</th>
                            <th>Win</th>
                            <th>Pole position</th>
                            <th>Fast lap</th>
                            <th>Top start</th>
                            <th>Top finish</th>
                        </tr>
                    </thead>
                    <tbody>
                        {openApiData.constructorSeasons.map(season =>
                            <tr key={season.idSeason}>
                                <td className="text-center" style={{cursor: 'pointer'}} onClick={() => history.push(SEASON_ROUTE + '/' + season.idSeason)}>{season.season}</td>
                                <td>
                                    {season.chassis.map(car =>
                                        <p style={{cursor: 'pointer'}} onClick={() => history.push(CHASSIS_ROUTE + '/' + car.idChassis)}>{car.chassis}</p>
                                    )}
                                </td>
                                <td>
                                    {season.livery.map(liv =>
                                        <Card.Img variant="top" src={liv.chassis}/>
                                    )}
                                </td>
                                <td className="text-center">{season.points}</td>
                                <td className="text-center">{season.position}</td>
                                <td className="text-center">{season.win}</td>
                                <td className="text-center">{season.polePosition}</td>
                                <td className="text-center">{season.fastLap}</td>
                                <td className="text-center">{season.topStart}</td>
                                <td className="text-center">{season.topFinish}</td>
                            </tr>
                        )}
                    </tbody>
                </Table>
            </Row>
        </Container>
    );
});

export default TableConstructorSeasons;