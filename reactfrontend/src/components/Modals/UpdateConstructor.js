import React, { useContext, useEffect } from 'react';
import Modal from "react-bootstrap/Modal";
import { Button, Form, Dropdown, Card } from "react-bootstrap";
import { fetchImagesByConstructor, updateConstructor } from "../../http/API";
import { observer } from "mobx-react-lite";
import {Context} from '../../index';

const UpdateConstructor = observer(({ id, show, onHide }) => {
    const{openApiData} = useContext(Context)

    useEffect(() => {
        if(id !== undefined)
            fetchImagesByConstructor(id).then(data => openApiData.setImages(data))
    // eslint-disable-next-line react-hooks/exhaustive-deps
    },[show])

    const updateThisConstructor = () => {
        const formData  = new FormData()
        formData.append('id', id)
        formData.append('image', openApiData.selectedImage.link)
        formData.append('logo', openApiData.selectedLogo.link)
        if(openApiData.selectedImage.link !== undefined & openApiData.selectedLogo.link !== undefined)
            updateConstructor(id, formData).then(onHide)
    }

    return (
        <Modal show={show} onHide={onHide} centered>
            <Modal.Header closeButton>
                <Modal.Title id="contained-modal-title-vcenter">Update constructor</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Form>
                    <Dropdown className="mt-2 mb-2">
                        <Dropdown.Toggle>{openApiData.setSelectedImage.name || "Change image"}</Dropdown.Toggle>
                        <Dropdown.Menu>
                            {openApiData.images.map(image =>
                                <Dropdown.Item onClick={() => openApiData.setSelectedImage(image)} key={image.id}>
                                    <Card.Img variant="top" src={image.link}/>
                                </Dropdown.Item>
                            )}
                        </Dropdown.Menu>
                    </Dropdown>
                    <Card.Img variant="top" src={openApiData.selectedImage.link}/>

                    <Dropdown className="mt-2 mb-2">
                        <Dropdown.Toggle>{openApiData.selectedLogo.name || "Change logo"}</Dropdown.Toggle>
                        <Dropdown.Menu>
                            {openApiData.images.map(image =>
                                <Dropdown.Item onClick={() => openApiData.setSelectedLogo(image)} key={image.id}>
                                    <Card.Img variant="top" src={image.link}/>
                                </Dropdown.Item>
                            )}
                        </Dropdown.Menu>
                    </Dropdown>
                    <Card.Img variant="top" src={openApiData.selectedLogo.link}/>
                </Form>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="outline-danger" onClick={onHide}>Close</Button>
                <Button variant="outline-success" onClick={updateThisConstructor}>Update</Button>
            </Modal.Footer>
        </Modal>
    );
});

export default UpdateConstructor;