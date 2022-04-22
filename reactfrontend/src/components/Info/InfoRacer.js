import React, { useContext, useEffect } from 'react';
import { observer } from "mobx-react-lite";
import {fetchRacerInfo} from "../../http/API";
import {Context} from "../../index";
import { Card } from "react-bootstrap"; 
import { useParams } from 'react-router-dom';

const InfoRacer = observer(() => {
    const {openApiData} = useContext(Context)
    const {id} = useParams()

    useEffect(() => {
        fetchRacerInfo(id).then(data => openApiData.setRacerInfo(data))
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [])

    return (
        <div>
            <Card.Img variant="top" src={openApiData.racerInfo.imgLink}/>
            <p>{openApiData.racerInfo.name}</p>
            <p>{openApiData.racerInfo.birthDay}</p>
        </div>
    );
});

export default InfoRacer;