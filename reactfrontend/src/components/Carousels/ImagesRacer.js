import React, { useEffect, useContext } from 'react';
import { useParams } from 'react-router-dom';
import { observer } from "mobx-react-lite";
import { Context } from "../../index";
import { Container, Carousel } from 'react-bootstrap';
import { fetchRacerImages } from "../../http/API";
import { Card } from "react-bootstrap"; 

const ImagesRacer = observer(() => {
    const {openApiData} = useContext(Context)
    const {id} = useParams()

    useEffect(() => {
        fetchRacerImages(id).then(data => openApiData.setRacerImages(data))
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [])

    return (
        <Container>
            <Carousel>
                {openApiData.racerImages.map(result =>
                    <Carousel.Item>
                        <Card.Img variant="top" src={result.link}/>
                    </Carousel.Item>
                )}
            </Carousel>
        </Container>
    );
});

export default ImagesRacer;