import React, { useEffect, useContext, useState } from 'react';
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
    RUS,
    TYRE,
    TIME,
    AVR_SPEED,
    CHASSIS,
    CLASSIFICATION,
    NOTE} 
from "../../utils/TitleNameConst";
import { Pencil } from 'react-bootstrap-icons';
import UpdateGrandPrixResult from '../Modals/UpdateGrandPrixResult';

const TableAdminClassification = observer((id) => {
    const {openApiData} = useContext(Context)

    const [resultVisible, setResultVisible] = useState(false)
    const [idResult, setIdResult] = useState(undefined)

    useEffect(() => {
        if(id.id !== undefined){
            openApiData.setGpClassification([])
            fetchGpAdminClassification(id.id).then(data => openApiData.setGpClassification(data))
        }
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [id])

    return (
        <Container>
            <UpdateGrandPrixResult 
                id={idResult}
                show={resultVisible}
                onHide={() => setResultVisible(false)}
            />
            <Row>
                <TitleSmall name={CLASSIFICATION}/>
                <Table striped bordered hover size="sm">
                    <thead>
                        <tr className="text-center">
                            <th></th>
                            <th>{POSITION}</th>
                            <th>{RACER}</th>
                            <th>{CHASSIS}</th>
                            <th>{ENGINE}</th>
                            <th>{TYRE}</th>
                            <th>{LAPS}</th>
                            <th>{TIME}</th>
                            <th>{AVR_SPEED}</th>
                            <th>{POINTS}</th>
                            <th>{CLASSIFICATION}</th>
                            <th>{CLASSIFICATION + RUS}</th>
                            <th>{NOTE}</th>
                            <th>{NOTE + RUS}</th>
                        </tr>
                    </thead>
                    <tbody>
                        {openApiData.gpClassification.map(result =>
                            <tr key={result.idRacer}>
                                <td onClick={function(){setResultVisible(true); setIdResult(result.id)}}><Pencil /></td>
                                <td className="text-center">{result.positionNum}</td>
                                <td>{result.racer}</td>
                                <td>{result.chassis}</td>
                                <td>{result.engine}</td>
                                <td>{result.tyre}</td>
                                <td>{result.circles}</td>
                                <td>{result.time}</td>
                                <td>{result.avrSpeed}</td>
                                <td>{result.points}</td>
                                <td className="text-center">{result.position}</td>
                                <td>{result.classificationRus}</td>
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