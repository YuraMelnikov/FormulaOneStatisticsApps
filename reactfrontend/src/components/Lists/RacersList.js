import React, { useContext, useEffect } from 'react';
import { observer } from "mobx-react-lite";
import { Row } from "react-bootstrap";
import {fetchRacers} from "../../http/API";
import {Context} from "../../index";
import CardItem from '../Cards/CardItem';
import { RACER_ROUTE } from '../../utils/Constants';

const RacersList = observer(() => {
    const {openApiData} = useContext(Context)

    useEffect(() => {
        if(openApiData.racers.length === 0) {
            fetchRacers().then(data => openApiData.setRacers(data))
        }
    }, [openApiData])
    
    return (
        <Row className="d-flex">
            {openApiData.racers.map(racer =>
                <CardItem key={racer.id} data={racer} route={RACER_ROUTE}/>
            )}
        </Row>
    );
});

export default RacersList;