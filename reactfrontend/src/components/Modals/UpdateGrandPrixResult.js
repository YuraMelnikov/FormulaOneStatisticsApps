import React, { useEffect, useState } from 'react';
import Modal from "react-bootstrap/Modal";
import { Button, Form } from "react-bootstrap";
import { updateGrandPrixResult, fetchGrandPrixResult } from "../../http/API";
import { observer } from "mobx-react-lite";
import { 
    BUTTON_UPDATE,
    GRAND_PRIX,
    INPUT_ELEMENT,
    NOTE,
    CLASSIFICATION, 
    RUS,
    BUTTON_CLOSE, 
    UPDATE_ELEMENT } 
from "../../utils/TitleNameConst";

const UpdateGrandPrixResult = observer(({ id, show, onHide }) => {

    const [note, setNote] = useState('')
    const [noteRus, SetNoteRus] = useState('')
    const [classification, setClassification] = useState('')
    const [classificationRus, setClassificationRus] = useState('')

    useEffect(() => {
        setNote('')
        SetNoteRus('')
        setClassification('')
        setClassificationRus('')
        if(show === true){
            const fetch = async (id) => {
                const json = await fetchGrandPrixResult(id)
                console.log(json)
                setNote(json.note)
                SetNoteRus(json.noteRus)
                setClassification(json.classification)
                setClassificationRus(json.classificationRus)
            }
            fetch(id)
        }
    // eslint-disable-next-line react-hooks/exhaustive-deps
    },[show])

    const updateThisResult = () => {
        const formData  = new FormData()
        formData.append('id', id.id)
        formData.append('note', note)
        formData.append('noteRus', noteRus)
        formData.append('classification', classification)
        formData.append('classificationRus', classificationRus)
        updateGrandPrixResult(id, formData).then(onHide)
    }

    return (
        <Modal show={show} onHide={onHide} centered>
            <Modal.Header closeButton>
                <Modal.Title id="contained-modal-title-vcenter">{UPDATE_ELEMENT + GRAND_PRIX}</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Form>
                    <h5>{NOTE}</h5>
                    <Form.Control
                        value={note}
                        onChange={e => setNote(e.target.value)}
                        className="mt-3"
                        placeholder={INPUT_ELEMENT + NOTE}
                        type="text"
                    />
                    <h5>{NOTE + RUS}</h5>
                    <Form.Control
                        value={noteRus}
                        onChange={e => SetNoteRus(e.target.value)}
                        className="mt-3"
                        placeholder={INPUT_ELEMENT + NOTE + RUS}
                        type="text"
                    />
                    <h5>{CLASSIFICATION}</h5>
                    <Form.Control
                        value={classification}
                        onChange={e => setClassification(e.target.value)}
                        className="mt-3"
                        placeholder={INPUT_ELEMENT + CLASSIFICATION}
                        type="text"
                    />
                    <h5>{CLASSIFICATION + RUS}</h5>
                    <Form.Control
                        value={classificationRus}
                        onChange={e => setClassificationRus(e.target.value)}
                        className="mt-3"
                        placeholder={INPUT_ELEMENT + CLASSIFICATION + RUS}
                        type="text"
                    />
            </Form>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="outline-danger" onClick={onHide}>{BUTTON_CLOSE}</Button>
                <Button variant="outline-success" onClick={updateThisResult}>{BUTTON_UPDATE}</Button>
            </Modal.Footer>
        </Modal>
    );
});

export default UpdateGrandPrixResult;