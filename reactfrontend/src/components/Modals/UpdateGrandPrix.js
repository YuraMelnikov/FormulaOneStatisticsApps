import React, { useContext, useEffect, useState } from 'react';
import Modal from "react-bootstrap/Modal";
import { Button, Form, Dropdown, Card } from "react-bootstrap";
import { fetchGpImages, updateGrandPrix } from "../../http/API";
import { observer } from "mobx-react-lite";
import {Context} from '../../index';
import { 
    BUTTON_UPDATE,
    INPUT_ELEMENT,
    CHANGE_ELEMENT,
    IMAGE, 
    TEXT,
    GRAND_PRIX,
    BUTTON_CLOSE, 
    UPDATE_ELEMENT } 
from "../../utils/TitleNameConst";

const UpdateGrandPrix = observer(({ id, show, onHide }) => {
    const{openApiData} = useContext(Context)
    const[text, setText] = useState('')

    useEffect(() => {
        if(id !== undefined) {
            setText('')
            //openApiData.setSelectedImage({})
            openApiData.setImages([])
            fetchGpImages(id).then(data => openApiData.setImages(data))
        }
    // eslint-disable-next-line react-hooks/exhaustive-deps
    },[show])

    const updateThisGrandPrix = () => {
        const formData  = new FormData()
        formData.append('id', id)
        formData.append('image', openApiData.selectedImage.link)
        formData.append('text', text)
        if(openApiData.selectedImage.link !== undefined)
            updateGrandPrix(id, formData).then(data => data === false ? openApiData.setSelectedImage({}) : onHide())
    }

    return (
        <Modal show={show} onHide={onHide} centered>
            <Modal.Header closeButton>
                <Modal.Title id="contained-modal-title-vcenter">{UPDATE_ELEMENT + GRAND_PRIX}</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Form>
                    <Dropdown className="mt-2 mb-2">
                        <Dropdown.Toggle>{CHANGE_ELEMENT + IMAGE}</Dropdown.Toggle>
                        <Dropdown.Menu>
                            {openApiData.images.map(image =>
                                <Dropdown.Item onClick={() => openApiData.setSelectedImage(image)} key={image.id}>
                                    <Card.Img variant="top" src={image.link}/>
                                </Dropdown.Item>
                            )}
                        </Dropdown.Menu>
                    </Dropdown>
                    <Card.Img variant="top" src={openApiData.selectedImage.link}/>
                    <Form.Control
                        value={text}
                        onChange={e => setText(e.target.value)}
                        placeholder={INPUT_ELEMENT + TEXT}
                        type="text"
                    />
                </Form>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="outline-danger" onClick={onHide}>{BUTTON_CLOSE}</Button>
                <Button variant="outline-success" onClick={updateThisGrandPrix}>{BUTTON_UPDATE}</Button>
            </Modal.Footer>
        </Modal>
    );
});

export default UpdateGrandPrix;