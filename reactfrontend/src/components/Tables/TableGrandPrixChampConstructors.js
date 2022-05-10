import React, { useEffect, useContext } from 'react';
import { useParams } from 'react-router-dom';
import { observer } from "mobx-react-lite";
import Table from 'react-bootstrap/Table';
import { Context } from "../../index";
import { Container, Row } from 'react-bootstrap';
import TitleSmall from '../Titles/TitleSmall';
import { fetchGpChampConstructors } from "../../http/API";
import { 
    POINTS,
    POSITION,
    NAME,
    CONSTRUCTORS_TITLE,
    STANDING_AFTER_RACE} 
from "../../utils/TitleNameConst";

const TableGrandPrixChampConstructors = observer(() => {
    const {openApiData} = useContext(Context)
    const {id} = useParams()

    useEffect(() => {
        fetchGpChampConstructors(id).then(data => openApiData.setGpChampConstructors(data))
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [])

    return (
        <Container>
            <Row>
                <TitleSmall name={CONSTRUCTORS_TITLE + STANDING_AFTER_RACE}/>
                <Table striped bordered hover size="sm">
                    <thead>
                        <tr className="text-center">
                            <th>{POSITION}</th>
                            <th>{NAME}</th>
                            <th>{POINTS}</th>
                        </tr>
                    </thead>
                    <tbody>
                        {openApiData.gpChampConstructors.map(result =>
                            <tr>
                                <td>{result.position}</td>
                                <td>{result.name}</td>
                                <td>{result.points}</td>
                            </tr>
                        )}
                    </tbody>
                </Table>
            </Row>
        </Container>
    );
});

export default TableGrandPrixChampConstructors;