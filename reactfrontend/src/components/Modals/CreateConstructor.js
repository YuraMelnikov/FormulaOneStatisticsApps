import React, { useState, useContext, useEffect } from 'react';
import Modal from "react-bootstrap/Modal";
import { Button, Form, Dropdown } from "react-bootstrap";
import { createConstructor } from "../../http/API";
import { observer } from "mobx-react-lite";
import {Context} from '../../index';

const CreateConstructor = observer(({ show, onHide }) => {
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
                <Modal.Title id="contained-modal-title-vcenter">Added constructor</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Form>
                    <Form.Control
                        value={name}
                        onChange={e => setName(e.target.value)}
                        className="mt-3"
                        placeholder="Input name"
                        type="text"
                    />
                     <h4>{labelCountry}</h4>
                    <Dropdown className="mt-2 mb-2">
                        <Dropdown.Toggle>{"Change country"}</Dropdown.Toggle>
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
                <Button variant="outline-danger" onClick={onHide}>Close</Button>
                <Button variant="outline-success" onClick={addConstructor}>Added</Button>
            </Modal.Footer>
        </Modal>
    );
});

export default CreateConstructor;