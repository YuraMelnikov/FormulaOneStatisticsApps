import React, {useContext} from 'react';
import {observer} from "mobx-react-lite";
import {Context} from "../index";
import {Row} from "react-bootstrap";
import CardItem from "./CardItem";

const TracksList = observer(() => {
    const {mockData} = useContext(Context)

    return (
        <Row className="d-flex">
            {mockData.racers.map(mockData =>
                <CardItem key={mockData.id} mockData={mockData}/>
            )}
        </Row>
    );
});

export default TracksList;