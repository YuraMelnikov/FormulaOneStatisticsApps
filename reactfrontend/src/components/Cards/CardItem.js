import React from "react";
import { Card, Col } from "react-bootstrap"; 
import { useHistory } from "react-router-dom";

const CardItem = ({data, route}) => {
    const history = useHistory()

    return (
        <Col md={2} className='mt-3' onClick={() => history.push({pathname: route + '/' + data.id }, data.name )}>
            <Card style={{cursor: 'pointer'}} className="text-center" border="light">
                <Card.Img variant="top" src={data.imageLink}/>
                <Card.Body>
                    <Card.Title>{data.name}</Card.Title>
                </Card.Body>
            </Card>
        </Col>
    );
}

export default CardItem;