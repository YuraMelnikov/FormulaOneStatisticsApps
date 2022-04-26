import React, { useContext, useEffect } from 'react';
import { observer } from "mobx-react-lite";
import {fetchChassisInfo} from "../../http/API";
import {Context} from "../../index";
import { Card } from "react-bootstrap"; 
import { useParams } from 'react-router-dom';

const InfoChassis = observer(() => {
    const {openApiData} = useContext(Context)
    const {id} = useParams()

    useEffect(() => {
        fetchChassisInfo(id).then(data => openApiData.setChassisInfo(data))
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [])

    return (
        <div>
            <p>{openApiData.chassisInfo.name}</p>
            <p>{openApiData.chassisInfo.points}</p>
            <p>{openApiData.chassisInfo.win}</p>
            <p>{openApiData.chassisInfo.polePosition}</p>
            <p>{openApiData.chassisInfo.fastLap}</p>
            <p>{openApiData.chassisInfo.topStart}</p>
            <p>{openApiData.chassisInfo.topFinish}</p>
            <Card.Img variant="top" src={openApiData.constructorInfo.livery}/>
            <Card.Img variant="top" src={openApiData.constructorInfo.image}/>
        </div>
    );
});

export default InfoChassis;