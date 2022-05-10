import React from "react";
import { Container, Row } from "react-bootstrap";
import RacersList from "../components/Lists/RacersList";
import Title from "../components/Titles/Title";
import {RACERS_TITLE} from '../utils/TitleNameConst';

const Racers = () => {
    return (
        <Container fluid>
            <Row>
                <Title name={RACERS_TITLE}/>
                <RacersList/>
            </Row>
        </Container>
    );
}

export default Racers;