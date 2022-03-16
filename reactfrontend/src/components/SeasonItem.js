import React from "react";
import { Card, Col } from "react-bootstrap"; 



const SeasonItem = ({mockData}) => {
    const exampleImage = mockData.imageLink

    return (
        <Col md={2}>
            <Card>
                <Card.Body>
                    <Card.Title>{mockData.name}</Card.Title>
                </Card.Body>
                <Card.Img variant="top" src={exampleImage}/>
            </Card>
        </Col>
    );
}

export default SeasonItem;