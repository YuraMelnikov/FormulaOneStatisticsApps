import React, { useEffect } from 'react';
import Modal from "react-bootstrap/Modal";
import { Form } from "react-bootstrap";
import { importData } from "../../http/API";
import { observer } from "mobx-react-lite";
import { 
    ADDED_ELEMENT, 
    FILE
} from "../../utils/TitleNameConst";

const LoadingExcel = observer(({ show, onHide }) => {
 
    const selectFile = async e => {
        const data = new FormData()
        data.append('file', e.target.files[0])
        await importData(data)
    }

    useEffect(() => {
    // eslint-disable-next-line react-hooks/exhaustive-deps
    },[])

    return (
        <Modal show={show} onHide={onHide} backdrop={false} centered>
            <Modal.Header closeButton>
                <Modal.Title id="contained-modal-title-vcenter">{ADDED_ELEMENT + FILE}</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Form>
                    <Form.Control className="mt-3" type="file" onChange={selectFile} /> 
                </Form>
            </Modal.Body>
        </Modal>
    );
});

export default LoadingExcel;