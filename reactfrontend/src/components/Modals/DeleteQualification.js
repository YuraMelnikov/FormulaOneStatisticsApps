import React, { useEffect, useState } from 'react';
import Modal from "react-bootstrap/Modal";
import { Button, Form } from "react-bootstrap";
import { deleteQualification, fetchQualification } from "../../http/API";
import { observer } from "mobx-react-lite";
import { 
    DELETE,
    QUALIFICATION,
    BUTTON_CLOSE, 
    UPDATE_ELEMENT } 
from "../../utils/TitleNameConst";

const DeleteQualification = observer(({ id, show, onHide }) => {
    const [time, setTime] = useState('')
    const [thisId, setThisId] = useState('')

    useEffect(() => {
        if(show === true){
            setTime('')
            const fetch = async (id) => {
                const json = await fetchQualification(id)
                setTime(json.time)
                setThisId(id)
            }
            fetch(id)
        }
    // eslint-disable-next-line react-hooks/exhaustive-deps
    },[show])

    const deleteThisQualification = () => {
        const formData  = new FormData()
        console.log(id)
        formData.append('id', thisId)
        deleteQualification(formData).then(data => data === true ? onHide() : setTime(''))
    }

    return (
        <Modal show={show} onHide={onHide} centered>
            <Modal.Header closeButton>
                <Modal.Title id="contained-modal-title-vcenter">{UPDATE_ELEMENT + QUALIFICATION}</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Form>
                    <h5>{time}</h5>
                </Form>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="outline-danger" onClick={onHide}>{BUTTON_CLOSE}</Button>
                <Button variant="outline-success" onClick={deleteThisQualification}>{DELETE}</Button>
            </Modal.Footer>
        </Modal>
    );
});

export default DeleteQualification;