import React, { useContext, useEffect } from 'react';
import { observer } from "mobx-react-lite";
import {fetchGpFastLap} from "../../http/API";
import {Context} from "../../index";

const InfoAdminFastLap = observer((id) => {
    const {openApiData} = useContext(Context)

    useEffect(() => {
        if(id.id !== undefined){
            fetchGpFastLap(id.id).then(data => openApiData.setGpFastLap(data))
        }
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [id])

    return (
        <div>
            <p>{openApiData.gpFastLap.racer}</p>
            <p>{openApiData.gpFastLap.time}</p>
            <p>{openApiData.gpFastLap.averageSpeed}</p>
        </div>
    );
});

export default InfoAdminFastLap;