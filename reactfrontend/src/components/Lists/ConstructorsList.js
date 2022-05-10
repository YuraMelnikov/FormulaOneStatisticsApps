import React, { useContext, useEffect } from 'react';
import { observer } from "mobx-react-lite";
import { Row } from "react-bootstrap";
import {fetchConstructors} from "../../http/API";
import {Context} from "../../index";
import CardItem from '../Cards/CardItem';
import { CONSTRUCTOR_ROUTE } from '../../utils/Constants';

const ConstructorsList = observer(() => {
    const {openApiData} = useContext(Context)

    useEffect(() => {
        if(openApiData.constructors.length === 0) {
            fetchConstructors().then(data => openApiData.setConstructors(data))
        }
    }, [openApiData])
    
    return (
        <Row className="d-flex">
            {openApiData.constructors.map(constructors =>
                <CardItem key={constructors.name} data={constructors} route={CONSTRUCTOR_ROUTE}/>
            )}
        </Row>
    );
});

export default ConstructorsList;