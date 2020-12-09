import React,{Component, useState} from 'react';
import Dropdown from 'react-bootstrap/Dropdown';
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button';
import Table from 'react-bootstrap/Table';
import './My.css';

export default class UnderImplementation extends Component {

    render () {
         return (
             <div>
              <h1>Under Implementation</h1>
              <br/>
             <Dropdown>
            <div class="table-responsive">
            <table class="table table-bordered table-hover">
            <thead class="thead-dark">
            <tr>
            <th>S.no</th>
            <th>Task</th>
            <th>Status</th>
            <th>Comments</th>
            <th class="text-center">Actions</th>
            </tr>
            </thead>
            <tbody>
            <tr>

            <td>1</td>
            <td>Employee Management 
            <button class="btn btn-primary badge-pill float-right"> Edit</button>
            
            </td>
            <td><Dropdown className="text-right">
            <Dropdown.Toggle variant="success" id="dropdown-basic">
            </Dropdown.Toggle>
            <Dropdown.Menu>
            <Dropdown.Item href="#/action-1">Not started</Dropdown.Item>
            <Dropdown.Item href="#/action-2">progress</Dropdown.Item>
            <Dropdown.Item href="#/action-3">done</Dropdown.Item>
            </Dropdown.Menu>
            </Dropdown></td>
            <td></td>
            <td class="text-center">
            <button class="btn btn-primary badge-pill" type="button" onclick="showModalNow()">Add Comment</button>
            </td>
            </tr>
            <tr>
            <td>2</td>
            <td>Improve Customer Service
            <button class="btn btn-primary badge-pill float-right"> Edit</button>
            </td>
            <td><Dropdown className="text-right">
            <Dropdown.Toggle variant="success" id="dropdown-basic">
            </Dropdown.Toggle>
            <Dropdown.Menu>
            <Dropdown.Item href="#/action-1">Not started</Dropdown.Item>
            <Dropdown.Item href="#/action-2">progress</Dropdown.Item>
            <Dropdown.Item href="#/action-3">done</Dropdown.Item>
            </Dropdown.Menu>
            </Dropdown>
            </td>
            <td></td>
            <td className="text-center">   
            <button class="btn btn-primary badge-pill" type="button" onclick="showModalNow()">Add Comment</button>
            </td>
            </tr>

            <tr>
            <td>3</td>
            <td>Improve IT System
            <button class="btn btn-primary badge-pill float-right"> <span class="glyphicon glyphicon-user"></span> 
            Edit</button>    
            </td>
            <td><Dropdown className="text-right">
            <Dropdown.Toggle variant="success" id="dropdown-basic">
            </Dropdown.Toggle>
            <Dropdown.Menu>
            <Dropdown.Item href="#/action-1">Not started</Dropdown.Item>
            <Dropdown.Item href="#/action-2">progress</Dropdown.Item>
            <Dropdown.Item href="#/action-3">done</Dropdown.Item>
            </Dropdown.Menu>
            </Dropdown></td>
            <td></td>
            <td className="text-center">
            <button class="btn btn-primary badge-pill" type="button" onclick="showModalNow()">Add Comment</button>
            </td>
            </tr>
            </tbody>
            </table>
      </div>
      </Dropdown>
      </div>

      
         )
    }
}