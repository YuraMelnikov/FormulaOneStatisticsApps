import React, { useState, useEffect } from 'react';
import Modal from "react-bootstrap/Modal";
import { Button, Form } from "react-bootstrap";
import { createGrandPrixName } from "../../http/API";
import { observer } from "mobx-react-lite";
import { 
    ADDED_ELEMENT, 
    INPUT_ELEMENT,
    GRAND_PRIX,
    NAME,
    BUTTON_CLOSE, 
    BUTTON_ADDED } 
from "../../utils/TitleNameConst";

const CreateGrandPrixName = observer(({ show, onHide }) => {

    const [fullName, setFullName] = useState('')
    const [shortName, setShortName] = useState('')

    useEffect(() => {
        if(show === true){
            setFullName('')
            setShortName('')
        }
    // eslint-disable-next-line react-hooks/exhaustive-deps
    },[show])

    const addName = () => {
        const formData  = new FormData()
        formData.append('fullName', fullName)
        formData.append('shortName', shortName)
        createGrandPrixName(formData).then(data => data === false ? setFullName('') : onHide())
    }

    return (
        <Modal show={show} onHide={onHide} centered>
            <Modal.Header closeButton>
                <Modal.Title id="contained-modal-title-vcenter">{ADDED_ELEMENT + GRAND_PRIX + NAME}</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Form>
                    <Form.Control
                        value={fullName}
                        onChange={e => setFullName(e.target.value)}
                        className="mt-3"
                        placeholder={INPUT_ELEMENT + NAME}
                        type="text"
                    />
                    <Form.Control
                        value={shortName}
                        onChange={e => setShortName(e.target.value)}
                        className="mt-3"
                        placeholder={INPUT_ELEMENT + NAME}
                        type="text"
                    />
                </Form>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="outline-danger" onClick={() => onHide} >{BUTTON_CLOSE}</Button>
                <Button variant="outline-success" onClick={addName}>{BUTTON_ADDED}</Button>
            </Modal.Footer>
        </Modal>
    );
});

export default CreateGrandPrixName;