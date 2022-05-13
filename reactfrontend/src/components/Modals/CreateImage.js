import React, { useState, useEffect, useContext } from 'react';
import Modal from "react-bootstrap/Modal";
import { Button, Form, Dropdown } from "react-bootstrap";
import { createImage, saveImage } from "../../http/API";
import { observer } from "mobx-react-lite";
import { fetchGrandPrix, fetchGpParticipant } from "../../http/API";
import {Context} from '../../index';
import { 
    ADDED_ELEMENT, 
    IMAGE, 
    CHANGE_ELEMENT, 
    GRAND_PRIX, 
    PARTICIPANT, 
    BUTTON_REMOVE, 
    BUTTON_ADDED 
} from "../../utils/TitleNameConst";

const CreateImage = observer(({ show, onHide }) => {
    const{openApiData} = useContext(Context)

    const [participantArray, setParticipantArray] = useState([])
    const addParticipant = (newParticipant) => {
        setParticipantArray([...participantArray, newParticipant])
    }
    const removeParticipant = () => {
        setParticipantArray([])
    }

    const [file, setFile] = useState('')

    const selectFile = async e => {
        const data = new FormData()
        data.append('file', e.target.files[0])
        let path = await saveImage(data)
        setFile(path)
    }

    const addImage = () => {
        if(file !== '') {
            const formData  = new FormData()
            for (var i = 0; i < participantArray.length; i++) {
                formData.append('participant[]', participantArray[i]);
            }
            formData.append('grandPrix', openApiData.selectItem.id)
            formData.append('path', file);
            createImage(formData).then(data => data === false ? removeParticipant() : onHide)
        }
    }

    useEffect(() => {
        setParticipantArray([])
        openApiData.setSelectItem({})
        openApiData.setGpParticipant([])
        setFile('')
        if(show === true){
            fetchGrandPrix().then(data => openApiData.setGrandPrix(data))
        }
    // eslint-disable-next-line react-hooks/exhaustive-deps
    },[show])

    useEffect(() => {
        if(openApiData.selectItem.id !== undefined) {
            openApiData.setGpParticipant([])
            setParticipantArray([])
            fetchGpParticipant(openApiData.selectItem.id).then(data => openApiData.setGpParticipant(data))
        }
    // eslint-disable-next-line react-hooks/exhaustive-deps
    },[openApiData.selectItem])

    return (
        <Modal show={show} onHide={onHide} backdrop={false} centered>
            <Modal.Header closeButton>
                <Modal.Title id="contained-modal-title-vcenter">{ADDED_ELEMENT + IMAGE}</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Form>
                    <Dropdown className="mt-2 mb-2">
                        <Dropdown.Toggle>{CHANGE_ELEMENT + GRAND_PRIX}</Dropdown.Toggle>
                        <Dropdown.Menu>
                            {openApiData.grandPrix.map(gp =>
                                <Dropdown.Item onClick={() => openApiData.setSelectItem(gp)} key={gp.id}>
                                    {gp.number}
                                    {gp.season}
                                    {gp.grandPrixNames}
                                </Dropdown.Item>
                            )}
                        </Dropdown.Menu>
                    </Dropdown>
                    <h4>{openApiData.selectItem.grandPrixNames}</h4>
                    <Dropdown className="mt-2 mb-2">
                        <Dropdown.Toggle>{CHANGE_ELEMENT + PARTICIPANT}</Dropdown.Toggle>
                        <Dropdown.Menu>
                            {openApiData.gpParticipant.map(participant =>
                                <Dropdown.Item onClick={() => addParticipant(participant.id)} key={participant.id}>
                                    {participant.racer}
                                    {participant.chassis}
                                    {participant.no}
                                </Dropdown.Item>
                            )}
                        </Dropdown.Menu>
                    </Dropdown>
                    <Button onClick={() => removeParticipant()} variant={"outline-danger"}>{BUTTON_REMOVE}</Button>
                    <div className="col">
                        {participantArray.map(part => <div>{part}</div>)}
                    </div>
                    <Form.Control className="mt-3" type="file" onChange={selectFile} /> 
                </Form>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="outline-success" onClick={addImage}>{BUTTON_ADDED}</Button>
            </Modal.Footer>
        </Modal>
    );
});

export default CreateImage;