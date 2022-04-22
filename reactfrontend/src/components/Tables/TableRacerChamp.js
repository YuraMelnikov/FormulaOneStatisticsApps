import React, { useEffect, useContext } from 'react';
import { useParams } from 'react-router-dom';
import { observer } from "mobx-react-lite";
import Table from 'react-bootstrap/Table';
import { Context } from "../../index";
import { Container, Row } from 'react-bootstrap';
import TitleSmall from '../Titles/TitleSmall';
import { fetchRacerClassifications } from "../../http/API";
import { useHistory } from "react-router-dom";
import { GRANDPRIX_ROUTE } from '../../utils/Constants';

const TableRacerChamp = observer(() => {
    const history = useHistory()
    const {openApiData} = useContext(Context)
    const {id} = useParams()

    useEffect(() => {
        fetchRacerClassifications(id).then(data => openApiData.setRacerClassifications(data))
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [])

    const max = openApiData.racerClassifications.reduce((acc, shot) => acc = acc > shot.result ? acc : shot.result.length, 0);

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
                        {openApiData.racerClassifications.map(seasonResult =>
                            <tr key={ seasonResult.season }>
                                <td className="text-center">{seasonResult.season}</td>
                                    {seasonResult.result.map(resultGrandPrix =>
                                        
                                        <td>
                                                <p className="text-center" style={{cursor: 'pointer'}} onClick={() => history.push(GRANDPRIX_ROUTE + '/' + resultGrandPrix.id)}>{resultGrandPrix.name}</p>
                                                <p className="text-center">{resultGrandPrix.racePosition}</p>
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

export default TableRacerChamp;