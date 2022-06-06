import Rectangle from '../assets/Rectangle.png';
import { useTranslation } from 'react-i18next';
import { Col, Container, Row } from 'react-bootstrap';

const IndexImage:React.FC = () => {
    const {t} = useTranslation();

    return (
        <div className="app" style={{backgroundImage: `url(${Rectangle})` }}>
            <Container>
                <Row>
                    <Col className='col-7'>
                        <h1 className='app-content'>{t('siteName.label')}</h1>
                    </Col>
                </Row>
                <Row>
                    <Col className='col-7'>
                        <h2 className='app-label-content'>{t('siteIntro.label')}</h2>
                    </Col>
                </Row>
            </Container>
        </div>  
    );
}

export default IndexImage;

