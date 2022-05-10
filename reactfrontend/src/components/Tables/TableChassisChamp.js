import React, { useEffect, useContext } from 'react';
import { useParams } from 'react-router-dom';
import { observer } from "mobx-react-lite";
import Table from 'react-bootstrap/Table';
import { Context } from "../../index";
import { Container, Row } from 'react-bootstrap';
import TitleSmall from '../Titles/TitleSmall';
import { fetchChassisClassifications } from "../../http/API";
import { useHistory } from "react-router-dom";
import { GRANDPRIX_ROUTE } from '../../utils/Constants';
import { 
    WORLD_TITLE,
    SEASON,
    RACERS_TITLE} 
from "../../utils/TitleNameConst";

const TableChassisChamp = observer(() => {
    const history = useHistory()
    const {openApiData} = useContext(Context)
    const {id} = useParams()

    useEffect(() => {
        fetchChassisClassifications(id).then(data => openApiData.setChassisClassifications(data))
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [])

    const max = openApiData.constructorClassifications.reduce((acc, shot) => acc = acc > shot.result.length ? acc : shot.result.length, 0);

    return(
        <Container>
            <Row>
                <TitleSmall name={WORLD_TITLE + RACERS_TITLE}/>
                <Table striped bordered hover size="sm">
                    <thead>
                        <tr className="text-center">
                            <th>{SEASON}</th>
                                {[...new Array(max)].map((_, index) => 
                                    {
                                        return (
                                            <th>{index + 1}</th>
                                        );
                                    }
                                )}
                        </tr>
                    </thead>
                    <tbody>
                        {openApiData.chassisClassifications.map(seasonResult =>
                            <tr key={ seasonResult.season }>
                                <td className="text-center">{seasonResult.season}</td>
                                    {seasonResult.result.map(resultGrandPrix =>
                                        <td>
                                            <p className="text-center" style={{cursor: 'pointer'}} onClick={() => history.push(GRANDPRIX_ROUTE + '/' + resultGrandPrix.id)}>{resultGrandPrix.name}</p>
                                            <div>
                                                {resultGrandPrix.position.map(pos =>
                                                    <p className="text-center">{pos}</p>
                                                )}
                                            </div>
                                        </td>
                                    )}
                                    {[...new Array(max - seasonResult.result.length)].map(() => 
                                        {
                                            return (
                                                <td></td>
                                            );
                                        }
                                    )}
                            </tr>
                        )}
                    </tbody>
                </Table>
            </Row>
        </Container>
    );
});

export default TableChassisChamp;