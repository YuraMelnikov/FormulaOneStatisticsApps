import React, {useContext} from 'react';
import {observer} from "mobx-react-lite";
import {Context} from "../index";
import {Row} from "react-bootstrap";
import CardItem from "./CardItem";

const ManufacturersList = observer(() => {
    const {mockData} = useContext(Context)

    return (
        <Row className="d-flex">
            {mockData.manufacturers.map(mockData =>
                <CardItem key={mockData.id} mockData={mockData}/>
            )}
        </Row>
    );
});

export default ManufacturersList;