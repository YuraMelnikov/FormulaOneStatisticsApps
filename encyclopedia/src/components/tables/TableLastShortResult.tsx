import Table from 'react-bootstrap/Table';
import React from "react";
import { IShortResult } from '../../types/types';
import ReactCountryFlag from "react-country-flag";

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
                        <td>
                            <ReactCountryFlag
                                countryCode="US"
                                svg
                                style={{
                                    width: '25px',
                                    height: '17px',
                                }}
                        /><h4>{res.racerFullName}</h4></td>
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