import React, { useEffect, useContext, useState } from 'react';
import { observer } from "mobx-react-lite";
import Table from 'react-bootstrap/Table';
import { Context } from "../../index";
import { Container, Row, Button } from 'react-bootstrap';
import TitleSmall from '../Titles/TitleSmall';
import { fetchSeasons } from "../../http/API";
import { Card } from "react-bootstrap"; 
import { Pencil } from 'react-bootstrap-icons';
import CreateSeason from '../../components/Modals/CreateSeason';
import UpdateSeason from '../../components/Modals/UpdateSeason';

const TableAdminManufacturers = observer(() => {
    const {openApiData} = useContext(Context)
    const [seasonVisible, setSeasonVisible] = useState(false)
    const [seasonUpdateVisible, setSeasonUpdateVisible] = useState(false)
    const [id, setId] = useState()

    useEffect(() => {
        if(seasonUpdateVisible === false & seasonVisible === false)
            fetchSeasons().then(data => openApiData.setSeasons(data))
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [seasonVisible, seasonUpdateVisible])

    return (
        <Container>
            <Row>
                <TitleSmall name="Seasons"/>
                <Button onClick={() => setSeasonVisible(true)}> Add new Season </Button>
                <CreateSeason show={seasonVisible} onHide={() => setSeasonVisible(false)}/>
                <UpdateSeason 
                    show={seasonUpdateVisible} 
                    onHide={() => setSeasonUpdateVisible(false)}
                    id={id}
                />
                <Table striped bordered hover size="sm">
                    <thead>
                        <tr className="text-center">
                            <th></th>
                            <th>Id</th>
                            <th>Name</th>
                            <th>Link</th>
                            <th>Image</th>
                        </tr>
                    </thead>
                    <tbody>
                        {openApiData.seasons.map(season =>
                            <tr key={season.id}>
                                <td onClick={function(){ setSeasonUpdateVisible(true); setId(season.id)}}><Pencil /></td>
                                <td className="text-center">{season.id}</td>
                                <td className="text-center">{season.name}</td>
                                <td className="text-center">{season.imageLink}</td>
                                <td><Card.Img variant="top" src={season.imageLink}/></td>
                            </tr>
                        )}
                    </tbody>
                </Table>
            </Row>
        </Container>
    );
});

export default TableAdminManufacturers;