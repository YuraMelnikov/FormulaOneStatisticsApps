import React, { useState, useEffect } from 'react';
import Modal from "react-bootstrap/Modal";
import { Button, Form } from "react-bootstrap";
import { createSeason } from "../../http/API";
import { observer } from "mobx-react-lite";
import { 
    ADDED_ELEMENT, 
    SEASON,
    INPUT_ELEMENT,
    YEAR,
    BUTTON_CLOSE, 
    BUTTON_ADDED } 
from "../../utils/TitleNameConst";

const CreateSeason = observer(({ show, onHide }) => {
    const [year, setYear] = useState()

    useEffect(() => {
        setYear('')
    // eslint-disable-next-line react-hooks/exhaustive-deps
    },[show])

    const addSeason = () => {
        const formData  = new FormData()
        formData.append('year', year)
        createSeason(formData).then(data => data === false ? setYear('') : onHide)
    }

    return (
        <Modal show={show} onHide={onHide} centered>
            <Modal.Header closeButton>
                <Modal.Title id="contained-modal-title-vcenter">{ADDED_ELEMENT + SEASON}</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Form>
                    <Form.Control
                        value={year}
                        onChange={e => setYear(Number(e.target.value))}
                        className="mt-3"
                        placeholder={INPUT_ELEMENT + YEAR}
                        type="number"
                    />
                </Form>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="outline-danger" onClick={() => onHide} >{BUTTON_CLOSE}</Button>
                <Button variant="outline-success" onClick={addSeason}>{BUTTON_ADDED}</Button>
            </Modal.Footer>
        </Modal>
    );
});

export default CreateSeason;