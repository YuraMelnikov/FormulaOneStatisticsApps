import { Container } from 'react-bootstrap';
import IndexImage from '../components/IndexImage';
import LastResult from '../components/LastResult';

const Index:React.FC = () => {
    return (
        <Container fluid>
            <IndexImage/>
            <LastResult/>
        </Container>
    );
}

export default Index;