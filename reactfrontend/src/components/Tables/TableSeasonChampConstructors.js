import React, { useEffect, useContext } from 'react';
import { useParams } from 'react-router-dom';
import { observer } from "mobx-react-lite";
import Table from 'react-bootstrap/Table';
import { Context } from "../../index";
import { Container, Row } from 'react-bootstrap';
import TitleSmall from '../TitleSmall';
import { fetchSeasonConstResult } from "../../http/API";
import { useHistory } from "react-router-dom";
import { GRANDPRIX_ROUTE } from '../../utils/Constants';

const TableSeasonChampConstructors = observer(() => {
    let numGrandPrix = 0

    const history = useHistory()
    const {openApiData} = useContext(Context)
    const {id} = useParams()

    useEffect(() => {
        fetchSeasonConstResult(id).then(data => openApiData.setSeasonConstResult(data))
    }, [])

    return(
        <Container>
            <Row>
                <TitleSmall name="World Championship for Constructors"/>
                <Table striped bordered hover size="sm">
                    <thead>
                        <tr className="text-center">
                            <th>Position</th>
                            <th>Constructor</th>
                            {openApiData.seasonCalendar.map(mockData => 
                                <th  style={{cursor: 'pointer'}} onClick={() => history.push(GRANDPRIX_ROUTE + '/' + mockData.idGrandPrix)} className="text-center">{numGrandPrix += 1}</th>
                            )}
                            <th>Points</th>
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