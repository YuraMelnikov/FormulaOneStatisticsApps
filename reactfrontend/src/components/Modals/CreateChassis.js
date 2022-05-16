import React, { useState, useEffect,  useContext } from 'react';
import Modal from "react-bootstrap/Modal";
import { Button, Form, Dropdown } from "react-bootstrap";
import { createChassis, fetchManufacturers } from "../../http/API";
import { observer } from "mobx-react-lite";
import { 
    ADDED_ELEMENT, 
    MANUFACTURER,
    INPUT_ELEMENT,
    CHASSIS,
    CHANGE_ELEMENT,
    NAME,
    BUTTON_CLOSE, 
    BUTTON_ADDED } 
from "../../utils/TitleNameConst";
import {Context} from '../../index';

const CreateChassis = observer(({ show, onHide }) => {
    const{openApiData} = useContext(Context)

    const [name, setName] = useState('')
    const [manufacturer, setManufacturer] = useState({})

    useEffect(() => {
        if(show === true){
            setName('')
            setManufacturer({})
            if(openApiData.manufacturers.length === 0){
                fetchManufacturers().than(data => openApiData.setManufacturers(data))
            }
        }
    // eslint-disable-next-line react-hooks/exhaustive-deps
    },[show])

    const addChassis = () => {
        const formData  = new FormData()
        formData.append('name', name)
        formData.append('idManufacturer', manufacturer.id)
        createChassis(formData).then(data => data === false ? setName('') : onHide)
    }

    return (
        <Modal show={show} onHide={onHide} centered>
            <Modal.Header closeButton>
                <Modal.Title id="contained-modal-title-vcenter">{ADDED_ELEMENT + CHASSIS}</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Form>
                    <Form.Control
                        value={name}
                        onChange={e => setName(e.target.value)}
                        className="mt-3"
                        placeholder={INPUT_ELEMENT + NAME}
                        type="text"
                    />
                    <Dropdown className="mt-2 mb-2">
                        <Dropdown.Toggle>{CHANGE_ELEMENT + MANUFACTURER}</Dropdown.Toggle>
                        <Dropdown.Menu>
                            {openApiData.manufacturers.map(manufacturer =>
                                <Dropdown.Item onClick={() => setManufacturer(manufacturer)} key={manufacturer.id}>
                                    {manufacturer.name}
                                </Dropdown.Item>
                            )}
                        </Dropdown.Menu>
                    </Dropdown>
                    <h4>{manufacturer.name}</h4>
                </Form>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="outline-danger" onClick={() => onHide} >{BUTTON_CLOSE}</Button>
                <Button variant="outline-success" onClick={addChassis}>{BUTTON_ADDED}</Button>
            </Modal.Footer>
        </Modal>
    );
});

export default CreateChassis;