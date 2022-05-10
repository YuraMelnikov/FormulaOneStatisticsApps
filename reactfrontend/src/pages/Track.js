import React from "react";
import Title from "../components/Titles/Title";
import ImagesTrack from "../components/Carousels/ImagesTrack";
import TableTrackConfigurations from "../components/Tables/TableTrackConfigurations";
import TableTrackGrandPrix from "../components/Tables/TableTrackGrandPrix";
import { Container } from "react-bootstrap";
import { TRACK } from "../utils/TitleNameConst";

const Track = () =>{
    return (
        <Container>
            <Title name={TRACK}/>
            <ImagesTrack/>
            <TableTrackConfigurations/>
            <TableTrackGrandPrix/>
        </Container>
    );
}

export default Track;