import React, { useEffect, useContext } from 'react';
import { useParams } from 'react-router-dom';
import { observer } from "mobx-react-lite";
import { Context } from "../../index";
import { Container, Carousel } from 'react-bootstrap';
import { fetchGpImages } from "../../http/API";
import { Card } from "react-bootstrap"; 

const ImagesGrandPrix = observer(() => {
    const {openApiData} = useContext(Context)
    const {id} = useParams()

    useEffect(() => {
        fetchGpImages(id).then(data => openApiData.setGpImages(data))
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [])

    return (
        <Container>
            <Carousel>
                {openApiData.gpImages.map(result =>
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

export default ImagesGrandPrix;