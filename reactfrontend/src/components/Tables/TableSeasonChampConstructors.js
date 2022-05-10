import React, { useEffect, useContext } from 'react';
import { useParams } from 'react-router-dom';
import { observer } from "mobx-react-lite";
import Table from 'react-bootstrap/Table';
import { Context } from "../../index";
import { Container, Row } from 'react-bootstrap';
import TitleSmall from '../Titles/TitleSmall';
import { fetchSeasonConstResult } from "../../http/API";
import { useHistory } from "react-router-dom";
import { GRANDPRIX_ROUTE } from '../../utils/Constants';
import { 
    POINTS,
    POSITION,
    CONSTRUCTOR,
    WORLD_TITLE} 
from "../../utils/TitleNameConst";

const TableSeasonChampConstructors = observer(() => {
    let numGrandPrix = 0

    const history = useHistory()
    const {openApiData} = useContext(Context)
    const {id} = useParams()

    useEffect(() => {
        fetchSeasonConstResult(id).then(data => openApiData.setSeasonConstResult(data))
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [])

    return(
        <Container>
            <Row>
                <TitleSmall name={WORLD_TITLE + CONSTRUCTOR}/>
                <Table striped bordered hover size="sm">
                    <thead>
                        <tr className="text-center">
                            <th>{POSITION}</th>
                            <th>{CONSTRUCTOR}</th>
                            {openApiData.seasonCalendar.map(mockData => 
                                <th  style={{cursor: 'pointer'}} onClick={() => history.push(GRANDPRIX_ROUTE + '/' + mockData.idGrandPrix)} className="text-center">{numGrandPrix += 1}</th>
                            )}
                            <th>{POINTS}</th>
                        </tr>
                    </thead>
                    <tbody>
                        {openApiData.seasonConstResult.map(constructor =>
                            <tr key={ constructor.id }>
                                <td className="text-center">{constructor.position}</td>
                                <td>{constructor.name}</td>
                                {constructor.result.map(constResult =>
                                    <td className="text-center">{constResult.racePosition}</td>
                                )}
                                <td className="text-center">{constructor.points}</td>
                            </tr>
                        )}
                    </tbody>
                </Table>
            </Row>
        </Container>
    );
});

export default TableSeasonChampConstructors;