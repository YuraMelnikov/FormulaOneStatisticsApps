import Table from 'react-bootstrap/Table';
import React from "react";
import { IShortResult } from '../../types/types';

interface ResultsListProps {
    result: IShortResult[]
}

const TableLastShortResult: React.FC<ResultsListProps> = ({result}) => {
    return (
        <Table>
            <tbody>
                {result.map(res =>
                    <tr key={res.racerFullName}>
                        <td>{res.position}</td>
                        <td>{res.racerFullName}</td>
                        <td>{res.constructor}</td>
                        <td>{res.timeGap}</td>
                        <td>{res.points}</td>
                    </tr>
                )}
            </tbody>
        </Table>
    );
}

export default TableLastShortResult;