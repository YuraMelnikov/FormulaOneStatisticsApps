import React from "react";
import { Card, Col } from "react-bootstrap"; 
import { useHistory } from "react-router-dom";
import {SEASON_ROUTE} from '../utils/Consts';

const CardItem = ({mockData}) => {
    const history = useHistory()

    return (
        <Col md={2} className='mt-3' onClick={() => history.push(SEASON_ROUTE + '/' + mockData.id)}>
            <Card style={{cursor: 'pointer'}} className="text-center" border="light">
                <Card.Img variant="top" src={mockData.imageLink}/>
                <Card.Body>
                    <Card.Title>{mockData.name}</Card.Title>
                </Card.Body>
            </Card>
        </Col>
    );
}

export default CardItem;