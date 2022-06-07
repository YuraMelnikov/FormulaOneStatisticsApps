import Table from 'react-bootstrap/Table';
import React from "react";
import { IShortResult } from '../../types/types';
import ReactCountryFlag from "react-country-flag";

interface ResultsListProps {
    result: IShortResult[]
}

const TableLastShortResult: React.FC<ResultsListProps> = ({result}) => {
    return (
            <Table bordered className="rounded">
                <tbody>
                    {result.map(res =>
                        <tr key={res.racerFullName}>
                            <td className='text-center'><h4 className='font-bold'>{res.position}</h4></td>
                            <td><h4>
                                <ReactCountryFlag
                                    countryCode="US"
                                    svg
                                    style={{
                                        width: '25px',
                                        height: '17px',
                                    }}
                            />{res.racerFullName}</h4></td>
                            <td><h4>{res.constructor}</h4></td>
                            <td className='text-end'><h4 className='font-bold'>{res.timeGap}</h4></td>
                            <td className='text-center'><h4 className='font-bold'>{res.points}</h4></td>
                        </tr>
                    )}
                </tbody>
            </Table>
    );
}

export default TableLastShortResult;