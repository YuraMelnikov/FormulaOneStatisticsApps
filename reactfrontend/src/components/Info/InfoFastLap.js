import React, { useContext, useEffect } from 'react';
import { observer } from "mobx-react-lite";
import {fetchGpFastLap} from "../../http/API";
import {Context} from "../../index";
import { useParams } from 'react-router-dom';

const InfoFastLap = observer(() => {
    const {openApiData} = useContext(Context)
    const {id} = useParams()

    useEffect(() => {
        fetchGpFastLap(id).then(data => openApiData.setGpFastLap(data))
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [])

    return (
        <div>
            <p>{openApiData.gpFastLap.racer}</p>
            <p>{openApiData.gpFastLap.time}</p>
            <p>{openApiData.gpFastLap.averageSpeed}</p>
        </div>
    );
});

export default InfoFastLap;