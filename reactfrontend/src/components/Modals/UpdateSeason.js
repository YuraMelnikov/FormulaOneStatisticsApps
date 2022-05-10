import React, { useContext, useEffect } from 'react';
import Modal from "react-bootstrap/Modal";
import { Button, Form, Dropdown, Card } from "react-bootstrap";
import { fetchImagesBySeason, updateSeason } from "../../http/API";
import { observer } from "mobx-react-lite";
import {Context} from '../../index';
import { 
    BUTTON_UPDATE,
    SEASON,
    CHANGE_ELEMENT,
    IMAGE, 
    BUTTON_CLOSE, 
    UPDATE_ELEMENT } 
from "../../utils/TitleNameConst";

const UpdateSeason = observer(({ id, show, onHide }) => {
    const{openApiData} = useContext(Context)

    useEffect(() => {
        if(id !== undefined) {
            fetchImagesBySeason(id).then(data => openApiData.setImages(data))
        }
    // eslint-disable-next-line react-hooks/exhaustive-deps
    },[show])

    const updateThisSeason = () => {
        const formData  = new FormData()
        formData.append('id', id)
        formData.append('link', openApiData.selectedImage.link)
        if(openApiData.selectedImage.link !== undefined)
            updateSeason(id, formData).then(data => data === false ? openApiData.setSelectedImage({}) : onHide())
    }

    return (
        <Modal show={show} onHide={onHide} centered>
            <Modal.Header closeButton>
                <Modal.Title id="contained-modal-title-vcenter">{UPDATE_ELEMENT + SEASON}</Modal.Title>
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
                </Form>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="outline-danger" onClick={onHide}>{BUTTON_CLOSE}</Button>
                <Button variant="outline-success" onClick={updateThisSeason}>{BUTTON_UPDATE}</Button>
            </Modal.Footer>
        </Modal>
    );
});

export default UpdateSeason;