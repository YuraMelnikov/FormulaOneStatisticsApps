import React, { useState, useEffect,  useContext } from 'react';
import Modal from "react-bootstrap/Modal";
import { Button, Form, Dropdown } from "react-bootstrap";
import { createManufacturer, fetchCountries } from "../../http/API";
import { observer } from "mobx-react-lite";
import { 
    ADDED_ELEMENT, 
    MANUFACTURER,
    INPUT_ELEMENT,
    COUNTRY,
    CHANGE_ELEMENT,
    NAME,
    BUTTON_CLOSE, 
    BUTTON_ADDED } 
from "../../utils/TitleNameConst";
import {Context} from '../../index';

const CreateManufacturer = observer(({ show, onHide }) => {
    const{openApiData} = useContext(Context)

    const [name, setName] = useState('')
    const [idCountry, setIdCountry] = useState('')

    useEffect(() => {
        if(show === true){
            setName('')
            setIdCountry('')
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

    const addManufacturer = () => {
        const formData  = new FormData()
        formData.append('name', name)
        formData.append('idCountry', idCountry)
        createManufacturer(formData).then(data => data === false ? setName('') : onHide())
    }

    return (
        <Modal show={show} onHide={onHide} centered>
            <Modal.Header closeButton>
                <Modal.Title id="contained-modal-title-vcenter">{ADDED_ELEMENT + MANUFACTURER}</Modal.Title>
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
                <Button variant="outline-success" onClick={addManufacturer}>{BUTTON_ADDED}</Button>
            </Modal.Footer>
        </Modal>
    );
});

export default CreateManufacturer;