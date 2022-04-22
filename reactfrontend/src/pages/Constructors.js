import React from "react";
import { Container } from "react-bootstrap";
import ConstructorsList from "../components/Lists/ConstructorsList";
import Title from "../components/Titles/Title";
import { CONSTRUCTORS_TITLE } from "../utils/TitleNameConst";

const Constructors = () => {

    return (
        <Container fluid>
            <Title name={CONSTRUCTORS_TITLE}/>
            <ConstructorsList/>
        </Container>
    );
};

export default Constructors;