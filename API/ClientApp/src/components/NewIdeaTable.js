import React,{Component, useState} from 'react';
import Table from 'react-bootstrap/Table';

export default class NewIdeaTable extends Component {

    render () {
         return (
          <div>
          <h1>New Ideas</h1>
          <br/>
            <Table striped bordered hover>
          <thead class="thead-dark">
          <tr>
          <th>S.no</th>
          <th>Title</th>
          <th>Effort</th>
          <th>Impact</th>
          </tr>
          </thead>
          <tbody>
         <tr>
          <td>1</td>
          <td>Time Management</td>
          <td>2</td>
          <td>unknown</td>
          </tr>
          <tr>
          <td>2</td>
          <td>Team work</td>
          <td>3</td>
          <td></td>
          </tr>
    
        </tbody>
      </Table>
      </div>
         )
    }
}