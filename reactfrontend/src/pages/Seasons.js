import { observer } from "mobx-react-lite";
import React, { useContext, useEffect } from "react";
import { Container } from "react-bootstrap";
import { Context } from "../index";
import SeasonsList from "../components/SeasonsList";
import Title from "../components/Title";
import { fetchSeasons } from "../http/SeasonsAPI";

const Seasons = observer( () => {
    const {seasons} = useContext(Context)

    useEffect(() => {
        fetchSeasons().than(data => seasons.setSeasons(data))
    }, [])

    return (
        <Container fluid>
            <Title name="Seasons"/>
            <SeasonsList/>
        </Container>
    );
});

export default Seasons;