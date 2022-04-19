import React from "react";
import { Container } from "react-bootstrap";
import SeasonsList from "../components/Lists/SeasonsList";
import Title from "../components/Titles/Title";
import { SEASONS_TITLE } from "../utils/TitleNameConst";

const Seasons = () => {

    return (
        <Container fluid>
            <Title name={SEASONS_TITLE}/>
            <SeasonsList/>
        </Container>
    );
};

export default Seasons;