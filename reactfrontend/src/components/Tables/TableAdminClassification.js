import React, { useEffect, useContext } from 'react';
import { observer } from "mobx-react-lite";
import Table from 'react-bootstrap/Table';
import { Context } from "../../index";
import { Container, Row } from 'react-bootstrap';
import TitleSmall from '../Titles/TitleSmall';
import { fetchGpAdminClassification } from "../../http/API";
import { 
    POINTS,
    RACER,
    POSITION,
    LAPS,
    ENGINE,
    TYRE,
    TIME,
    AVR_SPEED,
    CHASSIS,
    CLASSIFICATION,
    NOTE} 
from "../../utils/TitleNameConst";

const TableAdminClassification = observer((id) => {
    const {openApiData} = useContext(Context)

    useEffect(() => {
        if(id.id !== undefined){
            fetchGpAdminClassification(id.id).then(data => openApiData.setGpClassification(data))
        }
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [id])

    return (
        <Container>
            <Row>
                <TitleSmall name={CLASSIFICATION}/>
                <Table striped bordered hover size="sm">
                    <thead>
                        <tr className="text-center">
                            <th>{POSITION}</th>
                            <th>{POSITION}</th>
                            <th>{POSITION}</th>
                            <th>{RACER}</th>
                            <th>{CHASSIS}</th>
                            <th>{ENGINE}</th>
                            <th>{TYRE}</th>
                            <th>{LAPS}</th>
                            <th>{TIME}</th>
                            <th>{AVR_SPEED}</th>
                            <th>{POINTS}</th>
                            <th>{NOTE}</th>
                            <th>{NOTE}</th>
                        </tr>
                    </thead>
                    <tbody>
                        {openApiData.gpClassification.map(result =>
                            <tr key={result.idRacer}>
                                <td className="text-center">{result.position}</td>
                                <td className="text-center">{result.positionNum}</td>
                                <td>{result.classificationRus}</td>
                                <td>{result.racer}</td>
                                <td>{result.chassis}</td>
                                <td>{result.engine}</td>
                                <td>{result.tyre}</td>
                                <td>{result.circles}</td>
                                <td>{result.time}</td>
                                <td>{result.avrSpeed}</td>
                                <td>{result.points}</td>
                                <td>{result.note}</td>
                                <td>{result.noteRus}</td>
                            </tr>
                        )}
                    </tbody>
                </Table>
            </Row>
        </Container>
    );
});

export default TableAdminClassification;