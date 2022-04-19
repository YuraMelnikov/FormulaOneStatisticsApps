import React, { useEffect, useContext } from 'react';
import { useParams } from 'react-router-dom';
import { observer } from "mobx-react-lite";
import Table from 'react-bootstrap/Table';
import { Context } from "../../index";
import { Container, Row } from 'react-bootstrap';
import TitleSmall from '../Titles/TitleSmall';
import { fetchGpChampRacers } from "../../http/API";

const TableGrandPrixChampRacers = observer(() => {
    const {openApiData} = useContext(Context)
    const {id} = useParams()

    useEffect(() => {
        fetchGpChampRacers(id).then(data => openApiData.setGpChampRacers(data))
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [])

    return (
        <Container>
            <Row>
                <TitleSmall name="Racers standings after race"/>
                <Table striped bordered hover size="sm">
                    <thead>
                        <tr className="text-center">
                            <th>Position</th>
                            <th>Name</th>
                            <th>Points</th>
                        </tr>
                    </thead>
                    <tbody>
                        {openApiData.gpChampRacers.map(result =>
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

export default TableGrandPrixChampRacers;