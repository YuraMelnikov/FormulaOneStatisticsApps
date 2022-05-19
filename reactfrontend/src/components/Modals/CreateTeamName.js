import React, { useState, useEffect,  useContext } from 'react';
import Modal from "react-bootstrap/Modal";
import { Button, Form, Dropdown } from "react-bootstrap";
import { createTeamName, fetchCountries } from "../../http/API";
import { observer } from "mobx-react-lite";
import { 
    ADDED_ELEMENT, 
    API,
    COUNTRY,
    INPUT_ELEMENT,
    TEAM,
    NAME,
    CHANGE_ELEMENT,
    BUTTON_CLOSE, 
    BUTTON_ADDED } 
from "../../utils/TitleNameConst";
import {Context} from '../../index';

const CreateTeamName = observer(({ show, onHide }) => {
    const{openApiData} = useContext(Context)

    const [name, setName] = useState('')
    const [timeApiId, setTimeApiId] = useState('')
    const [idCountry, setIdCountry] = useState('')

    useEffect(() => {
        if(show === true){
            setName('')
            setTimeApiId('')
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

    const addTeamName = () => {
        const formData  = new FormData()
        formData.append('name', name)
        formData.append('timeApiId', timeApiId)
        formData.append('idCountry', idCountry)
        createTeamName(formData).then(data => data === false ? setName('') : onHide())
    }

    return (
        <Modal show={show} onHide={onHide} centered>
            <Modal.Header closeButton>
                <Modal.Title id="contained-modal-title-vcenter">{ADDED_ELEMENT + TEAM + " " + NAME}</Modal.Title>
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
                        value={timeApiId}
                        onChange={e => setTimeApiId(e.target.value)}
                        className="mt-3"
                        placeholder={INPUT_ELEMENT + API + NAME}
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
                <Button variant="outline-success" onClick={addTeamName}>{BUTTON_ADDED}</Button>
            </Modal.Footer>
        </Modal>
    );
});

export default CreateTeamName;