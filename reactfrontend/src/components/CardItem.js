import React from "react";
import { Card, Col } from "react-bootstrap"; 

const CardItem = ({mockData}) => {
    return (
        <Col md={2}>
            <Card>
                <Card.Body>
                    <Card.Title>{mockData.name}</Card.Title>
                </Card.Body>
                <Card.Img variant="top" src={mockData.imageLink}/>
            </Card>
        </Col>
    );
}

export default CardItem;