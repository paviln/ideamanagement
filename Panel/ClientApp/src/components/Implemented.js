import React,{Component, useState} from 'react';
import { InputGroup } from 'react-bootstrap';
import { FormControl } from 'react-bootstrap';
import Table from 'react-bootstrap/Table';
export default class Implemented extends Component {

    render () {  
         return (
            <div>
                <h1>Implemented</h1>
                <br/>
            <Table striped bordered hover>
            <thead>
            <tr>
            <th>Idea</th>
            <th>Challenges</th>
            <th>Results</th>
            </tr>
            </thead>

            <tbody>
            <tr>
            <td></td>
            <td></td>
            <td></td>
            </tr>

            <tr>
            <td></td>
            <td></td>
            <td></td>
            </tr>
            </tbody>
          </Table>

          <form>
          <div class="container pb-cmnt-container">
            <div class="row">
            <div class="col-md-6 col-md-offset-3">
            <div class="panel panel-info">
            <div class="panel-body">
            <InputGroup>
            <InputGroup.Prepend>
            <InputGroup.Text>Challanges</InputGroup.Text>
            </InputGroup.Prepend>
            <FormControl as="textarea" aria-label="With textarea" />
            </InputGroup>
            <form class="form-inline">
            <button class="btn btn-primary pull-right" type="button">Add</button>
            </form>
            </div>
            </div>
            </div>
            </div>
            </div> 
           
            <br/>
            <div class="container pb-cmnt-container">
            <div class="row">
            <div class="col-md-6 col-md-offset-3">
            <div class="panel panel-info">
            <div class="panel-body">
            <InputGroup>
            <InputGroup.Prepend>
            <InputGroup.Text>Results</InputGroup.Text>
            </InputGroup.Prepend>
            <FormControl as="textarea" aria-label="With textarea" />
            </InputGroup>
            <form class="form-inline">
            <button class="btn btn-primary pull-right" type="button">Add</button>
            </form>
            </div>
            </div>
            </div>
            </div>
            </div>
            </form>
         </div>
         
         
         )
    }
}