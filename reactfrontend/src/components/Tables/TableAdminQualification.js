import React, { useEffect, useContext, useState } from 'react';
import { observer } from "mobx-react-lite";
import Table from 'react-bootstrap/Table';
import { Context } from "../../index";
import { Container, Row } from 'react-bootstrap';
import TitleSmall from '../Titles/TitleSmall';
import { fetchGpQualification } from "../../http/API";
import { Pencil } from 'react-bootstrap-icons';
import { 
    GAP,
    RACER,
    POSITION,
    ENGINE,
    TIME,
    QUALIFICATION,
    CHASSIS} 
from "../../utils/TitleNameConst";
import UpdateQualification from '../Modals/UpdateQualification';

const TableAdminQualification = observer((id) => {
    const {openApiData} = useContext(Context)

    const [qualificationVisible, setQualificationVisible] = useState(false)
    const [idQualification, setIdQualification] = useState(undefined)

    useEffect(() => {
        if(id.id !== undefined){
            setIdQualification(undefined)
            fetchGpQualification(id.id).then(data => openApiData.setGpQualification(data))
        }
        else if(qualificationVisible === false & id.id !== undefined) {
            fetchGpQualification(id.id).then(data => openApiData.setGpQualification(data))
        }
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [id, qualificationVisible])

    return (
        <Container>
            <UpdateQualification 
                id={idQualification}
                show={qualificationVisible}
                onHide={() => setQualificationVisible(false)}
            />
            <Row>
                <TitleSmall name={QUALIFICATION}/>
                <Table striped bordered hover size="sm">
                    <thead>
                        <tr className="text-center">
                            <th></th>
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
                            <tr key={result.id}>
                                <td onClick={function(){setQualificationVisible(true); setIdQualification(result.id)}}><Pencil /></td>
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