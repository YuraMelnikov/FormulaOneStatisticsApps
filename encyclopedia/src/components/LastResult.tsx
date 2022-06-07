import LayoutResult from '../assets/LayoutResult.png';
import { useTranslation } from 'react-i18next';
import { Col, Container, Row } from 'react-bootstrap';
import TableLastShortResult from './tables/TableLastShortResult';
import { IShortResult } from '../types/types';


const result: IShortResult[] = [
    { position: 1, racerFullName:"Max Verstappen", constructor:"Red Bull", timeGap:"21:37:20.475", points:25 },
    { position:2, racerFullName:"Max1 Verstappen", constructor:"Red Bull", timeGap:"+20.475", points:18 },
    { position:3, racerFullName:"Ma2 Verstappen", constructor:"Red Bull", timeGap:"+475", points:15 },
    { position:4, racerFullName:"Ma3 Verstappen", constructor:"Red Bull", timeGap:"+475", points:14 },
    { position:5, racerFullName:"Ma4 Verstappen", constructor:"Red Bull", timeGap:"+.475", points:14 },
    { position:6, racerFullName:"Ma5 Verstappen", constructor:"Red Bull", timeGap:"21:37:20.475", points:11 },
    { position:7, racerFullName:"Ma6 Verstappen", constructor:"Red Bull", timeGap:"21:37:20.475", points:10 },
    { position:8, racerFullName:"Ma7 Verstappen", constructor:"Red Bull", timeGap:"21:37:20.475", points:5 },
    { position:9, racerFullName:"Ma8 Verstappen", constructor:"Red Bull", timeGap:"21:37:20.475", points:2 },
    { position:10, racerFullName:"Ma9 Verstappen", constructor:"Red Bull", timeGap:"21:37:20.475", points:1 }
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
                    <Col sm='9' md='9' lg='9' xl='9' xxl="9">
                        <TableLastShortResult result={result} />
                    </Col>
                    <Col sm='3' md='3' lg='3' xl='3' xxl="3">
                    </Col>
                </Row>
            </Container>
        </div>  
    );
}

export default LastResult;