import React, { useEffect, useContext } from 'react';
import { useParams } from 'react-router-dom';
import { observer } from "mobx-react-lite";
import Table from 'react-bootstrap/Table';
import { Context } from "../../index";
import { Container, Row } from 'react-bootstrap';
import TitleSmall from '../Titles/TitleSmall';
import { fetchConstructorClassifications } from "../../http/API";
import { useHistory } from "react-router-dom";
import { GRANDPRIX_ROUTE } from '../../utils/Constants';

const TableConstructorChamp = observer(() => {
    const history = useHistory()
    const {openApiData} = useContext(Context)
    const {id} = useParams()

    useEffect(() => {
        fetchConstructorClassifications(id).then(data => openApiData.setConstructorClassifications(data))
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [])

    const max = openApiData.constructorClassifications.reduce((acc, shot) => acc = acc > shot.result.length ? acc : shot.result.length, 0);

    return(
        <Container>
            <Row>
                <TitleSmall name="World Championship for Drivers"/>
                <Table striped bordered hover size="sm">
                    <thead>
                        <tr className="text-center">
                            <th>Season</th>
                                {[...new Array(max)].map((_, index) => 
                                    {
                                        return (
                                            <th>{index + 1}</th>
                                        );
                                    }
                                )}
                            <th>Position</th>
                            <th>Points</th>
                        </tr>
                    </thead>
                    <tbody>
                        {openApiData.constructorClassifications.map(seasonResult =>
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
                                <td className="text-center">{seasonResult.points}</td>
                                <td className="text-center">{seasonResult.position}</td>
                            </tr>
                        )}
                    </tbody>
                </Table>
            </Row>
        </Container>
    );
});

export default TableConstructorChamp;