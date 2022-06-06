import LayoutResult from '../assets/LayoutResult.png';
import { useTranslation } from 'react-i18next';
import { Col, Container, Row } from 'react-bootstrap';
import TableLastShortResult from './tables/TableLastShortResult';
import { IShortResult } from '../types/types';


const result: IShortResult[] = [
    { position: 1, racerFullName:"Max Verstappen", constructor:"Red Bull", timeGap:"21:37:20.475", points:25 },
    { position:2, racerFullName:"Max Verstappen", constructor:"Red Bull", timeGap:"21:37:20.475", points:25 },
    { position:3, racerFullName:"Max Verstappen", constructor:"Red Bull", timeGap:"21:37:20.475", points:25 },
    { position:4, racerFullName:"Max Verstappen", constructor:"Red Bull", timeGap:"21:37:20.475", points:25 },
    { position:5, racerFullName:"Max Verstappen", constructor:"Red Bull", timeGap:"21:37:20.475", points:25 },
    { position:6, racerFullName:"Max Verstappen", constructor:"Red Bull", timeGap:"21:37:20.475", points:25 },
    { position:7, racerFullName:"Max Verstappen", constructor:"Red Bull", timeGap:"21:37:20.475", points:25 },
    { position:8, racerFullName:"Max Verstappen", constructor:"Red Bull", timeGap:"21:37:20.475", points:25 },
    { position:9, racerFullName:"Max Verstappen", constructor:"Red Bull", timeGap:"21:37:20.475", points:25 },
    { position:10, racerFullName:"Max Verstappen", constructor:"Red Bull", timeGap:"21:37:20.475", points:25 }
]



const LastResult:React.FC = () => {
    const {t} = useTranslation();
    
    return (
        <div className="app-background-content" style={{backgroundImage: `url(${LayoutResult})` }}>
            <Container>
                <Row>
                    <Col>
                        <h3 className='app-content-60'>{t('resultGrandPrix.label')}</h3>
                    </Col>
                </Row>
                <Row>
                    <Col>
                        <TableLastShortResult result={result} />
                    </Col>
                </Row>
            </Container>
        </div>  
    );
}

export default LastResult;