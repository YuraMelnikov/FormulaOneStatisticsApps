import React, { useState } from 'react';
import Modal from "react-bootstrap/Modal";
import { Button, Form } from "react-bootstrap";
import { createConstructor } from "../../http/API";
import { observer } from "mobx-react-lite";

const CreateConstructor = observer(({ show, onHide }) => {
    const [name, setName] = useState('')
    const [idCountry, setIdCountry] = useState('')

    const addCountry = () => {
        const formData  = new FormData()
        formData.append('name', name)
        formData.append('idCountry', idCountry)
        createConstructor(formData).then(data => data === false ? setName() : onHide())
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
                </Form>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="outline-danger" onClick={onHide}>Close</Button>
                <Button variant="outline-success" onClick={addCountry}>Added</Button>
            </Modal.Footer>
        </Modal>
    );
});

export default CreateConstructor;