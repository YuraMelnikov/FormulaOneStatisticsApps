import React, { useEffect, useContext, useState } from 'react';
import { observer } from "mobx-react-lite";
import Table from 'react-bootstrap/Table';
import { Context } from "../../index";
import { Container, Row, Button } from 'react-bootstrap';
import TitleSmall from '../Titles/TitleSmall';
import { fetchConstructors } from "../../http/API";
import { Card } from "react-bootstrap"; 
import { Pencil } from 'react-bootstrap-icons';
import CreateConstructor from '../../components/Modals/CreateConstructor';
import UpdateConstructor from '../../components/Modals/UpdateConstructor';

const TableAdminConstructors = observer(() => {
    const {openApiData} = useContext(Context)
    const [constructorVisible, setConstructorVisible] = useState(false)
    const [constructorUpdateVisible, setConstructorUpdateVisible] = useState(false)
    const [id, setId] = useState()

    useEffect(() => {
        if(constructorUpdateVisible === false & constructorVisible === false)
            fetchConstructors().then(data => openApiData.setConstructors(data))
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [constructorVisible, constructorUpdateVisible])

    return (
        <Container>
            <Row>
                <TitleSmall name="Seasons"/>
                <Button onClick={() => setConstructorVisible(true)}> Add new Constructor </Button>
                <CreateConstructor show={constructorVisible} onHide={() => setConstructorVisible(false)}/>
                <UpdateConstructor 
                    show={constructorUpdateVisible} 
                    onHide={() => setConstructorUpdateVisible(false)}
                    id={id}
                />
                <Table striped bordered hover size="sm">
                    <thead>
                        <tr className="text-center">
                            <th></th>
                            <th>Id</th>
                            <th>Name</th>
                            <th>Country</th>
                            <th>Logo</th>
                            <th>Image</th>
                        </tr>
                    </thead>
                    <tbody>
                        {openApiData.constructors.map(constructor =>
                            <tr key={constructor.id}>
                                <td onClick={function(){ setConstructorUpdateVisible(true); setId(constructor.id)}}><Pencil /></td>
                                <td className="text-center">{constructor.id}</td>
                                <td className="text-center">{constructor.name}</td>
                                <td className="text-center">{constructor.country}</td>
                                <td><Card.Img variant="top" src={constructor.imageLink}/></td>
                                <td><Card.Img variant="top" src={constructor.logo}/></td>
                            </tr>
                        )}
                    </tbody>
                </Table>
            </Row>
        </Container>
    );
});

export default TableAdminConstructors;