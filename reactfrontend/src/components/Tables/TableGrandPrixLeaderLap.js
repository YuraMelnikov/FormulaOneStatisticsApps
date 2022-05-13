import React, { useEffect, useContext } from 'react';
import { useParams } from 'react-router-dom';
import { observer } from "mobx-react-lite";
import Table from 'react-bootstrap/Table';
import { Context } from "../../index";
import { Container, Row } from 'react-bootstrap';
import TitleSmall from '../Titles/TitleSmall';
import { fetchGpLeaderLap } from "../../http/API";
import { 
    LAST,
    RACER,
    LEADER_LAP,
    FIRST} 
from "../../utils/TitleNameConst";

const TableGrandPrixLeaderLap = observer(() => {
    const {openApiData} = useContext(Context)
    const {id} = useParams()

    useEffect(() => {
        fetchGpLeaderLap(id).then(data => openApiData.setGpLeaderLap(data))
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [])

    return (
        <Container>
            <Row>
                <TitleSmall name={LEADER_LAP}/>
                <Table striped bordered hover size="sm">
                    <thead>
                        <tr className="text-center">
                            <th>{RACER}</th>
                            <th>{FIRST}</th>
                            <th>{LAST}</th>
                        </tr>
                    </thead>
                    <tbody>
                        {openApiData.gpLeaderLap.map(lap =>
                            <tr>
                                <td>{lap.racer}</td>
                                <td className="text-center">{lap.first}</td>
                                <td className="text-center">{lap.last}</td>
                            </tr>
                        )}
                    </tbody>
                </Table>
            </Row>
        </Container>
    );
});

export default TableGrandPrixLeaderLap;