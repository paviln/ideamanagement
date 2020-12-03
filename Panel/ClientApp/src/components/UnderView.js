import React,{Component, useState} from 'react';
import Table from 'react-bootstrap/Table';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form'
import { Row, Col } from 'react-bootstrap';

export default class UnderView extends Component {

    render () {
         return (
             <div>
              <h3>Under Review Page</h3>
              <br/>
            <Table striped bordered hover>
            <thead>
            <tr>
            <th>S.no</th>
            <th>Idea</th>
            <th>Status</th>
            <th>Estimated  cost saving</th>
            <th>Comment</th>
            </tr>
            </thead>

            <tbody>
            <tr>
            <td>1</td>
            <td></td>
            <td>under review</td>
            <td></td>
            <td></td>
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
         
          <form>
          <div class="container pb-cmnt-container">
            <div class="row">
            <div class="col-md-6 col-md-offset-3">
            <div class="panel panel-info">
            <div class="panel-body">
            <textarea placeholder="Estimate the cost" class="pb-cmnt-textarea"></textarea>
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
            <textarea placeholder="Your comment" class="pb-cmnt-textarea"></textarea>
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