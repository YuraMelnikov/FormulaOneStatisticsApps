import React, { useEffect, useState } from 'react';
import Modal from "react-bootstrap/Modal";
import { Button, Form } from "react-bootstrap";
import { updateQualification, fetchQualification } from "../../http/API";
import { observer } from "mobx-react-lite";
import { 
    BUTTON_UPDATE,
    QUALIFICATION,
    INPUT_ELEMENT,
    TIME, 
    BUTTON_CLOSE, 
    UPDATE_ELEMENT } 
from "../../utils/TitleNameConst";

const UpdateQualification = observer(({ id, show, onHide }) => {
    const [time, setTime] = useState('')

    useEffect(() => {
        setTime('')
        if(show === true){
            const fetch = async (id) => {
                const json = await fetchQualification(id)
                setTime(json.time)
            }
            fetch(id)
        }
    // eslint-disable-next-line react-hooks/exhaustive-deps
    },[show])

    const updateThisQualification = () => {
        const formData  = new FormData()
        formData.append('id', id)
        formData.append('Time', time)
        updateQualification(formData).then(data => data === true ? onHide() : setTime(''))
    }

    return (
        <Modal show={show} onHide={onHide} centered>
            <Modal.Header closeButton>
                <Modal.Title id="contained-modal-title-vcenter">{UPDATE_ELEMENT + QUALIFICATION}</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Form>
                <Form.Control
                        value={time}
                        onChange={e => setTime(e.target.value)}
                        className="mt-3"
                        placeholder={INPUT_ELEMENT + TIME}
                        type="text"
                    />
                </Form>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="outline-danger" onClick={onHide}>{BUTTON_CLOSE}</Button>
                <Button variant="outline-success" onClick={updateThisQualification}>{BUTTON_UPDATE}</Button>
            </Modal.Footer>
        </Modal>
    );
});

export default UpdateQualification;