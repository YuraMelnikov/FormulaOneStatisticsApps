import React, { useEffect, useContext } from 'react';
import { useParams } from 'react-router-dom';
import { observer } from "mobx-react-lite";
import { Context } from "../../index";
import { Container, Carousel } from 'react-bootstrap';
import { fetchConstructorImages } from "../../http/API";
import { Card } from "react-bootstrap"; 

const ImagesConstructor = observer(() => {
    const {openApiData} = useContext(Context)
    const {id} = useParams()

    useEffect(() => {
        fetchConstructorImages(id).then(data => openApiData.setConstructorImages(data))
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [])

    return (
        <Container>
            <Carousel>
                {openApiData.constructorImages.map(result =>
                    <Carousel.Item>
                        <Card.Img variant="top" src={result.link}/>,
                        <Carousel.Caption>
                            <p>{result.text}</p>
                        </Carousel.Caption>
                    </Carousel.Item>
                )}
            </Carousel>
        </Container>
    );
});

export default ImagesConstructor;