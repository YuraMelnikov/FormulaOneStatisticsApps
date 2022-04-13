import React, { useContext, useEffect } from 'react';
import { observer } from "mobx-react-lite";
import { Row } from "react-bootstrap";
import {fetchManufacturers} from "../../http/API";
import {Context} from "../../index";
import CardItem from '../Cards/CardItem';
import { MANUFACTURER_ROUTE } from '../../utils/Constants';

const ManufacturersList = observer(() => {
    const {openApiData} = useContext(Context)

    useEffect(() => {
        if(openApiData.manufacturers.length === 0) {
            fetchManufacturers().then(data => openApiData.setManufacturers(data))
        }
    }, [openApiData])
    
    return (
        <Row className="d-flex">
            {openApiData.manufacturers.map(manufacturer =>
                <CardItem key={manufacturer.id} data={manufacturer} route={MANUFACTURER_ROUTE}/>
            )}
        </Row>
    );
});

export default ManufacturersList;