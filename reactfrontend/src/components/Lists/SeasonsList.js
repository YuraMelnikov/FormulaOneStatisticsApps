import React, { useContext, useEffect } from 'react';
import { observer } from "mobx-react-lite";
import { Row } from "react-bootstrap";
import {fetchSeasons} from "../../http/API";
import {Context} from "../../index";
import CardItem from '../Cards/CardItem';
import { SEASON_ROUTE } from '../../utils/Constants';

const SeasonsList = observer(() => {
    const {openApiData} = useContext(Context)

    useEffect(() => {
        if(openApiData.seasons.length === 0) {
            fetchSeasons().then(data => openApiData.setSeasons(data))
        }
    }, [openApiData])
    
    return (
        <Row className="d-flex">
            {openApiData.seasons.map(season =>
                <CardItem key={season.id} data={season} route={SEASON_ROUTE}/>
            )}
        </Row>
    );
});

export default SeasonsList;