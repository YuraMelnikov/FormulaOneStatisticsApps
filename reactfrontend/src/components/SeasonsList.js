import React, {useContext} from 'react';
import {observer} from "mobx-react-lite";
import {Context} from "../index";
import {Row} from "react-bootstrap";
import SeasonItem from "./SeasonItem";

const SeasonsList = observer(() => {
    const {mockData} = useContext(Context)

    return (
        <Row className="d-flex">
            {mockData.manufacturers.map(mockData =>
                <SeasonItem key={mockData.id} mockData={mockData}/>
            )}
        </Row>
    );
});

export default SeasonsList;