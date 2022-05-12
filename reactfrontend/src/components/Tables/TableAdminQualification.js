import React, { useEffect, useContext } from 'react';
import { observer } from "mobx-react-lite";
import Table from 'react-bootstrap/Table';
import { Context } from "../../index";
import { Container, Row } from 'react-bootstrap';
import TitleSmall from '../Titles/TitleSmall';
import { fetchGpQualification } from "../../http/API";
import { 
    GAP,
    RACER,
    POSITION,
    ENGINE,
    TIME,
    QUALIFICATION,
    CHASSIS} 
from "../../utils/TitleNameConst";

const TableAdminQualification = observer((id) => {
    const {openApiData} = useContext(Context)

    useEffect(() => {
        if(id.id !== undefined){
            fetchGpQualification(id.id).then(data => openApiData.setGpQualification(data))
        }
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [id])

    return (
        <Container>
            <Row>
                <TitleSmall name={QUALIFICATION}/>
                <Table striped bordered hover size="sm">
                    <thead>
                        <tr className="text-center">
                            <th>{POSITION}</th>
                            <th>{RACER}</th>
                            <th>{CHASSIS}</th>
                            <th>{ENGINE}</th>
                            <th>{TIME}</th>
                            <th>{GAP}</th>
                        </tr>
                    </thead>
                    <tbody>
                        {openApiData.gpQualification.map(result =>
                            <tr key={result.idRacer}>
                                <td className="text-center">{result.position}</td>
                                <td>{result.racer}</td>
                                <td>{result.chassis}</td>
                                <td>{result.engine}</td>
                                <td>{result.time}</td>
                                <td>{result.gap}</td>
                            </tr>
                        )}
                    </tbody>
                </Table>
            </Row>
        </Container>
    );
});

export default TableAdminQualification;