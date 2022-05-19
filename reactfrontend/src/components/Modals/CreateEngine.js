import React, { useState, useEffect,  useContext } from 'react';
import Modal from "react-bootstrap/Modal";
import { Button, Form, Dropdown } from "react-bootstrap";
import { createEngine, fetchManufacturers } from "../../http/API";
import { observer } from "mobx-react-lite";
import { 
    ADDED_ELEMENT, 
    MANUFACTURER,
    INPUT_ELEMENT,
    ENGINE,
    CHANGE_ELEMENT,
    NAME,
    BUTTON_CLOSE, 
    BUTTON_ADDED } 
from "../../utils/TitleNameConst";
import {Context} from '../../index';

const CreateEngine = observer(({ show, onHide }) => {
    const{openApiData} = useContext(Context)

    const [name, setName] = useState('')
    const [idManufacturer, setIdManufacturer] = useState('')

    useEffect(() => {
        if(show === true){
            setName('')
            setIdManufacturer('')
            if(openApiData.manufacturers.length === 0){
                const fetch = async () => {
                    const json = await fetchManufacturers()
                    openApiData.setManufacturers(json)
                }
                fetch()
            }
        }
    // eslint-disable-next-line react-hooks/exhaustive-deps
    },[show])

    const addEngine = () => {
        const formData  = new FormData()
        formData.append('name', name)
        formData.append('idManufacturer', idManufacturer)
        createEngine(formData).then(data => data === false ? setName('') : onHide())
    }

    return (
        <Modal show={show} onHide={onHide} centered>
            <Modal.Header closeButton>
                <Modal.Title id="contained-modal-title-vcenter">{ADDED_ELEMENT + ENGINE}</Modal.Title>
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
                                <Dropdown.Item onClick={() => setIdManufacturer(manufacturer.id)} key={manufacturer.id}>
                                    {manufacturer.name}
                                </Dropdown.Item>
                            )}
                        </Dropdown.Menu>
                    </Dropdown>
                    <h4>{idManufacturer}</h4>
                </Form>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="outline-danger" onClick={() => onHide} >{BUTTON_CLOSE}</Button>
                <Button variant="outline-success" onClick={addEngine}>{BUTTON_ADDED}</Button>
            </Modal.Footer>
        </Modal>
    );
});

export default CreateEngine;