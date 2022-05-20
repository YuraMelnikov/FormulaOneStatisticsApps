import React, {useContext, useEffect, useState} from 'react';
import { observer } from "mobx-react-lite";
import { Container, Dropdown, Table, Card, Col, Row, Button } from "react-bootstrap";
import { Pencil } from 'react-bootstrap-icons';
import {Context} from '../index';
import { 
    GRAND_PRIX,
    BUTTON_ADD,
    IMAGE,
    TEAM,
    NAME,
    ENGINE,
    LENGTH,
    TRACK,
    CHASSIS,
    MANUFACTURER,
    ADMIN_TITLE, 
    CHANGE_ELEMENT } from "../utils/TitleNameConst";
import TitleSmall from '../components/Titles/TitleSmall';
import { fetchGrandPrix } from "../http/API";
import UpdateGrandPrix from '../components/Modals/UpdateGrandPrix';
import TableAdminParticipant from '../components/Tables/TableAdminParticipant';
import TableAdminQualification from '../components/Tables/TableAdminQualification';
import TableAdminClassification from '../components/Tables/TableAdminClassification';
import CreateImage from '../components/Modals/CreateImage';
import CreateManufacturer from '../components/Modals/CreateManufacturer';
import CreateEngine from '../components/Modals/CreateEngine';
import CreateChassis from '../components/Modals/CreateChassis';
import CreateTeam from '../components/Modals/CreateTeam';
import CreateTeamName from '../components/Modals/CreateTeamName';
import CreateTrack from '../components/Modals/CreateTrack';
import CreateTrackConfiguration from '../components/Modals/CreateTrackConfiguration';
import CreateGrandPrixName from '../components/Modals/CreateGrandPrixName';
import InfoAdminFastLap from '../components/Info/InfoAdminFastLap';
import TableAdminGrandPrixLeaderLap from '../components/Tables/TableAdminGrandPrixLeaderLap';

//
const AdminSeason = observer(() => {
    const{openApiData} = useContext(Context)
    const [grandPrixVisible, setGrandPrixVisible] = useState(false)
    const [imageVisible, setImageVisible] = useState(false)
    const [manufacturerVisible, setManufacturerVisible] = useState(false)
    const [chassisVisible, setChassisVisible] = useState(false)
    const [engineVisible, setEngineVisible] = useState(false)
    const [teamVisible, setTeamVisible] = useState(false)
    const [teamNameVisible, setTeamNameVisible] = useState(false)
    const [trackVisible, setTrackVisible] = useState(false)
    const [trackConfigurationVisible, setTrackConfigurationVisible] = useState(false)
    const [grandPrixNameVisible, setGrandPrixNameVisible] = useState(false)

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
            <CreateManufacturer show={manufacturerVisible} onHide={() => setManufacturerVisible(false)} />
            <CreateEngine show={engineVisible} onHide={() => setEngineVisible(false)} />
            <CreateChassis show={chassisVisible} onHide={() => setChassisVisible(false)} />
            <CreateImage show={imageVisible} onHide={() => setImageVisible(false)} />
            <UpdateGrandPrix show={grandPrixVisible}  onHide={() => setGrandPrixVisible(false)} id={openApiData.selectItem.id} />
            <CreateTeam show={teamVisible} onHide={() => setTeamVisible(false)} />
            <CreateTeamName show={teamNameVisible} onHide={() => setTeamNameVisible(false)} />
            <CreateTrack show={trackVisible} onHide={() => setTrackVisible(false)} />
            <CreateTrackConfiguration show={trackConfigurationVisible} onHide={() => setTrackConfigurationVisible(false)} />
            <CreateGrandPrixName show={grandPrixNameVisible} onHide={() => setGrandPrixNameVisible(false)} />
            <Row>
                <Col><Button onClick={() => setImageVisible(true)}>{BUTTON_ADD + IMAGE} </Button></Col>
                <Col><Button onClick={() => setManufacturerVisible(true)}>{BUTTON_ADD + MANUFACTURER} </Button></Col>
                <Col><Button onClick={() => setChassisVisible(true)}>{BUTTON_ADD + CHASSIS} </Button></Col>
                <Col><Button onClick={() => setEngineVisible(true)}>{BUTTON_ADD + ENGINE} </Button></Col>
                <Col><Button onClick={() => setTeamVisible(true)}>{BUTTON_ADD + TEAM} </Button></Col>
                <Col><Button onClick={() => setTeamNameVisible(true)}>{BUTTON_ADD + TEAM + NAME} </Button></Col>
                <Col><Button onClick={() => setTrackVisible(true)}>{BUTTON_ADD + TRACK } </Button></Col>
                <Col><Button onClick={() => setTrackConfigurationVisible(true)}>{BUTTON_ADD + TRACK + LENGTH} </Button></Col>
                <Col><Button onClick={() => setGrandPrixNameVisible(true)}>{BUTTON_ADD + GRAND_PRIX + NAME} </Button></Col>
            </Row>
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