import React, { useContext, useEffect } from 'react';
import { observer } from "mobx-react-lite";
import {fetchGpInfo} from "../../http/API";
import {Context} from "../../index";
import { Card } from "react-bootstrap"; 
import { useParams } from 'react-router-dom';

const InfoGrandPrix = observer(() => {
    const {openApiData} = useContext(Context)
    const {id} = useParams()

    useEffect(() => {
        fetchGpInfo(id).then(data => openApiData.setGpInfo(data))
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [])

    return (
        <div>
            <Card.Img variant="top" src={openApiData.gpInfo.imgLink}/>
            <Card.Img variant="top" src={openApiData.gpInfo.imgTrackLink}/>
            <p>{openApiData.gpInfo.name}</p>
            <p>{openApiData.gpInfo.trackName}</p>
            <p>{openApiData.gpInfo.numberInSeason}</p>
            <p>{openApiData.gpInfo.date}</p>
            <p>{openApiData.gpInfo.text}</p>
            <p>{openApiData.gpInfo.weather}</p>
        </div>
    );
});

export default InfoGrandPrix;