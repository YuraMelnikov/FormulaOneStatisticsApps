import React, { useState, useEffect,  useContext } from 'react';
import Modal from "react-bootstrap/Modal";
import { Button, Form, Dropdown } from "react-bootstrap";
import { createTrackConfiguration, fetchTracks } from "../../http/API";
import { observer } from "mobx-react-lite";
import { 
    ADDED_ELEMENT, 
    TRACK,
    INPUT_ELEMENT,
    LENGTH,
    CHANGE_ELEMENT,
    NOTE,
    BUTTON_CLOSE, 
    BUTTON_ADDED } 
from "../../utils/TitleNameConst";
import {Context} from '../../index';

const CreateTrackConfiguration = observer(({ show, onHide }) => {
    const{openApiData} = useContext(Context)

    const [IdTrack, setIdTrack] = useState('')
    const [length, setLength] = useState('')
    const [note, setNote] = useState('')

    useEffect(() => {
        if(show === true){
            setIdTrack('')
            setLength('')
            setNote('')
            if(openApiData.tracks.length === 0){
                const fetch = async () => {
                    const json = await fetchTracks()
                    openApiData.setTracks(json)
                }
                fetch()
            }
        }
    // eslint-disable-next-line react-hooks/exhaustive-deps
    },[show])

    const addConfig = () => {
        const formData  = new FormData()
        formData.append('idTrack', IdTrack)
        formData.append('length', length)
        formData.append('note', note)
        createTrackConfiguration(formData).then(data => data === false ? setIdTrack('') : onHide())
    }

    return (
        <Modal show={show} onHide={onHide} centered>
            <Modal.Header closeButton>
                <Modal.Title id="contained-modal-title-vcenter">{ADDED_ELEMENT + TRACK}</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Form>
                    <Form.Control
                        value={length}
                        onChange={e => setLength(e.target.value)}
                        className="mt-3"
                        placeholder={INPUT_ELEMENT + LENGTH}
                        type="text"
                    />
                    <Form.Control
                        value={note}
                        onChange={e => setNote(e.target.value)}
                        className="mt-3"
                        placeholder={INPUT_ELEMENT + NOTE}
                        type="text"
                    />
                    <Dropdown className="mt-2 mb-2">
                        <Dropdown.Toggle>{CHANGE_ELEMENT + TRACK}</Dropdown.Toggle>
                        <Dropdown.Menu>
                            {openApiData.tracks.map(track =>
                                <Dropdown.Item onClick={() => setIdTrack(track.id)} key={track.id}>
                                    {track.name}
                                </Dropdown.Item>
                            )}
                        </Dropdown.Menu>
                    </Dropdown>
                    <h4>{IdTrack}</h4>
                </Form>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="outline-danger" onClick={() => onHide} >{BUTTON_CLOSE}</Button>
                <Button variant="outline-success" onClick={addConfig}>{BUTTON_ADDED}</Button>
            </Modal.Footer>
        </Modal>
    );
});

export default CreateTrackConfiguration;