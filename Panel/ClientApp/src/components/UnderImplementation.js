import React,{Component, useState} from 'react';
import Dropdown from 'react-bootstrap/Dropdown';
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
            <table class="table table-bordered">
            <thead>
            <tr>
            <th>Action</th>
            <th>Task</th>
            <th>Status</th>
            <th>Comments</th>
            </tr>
            </thead>
            <tbody>
            <tr>
            <td><div class="btn-group">
            <button type="button" class="btn btn-danger dropdown-toggle" data-toggle="dropdown">
            <span class="caret"></span>
            <span class="sr-only">Toggle Dropdown</span>
            </button>
            <ul class="dropdown-menu" role="menu">
            <li><a href="#">Edit task</a></li>
            <li><a href="#">Edit status</a></li>
            <li class="divider"></li>
            </ul>
            </div></td>
            <td>Employee Management</td>
            <td>Not started</td>
            <td></td>
            </tr>
            <tr>
            <td><div class="btn-group">
            <button type="button" class="btn btn-danger dropdown-toggle" data-toggle="dropdown">
            <span class="caret"></span>
            <span class="sr-only">Toggle Dropdown</span>
            </button>
            <ul class="dropdown-menu" role="menu">
            <li><a href="#">Edit task</a></li>
            <li><a href="#">Edit status</a></li>
            <li class="divider"></li>
            </ul>
            </div></td>
            <td>Improve Customer Service</td>
            <td>Progress</td>
            <td></td>
            </tr>
            <tr>
            <td><div class="btn-group">
            <button type="button" class="btn btn-danger dropdown-toggle" data-toggle="dropdown">
            <span class="caret"></span>
            <span class="sr-only">Toggle Dropdown</span>
            </button>
            <ul class="dropdown-menu" role="menu">
            <li><a href="#">Edit task</a></li>
            <li><a href="#">Edit status</a></li>
            <li class="divider"></li>
            </ul>
            </div></td>
            <td>Improve IT System</td>
            <td>Done</td>
            <td></td>
            </tr>
            </tbody>
            </table>

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
      </div>
      </Dropdown>
      </div>

      
         )
    }
}