import React, { useState, useContext, useEffect } from 'react';
import Modal from "react-bootstrap/Modal";
import { Button, Form, Dropdown } from "react-bootstrap";
import { createConstructor } from "../../http/API";
import { observer } from "mobx-react-lite";
import {Context} from '../../index';
import { 
    ADDED_ELEMENT, 
    INPUT_ELEMENT,
    BUTTON_CLOSE, 
    BUTTON_ADDED, 
    CONSTRUCTOR,
    NAME, 
    COUNTRY,
    CHANGE_ELEMENT } 
from "../../utils/TitleNameConst";

const CreateGrandPrix = observer(({ show, onHide }) => {
    const{openApiData} = useContext(Context)

    const [name, setName] = useState('')
    const [labelCountry, setLabelCountry] = useState('')

    useEffect(() => {
        setLabelCountry('')
        setName('')
        openApiData.setSelectedCountry({}) 
    // eslint-disable-next-line react-hooks/exhaustive-deps
    },[show])

    const addConstructor = () => {
        const formData  = new FormData()
        formData.append('name', name)
        formData.append('idCountry', openApiData.selectedCountry.id)
        createConstructor(formData).then(data => data === false ? setName('') : onHide)
    }

    return (
        <Modal show={show} onHide={onHide} centered>
            <Modal.Header closeButton>
                <Modal.Title id="contained-modal-title-vcenter">{ADDED_ELEMENT + GRAND_PRIX}</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Form>
                    <Form.Control
                        value={name}
                        onChange={e => setName(e.target.value)}
                        className="mt-3"
                        placeholder={INPUT_ELEMENT + DATE}
                        type="date"
                    />
                    
                    <Dropdown className="mt-2 mb-2">
                        <Dropdown.Toggle>{CHANGE_ELEMENT + COUNTRY}</Dropdown.Toggle>
                        <Dropdown.Menu>
                            {openApiData.country.map(gov =>
                                <Dropdown.Item onClick={function(){openApiData.setSelectedCountry(gov); setLabelCountry(gov.name)}} key={gov.id}>
                                    {gov.name}
                                </Dropdown.Item>
                            )}
                        </Dropdown.Menu>
                    </Dropdown>
                </Form>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="outline-danger" onClick={onHide}>{BUTTON_CLOSE}</Button>
                <Button variant="outline-success" onClick={addConstructor}>{BUTTON_ADDED}</Button>
            </Modal.Footer>
        </Modal>
    );
});

export default CreateGrandPrix;