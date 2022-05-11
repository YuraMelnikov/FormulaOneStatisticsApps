import React, {useState} from 'react';
import { Container, Button, Row, Col } from "react-bootstrap";
import TableAdminSeasons from '../components/Tables/TableAdminSeasons';
import TableAdminConstructors from '../components/Tables/TableAdminConstructors';
import TableAdminGrandPrixes from '../components/Tables/TableAdminGrandPrixes';
import CreateImage from '../components/Modals/CreateImage';
import { 
    BUTTON_ADD, 
    GRAND_PRIX,
    IMAGE, 
    ADMIN_TITLE, 
    LIST, 
    SEASON, 
    CONSTRUCTOR } from "../utils/TitleNameConst";
import Title from '../components/Titles/Title';

const Admin = () =>{
    const [imageVisible, setImageVisible] = useState(false)

    const [seasonListVisible, setSeasonListVisible] = useState(true)
    const [constructorsListVisible, setConstructorsListVisible] = useState(true)
    const [grandPrixListVisible, setGrandPrixListVisible] = useState(true)

    return (
        <Container className="d-flex flex-column">
            <Title name={ADMIN_TITLE}></Title>
            <Row>
                <Col>
                    <Button 
                        onClick={() => setImageVisible(true)}>
                            {BUTTON_ADD + IMAGE} 
                    </Button>
                </Col>
                <Col></Col>
                <Col></Col>
                <Col></Col>
                <Col></Col>
                <Col></Col>
            </Row>
            <hr></hr>
            <Row>
                <Col>
                    <Button 
                        onClick={() => seasonListVisible === true ? setSeasonListVisible(false) : setSeasonListVisible(true)}>
                            {SEASON + LIST}
                    </Button>
                </Col>
                <Col>
                    <Button 
                        onClick={() => constructorsListVisible === true ? setConstructorsListVisible(false) : setConstructorsListVisible(true)}>
                            {CONSTRUCTOR + LIST}
                    </Button>
                </Col>
                <Col>
                    <Button 
                        onClick={() => grandPrixListVisible === true ? setGrandPrixListVisible(false) : setGrandPrixListVisible(true)}>
                            {GRAND_PRIX + LIST}
                    </Button>
                </Col>
                <Col></Col>
                <Col></Col>
            </Row>
            <hr></hr>
            <CreateImage
                show={imageVisible}
                onHide={() => setImageVisible(false)}
            />
            <div hidden={seasonListVisible}>
                <TableAdminSeasons/>
            </div>
            <div hidden={constructorsListVisible}>
                <TableAdminConstructors/>
            </div>
            <div hidden={grandPrixListVisible}>
                <TableAdminGrandPrixes/>
            </div>
        </Container>
    );
}

export default Admin;