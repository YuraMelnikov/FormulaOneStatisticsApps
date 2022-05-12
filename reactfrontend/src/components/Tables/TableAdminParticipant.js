import React, { useEffect, useContext } from 'react';
import { observer } from "mobx-react-lite";
import Table from 'react-bootstrap/Table';
import { Context } from "../../index";
import { Container, Row } from 'react-bootstrap';
import TitleSmall from '../Titles/TitleSmall';
import { fetchGpParticipant } from "../../http/API";
import { 
    CONSTRUCTOR,
    RACER,
    ENGINE,
    TYRE,
    TEAM,
    CHASSIS,
    PARTICIPANT,
    NO} 
from "../../utils/TitleNameConst";

const TableAdminParticipant = observer((id) => {
    const {openApiData} = useContext(Context)

    useEffect(() => {
        if(id.id !== undefined){
            fetchGpParticipant(id.id).then(data => openApiData.setGpParticipant(data))
        }
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [id])

    return (
        <Container>
            <Row>
                <TitleSmall name={PARTICIPANT}/>
                <Table striped bordered hover size="sm">
                    <thead>
                        <tr className="text-center">
                            <th>{NO}</th>
                            <th>{TEAM}</th>
                            <th>{RACER}</th>
                            <th>{CHASSIS}</th>
                            <th>{ENGINE}</th>
                            <th>{TYRE}</th>
                            <th>{CONSTRUCTOR}</th>
                        </tr>
                    </thead>
                    <tbody>
                        {openApiData.gpParticipant.map(result =>
                            <tr key={result.idRacer}>
                                <td className="text-center">{result.no}</td>
                                <td>{result.teamName}</td>
                                <td>{result.racer}</td>
                                <td>{result.chassis}</td>
                                <td>{result.engine}</td>
                                <td>{result.tyre}</td>
                                <td>{result.constructor}</td>
                            </tr>
                        )}
                    </tbody>
                </Table>
            </Row>
        </Container>
    );
});

export default TableAdminParticipant;