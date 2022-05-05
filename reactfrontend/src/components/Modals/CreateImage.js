import React, { useState, useEffect, useContext } from 'react';
import Modal from "react-bootstrap/Modal";
import { Button, Form, Dropdown } from "react-bootstrap";
import { createImage } from "../../http/API";
import { observer } from "mobx-react-lite";
import { fetchGrandPrix, fetchGpParticipant } from "../../http/API";
import {Context} from '../../index';

const CreateImage = observer(({ show, onHide }) => {
    const{openApiData} = useContext(Context)

    const [participantArray, setParticipantArray] = useState([])
    const addParticipant = (newParticipant) => {
        setParticipantArray([...participantArray, newParticipant])
    }
    const removeParticipant = () => {
        setParticipantArray([])
    }

    const [file, setFile] = useState(null)
    const selectFile = e => {
        console.log(e.target.files[0])
        setFile(e.target.files[0])
    }

    useEffect(() => {
        setParticipantArray([])
        openApiData.setSelectItem({})
        openApiData.setGpParticipant([])
        setFile(null)
        fetchGrandPrix().then(data => openApiData.setGrandPrix(data))
    // eslint-disable-next-line react-hooks/exhaustive-deps
    },[show])

    useEffect(() => {
        console.log(openApiData.selectItem)
        if(openApiData.selectItem.id !== undefined) {
            openApiData.setGpParticipant([])
            setParticipantArray([])
            fetchGpParticipant(openApiData.selectItem.id).then(data => openApiData.setGpParticipant(data))
        }
    // eslint-disable-next-line react-hooks/exhaustive-deps
    },[openApiData.selectItem])

    const addImage = () => {
        const formData  = new FormData()
        formData.append('participant', participantArray)
        formData.append('grandPrix', openApiData.selectItem.id)
        formData.append('image', file)
        createImage(formData).then(data => data === false ? setFile(null) : onHide)
    }

    return (
        <Modal show={show} onHide={onHide} centered>
            <Modal.Header closeButton>
                <Modal.Title id="contained-modal-title-vcenter">Added image</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Form>
                    <Dropdown className="mt-2 mb-2">
                        <Dropdown.Toggle>{"Change Grand Prix"}</Dropdown.Toggle>
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
                        <Dropdown.Toggle>{"Participant"}</Dropdown.Toggle>
                        <Dropdown.Menu>
                            {openApiData.gpParticipant.map(participant =>
                                <Dropdown.Item onClick={() => addParticipant(participant)} key={participant.id}>
                                    {participant.racer}
                                    {participant.chassis}
                                    {participant.no}
                                </Dropdown.Item>
                            )}
                        </Dropdown.Menu>
                    </Dropdown>
                    <Button onClick={() => removeParticipant()} variant={"outline-danger"}>Remove</Button>
                    
                    <div className="col">
                        {participantArray.map(part => <div>{part.id}</div>)}
                    </div>

                    <Form.Control className="mt-3" type="file" onChange={selectFile} /> 
                </Form>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="outline-danger" onClick={() => onHide} >Close</Button>
                <Button variant="outline-success" onClick={addImage}>Added</Button>
            </Modal.Footer>
        </Modal>
    );
});

export default CreateImage;