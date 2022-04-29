import React, { useState } from 'react';
import Modal from "react-bootstrap/Modal";
import { Button, Form } from "react-bootstrap";
import { createSeason } from "../../http/API";
import { observer } from "mobx-react-lite";

const CreateSeason = observer(({ show, onHide }) => {
    const [year, setYear] = useState(0)

    const addSeason = () => {
        const formData  = new FormData()
        formData.append('year', year)
        createSeason(formData).then(data => data === false ? setYear(0) : onHide())
    }

    return (
        <Modal show={show} onHide={onHide} centered>
            <Modal.Header closeButton>
                <Modal.Title id="contained-modal-title-vcenter">
                    Added season
                </Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Form>
                    <Form.Control
                        value={year}
                        onChange={e => setYear(Number(e.target.value))}
                        className="mt-3"
                        placeholder="Input year"
                        type="number"
                    />
                    <hr/>
                </Form>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="outline-danger" onClick={onHide}>Close</Button>
                <Button variant="outline-success" onClick={addSeason}>Added</Button>
            </Modal.Footer>
        </Modal>
    );
});

export default CreateSeason;