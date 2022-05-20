import React, { useState, useEffect,  useContext } from 'react';
import Modal from "react-bootstrap/Modal";
import { Button, Form, Dropdown } from "react-bootstrap";
import { createTrack, fetchCountries } from "../../http/API";
import { observer } from "mobx-react-lite";
import { 
    ADDED_ELEMENT, 
    COUNTRY,
    INPUT_ELEMENT,
    TRACK,
    RUS,
    LOCATION,
    CHANGE_ELEMENT,
    NAME,
    BUTTON_CLOSE, 
    BUTTON_ADDED } 
from "../../utils/TitleNameConst";
import {Context} from '../../index';

const CreateTrack = observer(({ show, onHide }) => {
    const{openApiData} = useContext(Context)

    const [name, setName] = useState('')
    const [idCountry, setIdCountry] = useState('')
    const [nameRus, setNameRus] = useState('')
    const [location, setLocation] = useState('')

    useEffect(() => {
        if(show === true){
            setIdCountry('')
            setName('')
            setNameRus('')
            setLocation('')
            if(openApiData.country.length === 0){
                const fetch = async () => {
                    const json = await fetchCountries()
                    openApiData.setCountry(json)
                }
                fetch()
            }
        }
    // eslint-disable-next-line react-hooks/exhaustive-deps
    },[show])

    const addTrack = () => {
        const formData  = new FormData()
        formData.append('name', name)
        formData.append('idCountry', idCountry)
        formData.append('nameRus', nameRus)
        formData.append('location', location)

        createTrack(formData).then(data => data === false ? setName('') : onHide())
    }

    return (
        <Modal show={show} onHide={onHide} centered>
            <Modal.Header closeButton>
                <Modal.Title id="contained-modal-title-vcenter">{ADDED_ELEMENT + TRACK}</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Form>
                    <Form.Control
                        value={name}
                        onChange={e => setName(e.target.value)}
                        className="mt-3"
                        placeholder={INPUT_ELEMENT + NAME}
                        type="text"
                    />
                    <Form.Control
                        value={nameRus}
                        onChange={e => setNameRus(e.target.value)}
                        className="mt-3"
                        placeholder={INPUT_ELEMENT + NAME + " " + RUS}
                        type="text"
                    />
                    <Form.Control
                        value={location}
                        onChange={e => setLocation(e.target.value)}
                        className="mt-3"
                        placeholder={INPUT_ELEMENT + LOCATION}
                        type="text"
                    />
                    <Dropdown className="mt-2 mb-2">
                        <Dropdown.Toggle>{CHANGE_ELEMENT + COUNTRY}</Dropdown.Toggle>
                        <Dropdown.Menu>
                            {openApiData.country.map(cou =>
                                <Dropdown.Item onClick={() => setIdCountry(cou.id)} key={cou.id}>
                                    {cou.name}
                                </Dropdown.Item>
                            )}
                        </Dropdown.Menu>
                    </Dropdown>
                    <h4>{idCountry}</h4>
                </Form>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="outline-danger" onClick={() => onHide} >{BUTTON_CLOSE}</Button>
                <Button variant="outline-success" onClick={addTrack}>{BUTTON_ADDED}</Button>
            </Modal.Footer>
        </Modal>
    );
});

export default CreateTrack;