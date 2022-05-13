import React, {useContext, useEffect, useState} from 'react';
import { observer } from "mobx-react-lite";
import { Container, Dropdown, Table, Card, Col, Row } from "react-bootstrap";
import { Pencil } from 'react-bootstrap-icons';
import {Context} from '../index';
import { 
    GRAND_PRIX,
    ADMIN_TITLE, 
    CHANGE_ELEMENT } from "../utils/TitleNameConst";
import TitleSmall from '../components/Titles/TitleSmall';
import { fetchGrandPrix } from "../http/API";
import UpdateGrandPrix from '../components/Modals/UpdateGrandPrix';
import TableAdminParticipant from '../components/Tables/TableAdminParticipant';
import TableAdminQualification from '../components/Tables/TableAdminQualification';
import TableAdminClassification from '../components/Tables/TableAdminClassification';
import CreateImage from '../components/Modals/CreateImage';
import InfoAdminFastLap from '../components/Info/InfoAdminFastLap';
import TableAdminGrandPrixLeaderLap from '../components/Tables/TableAdminGrandPrixLeaderLap';

const AdminSeason = observer(() => {
    const{openApiData} = useContext(Context)

    const [grandPrixVisible, setGrandPrixVisible] = useState(false)
    const [imageVisible, setImageVisible] = useState(false)

    useEffect(() => {
        if(grandPrixVisible === false) {
            fetchGrandPrix().then(data => openApiData.setGrandPrix(data))
            openApiData.setSelectItem({})
        }
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [grandPrixVisible])

    return (
        <Container className="d-flex flex-column">
            <TitleSmall name={ADMIN_TITLE}/>
            <CreateImage
                show={imageVisible}
                onHide={() => setImageVisible(false)}
            />
            <UpdateGrandPrix
                    show={grandPrixVisible} 
                    onHide={() => setGrandPrixVisible(false)}
                    id={openApiData.selectItem.id}
            />
            <InfoAdminFastLap id={openApiData.selectItem.id}/>
            <TableAdminGrandPrixLeaderLap id={openApiData.selectItem.id}/>
            <Dropdown className="mt-2 mb-2">
                <Dropdown.Toggle>{CHANGE_ELEMENT + GRAND_PRIX}</Dropdown.Toggle>
                <Dropdown.Menu>
                    <Table striped bordered hover size="sm">
                        <tbody>
                            {openApiData.grandPrix.map(gp =>
                                <Dropdown.Item onClick={function(){openApiData.setSelectItem(gp); }} key={gp.id}>
                                    <tr>
                                        <td className="text-center">{gp.number}</td>
                                        <td>{gp.season}</td>
                                        <td>{gp.grandPrixNames}</td>
                                    </tr>
                                </Dropdown.Item>
                            )}
                        </tbody>
                    </Table>
                </Dropdown.Menu>
            </Dropdown>
            <Row>
                <Col lg={8} md={8} sm={8} xl={8} xs={8} xxl={8} >
                    <Row>
                        <Col>
                            <td onClick={function(){ 
                                setGrandPrixVisible(true); 
                                openApiData.setSelectedImage({link: openApiData.selectItem.image}); 
                                }}>
                                <Pencil />
                            </td>
                        </Col>
                        <Col>{openApiData.selectItem.season}</Col>
                        <Col>{openApiData.selectItem.number}</Col>
                        <Col>{openApiData.selectItem.grandPrixNames}</Col>
                    </Row>
                </Col>
                <Col lg={4} md={4} sm={4} xl={4} xs={4} xxl={4} >
                    <Card.Img variant="top" src={openApiData.selectItem.image}/>
                </Col>
            </Row>
            <TableAdminParticipant id={openApiData.selectItem.id}/>
            <TableAdminQualification id={openApiData.selectItem.id}/>
            <TableAdminClassification id={openApiData.selectItem.id}/>
        </Container>
    );
});

export default AdminSeason;