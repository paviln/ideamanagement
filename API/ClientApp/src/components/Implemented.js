import React,{Component, useState} from 'react';
import { InputGroup } from 'react-bootstrap';
import { FormControl } from 'react-bootstrap';
import Table from 'react-bootstrap/Table';
import './My.css';
export default class Implemented extends Component {

    render () {  
         return (
            <div>
                <h1>Implemented Ideas</h1>
                <br/>
            <Table striped bordered hover>
            <thead class="thead-dark">
            <tr>
            <th>S.no</th>
            <th>Ideas</th>
            </tr>
            </thead>

            <tbody>
            <tr>
            <td>1</td>
            <td></td>
            </tr>
            <tr>
            <td>2</td>
            <td></td>
            </tr>
            <tr>
            <td>3</td>
            <td></td>
            </tr>
            <tr>
            <td>4</td>
            <td></td>
            </tr>
            </tbody>
          </Table>
         </div>
         )
    }
}