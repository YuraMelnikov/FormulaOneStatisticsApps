import React, { useContext, useEffect } from 'react';
import { observer } from "mobx-react-lite";
import { Row } from "react-bootstrap";
import {fetchTracks} from "../../http/API";
import {Context} from "../../index";
import CardItem from '../Cards/CardItem';
import { TRACK_ROUTE } from '../../utils/Constants';

const TracksList = observer(() => {
    const {openApiData} = useContext(Context)

    useEffect(() => {
        if(openApiData.tracks.length === 0) {
            fetchTracks().then(data => openApiData.setTracks(data))
        }
    }, [openApiData])
    
    return (
        <Row className="d-flex">
            {openApiData.tracks.map(track =>
                <CardItem key={track.id} data={track} route={TRACK_ROUTE}/>
            )}
        </Row>
    );
});

export default TracksList;