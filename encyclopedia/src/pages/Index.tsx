import { Container } from 'react-bootstrap';
import IndexImage from '../components/IndexImage';
import LastResult from '../components/LastResult';
import RandomTopics from '../components/RandomTopics';

const Index:React.FC = () => {
    return (
        <Container fluid>
            <IndexImage/>
            <LastResult/>
            <RandomTopics/>
        </Container>
    );
}

export default Index;