import React, {useState} from 'react';
import { Container, Button } from "react-bootstrap";
import TableAdminSeasons from '../components/Tables/TableAdminSeasons';

import TableAdminRacers from '../components/Tables/TableAdminRacers';
import TableAdminConstructors from '../components/Tables/TableAdminConstructors';
import TableAdminManufacturers from '../components/Tables/TableAdminManufacturers';
import TableAdminTracks from '../components/Tables/TableAdminTracks';
import CreateImage from '../components/Modals/CreateImage';

//

//<TableAdminManufacturers/>
//<TableAdminTracks/>
//
//<TableAdminRacers/>

const Admin = () =>{
    const [imageVisible, setImageVisible] = useState(false)

    return (
        <Container className="d-flex flex-column">
            <Button onClick={() => setImageVisible(true)}> Add new Image </Button>
            <CreateImage
                show={imageVisible}
                onHide={() => setImageVisible(false)}
            />

            <TableAdminSeasons/>
            <TableAdminConstructors/>

        </Container>
    );
}

export default Admin;