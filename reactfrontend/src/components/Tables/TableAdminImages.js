import React, { useEffect, useContext, useState } from 'react';
import { observer } from "mobx-react-lite";
import Table from 'react-bootstrap/Table';
import { Context } from "../../index";
import { Container, Row, Button } from 'react-bootstrap';
import TitleSmall from '../Titles/TitleSmall';
import { fetchImagesByCount, deleteImage } from "../../http/API";
import { Card } from "react-bootstrap"; 
import { Pencil } from 'react-bootstrap-icons';

const TableAdminImages = observer(() => {
    const {openApiData} = useContext(Context)
    const [isUpdate, setIsUpdate] = useState()

    useEffect(() => {
        fetchImagesByCount().then(data => openApiData.setImages(data))
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [isUpdate])

    const delImage = (image) => {    
        console.log(image.id)
        deleteImage(image.id).then(data => data === true ? setIsUpdate(image.id) : console.log('error'))
    }

    return (
        <Container>
            <Row>
                <TitleSmall name="Images"/>
               
                <Table striped bordered hover size="sm">
                    <thead>
                        <tr className="text-center">
                            <th></th>
                            <th>Id</th>
                            <th>Man</th>
                            <th>chassis</th>
                            <th>livery</th>
                            <th>countries</th>
                            <th>engine</th>
                            <th>grand</th>
                            <th>racer</th>
                            <th>season</th>       
                            <th>team</th>
                            <th>track</th>
                            <th>conf</th>
                            <th>tyre</th>
                            <th>img</th>
                        </tr>
                    </thead>
                    <tbody>
                        {openApiData.images.map(image =>
                            <tr key={image.id}>
                                <td onClick={function(){ delImage(image);}}><Pencil /></td>
                                <td className="text-center">{image.id}</td>
                                <td className="text-center">{image.manufacturersCount}</td>
                                <td className="text-center">{image.chassisCount}</td>
                                <td className="text-center">{image.liveryCount}</td>
                                <td className="text-center">{image.countriesCount}</td>
                                <td className="text-center">{image.enginesCount}</td>
                                <td className="text-center">{image.grandPrixesCount}</td>
                                <td className="text-center">{image.racersCount}</td>
                                <td className="text-center">{image.seasonsCount}</td>
                                <td className="text-center">{image.teamNamesCount}</td>
                                <td className="text-center">{image.tracksCount}</td>
                                <td className="text-center">{image.trackСonfigurationsCount}</td>
                                <td className="text-center">{image.tyresCount}</td>
                                <td><Card.Img variant="top" src={image.link}/></td>
                            </tr>
                        )}
                    </tbody>
                </Table>
            </Row>
        </Container>
    );
});

export default TableAdminImages;