import React, { useContext, useEffect } from 'react';
import { observer } from "mobx-react-lite";
import {fetchConstructorInfo} from "../../http/API";
import {Context} from "../../index";
import { Card } from "react-bootstrap"; 
import { useParams } from 'react-router-dom';

const InfoConstructor = observer(() => {
    const {openApiData} = useContext(Context)
    const {id} = useParams()

    useEffect(() => {
        fetchConstructorInfo(id).then(data => openApiData.setConstructorInfo(data))
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [])

    return (
        <div>
            <p>{openApiData.constructorInfo.name}</p>
            <Card.Img variant="top" src={openApiData.constructorInfo.logo}/>
            <Card.Img variant="top" src={openApiData.constructorInfo.image}/>
        </div>
    );
});

export default InfoConstructor;