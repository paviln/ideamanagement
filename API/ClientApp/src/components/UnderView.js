import React,{Component, useState} from 'react';
import Table from 'react-bootstrap/Table';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form'
import { Row, Col } from 'react-bootstrap';
import {withRouter, Redirect} from 'react-router-dom';

export default class UnderView extends Component {
  
    render () {
         return (
             <div>
              <h3>Under Review Page</h3>
              <br/>
            <Table striped bordered hover>
            <thead class="thead-dark">
            <tr >
            <th>S.no</th>
            <th>Idea</th>
            <th>Status</th>
            <th>Estimated  cost saving</th>
            <th>Comments</th>
            </tr>
            </thead>

            <tbody>
            <tr>
            <td>1</td>
            <td></td>
            <td>under review</td>
            <td></td>
            <td>           
            
            </td>
            </tr>

            <tr>
            <td>2</td>
            <td></td>
            <td>under review</td>
            <td></td>
            <td></td>
            </tr>
            </tbody>
          </Table>
          </div>    
         )
    }
}