import React, { useEffect, useContext } from 'react';
import { useParams } from 'react-router-dom';
import { observer } from "mobx-react-lite";
import Table from 'react-bootstrap/Table';
import { Context } from "../../index";
import { Container, Row } from 'react-bootstrap';
import TitleSmall from '../Titles/TitleSmall';
import { fetchTrackConfigurations } from "../../http/API";
import { useHistory } from "react-router-dom";
import { SEASON_ROUTE } from '../../utils/Constants';
import { Card } from "react-bootstrap"; 

const TableTrackConfigurations = observer(() => {
    const history = useHistory()
    const {openApiData} = useContext(Context)
    const {id} = useParams()

    useEffect(() => {
        fetchTrackConfigurations(id).then(data => openApiData.setTrackConfigurations(data))
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [])

    return(
        <Container>
            <Row>
                <TitleSmall name="World Championship for Drivers"/>
                <Table striped bordered hover size="sm">
                    <thead>
                        <tr className="text-center">
                            <th>Configuration</th>
                            <th>Length</th>
                            <th>Seasons</th>
                        </tr>
                    </thead>
                    <tbody>
                        {openApiData.trackConfigurations.map(configuration =>
                            <tr>
                                <td>
                                    <Card.Img variant="top" src={configuration.image}/>
                                </td>
                                <td className="text-center">{configuration.length}</td>
                                <td>
                                    {configuration.seasons.map(season => 
                                        <p className="text-center" style={{cursor: 'pointer'}} onClick={() => history.push(SEASON_ROUTE + '/' + season.id)}>{season.name}</p>
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

export default TableTrackConfigurations;