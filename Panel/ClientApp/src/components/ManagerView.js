import React,{Component, useState} from 'react';
import Dropdown from 'react-bootstrap/Dropdown';
import { Redirect } from 'react-router-dom';

export default class ManagerView extends Component {
  constructor(props){
    super(props)
    let ManagerTab = false
    this.state = {
      newideas: '',
      underview: '',
      underimplementation: '',
      implemented: '',
      ManagerTab
    }
  }
    render () {
      if(this.state.ManagerTab){
        return<Redirect to="/action-1"/>
      }
         return (
          <div>
          <h1>Manager View</h1>
          <br/>
          <Dropdown>
          <Dropdown.Toggle variant="success" id="dropdown-basic">
            Manager Tab
          </Dropdown.Toggle>
        
          <Dropdown.Menu>
          <Dropdown.Item href="#/action-1">New Ideas</Dropdown.Item>
          <Dropdown.Item href="#/action-2">Under View</Dropdown.Item>
          <Dropdown.Item href="#/action-3">Under Implementation</Dropdown.Item>
          <Dropdown.Item href="#/action-3">Implemented</Dropdown.Item>
          </Dropdown.Menu>
        </Dropdown>
        </div>
         )
    }
}