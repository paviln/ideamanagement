import React, { Component } from 'react';
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button'
import IdeaService from '../services/IdeaService'
import {ManagerView} from './ManagerView'
import{ ButtonToolbar} from 'react-bootstrap';
import axios from 'axios';

export default class Login extends Component {
  constructor(props) {
    super(props); 
    this.state = {
      email: "",
      password: ""
    };
  
    this.handleChange = this.handleChange.bind(this); 
    this.handleChangePassWord = this.handleChangePassWord.bind(this);
   }

    

    handleChange = event => {
      this.setState({email: event.target.value});
    };

    handleChangePassWord = event => {
        this.setState({password: event.target.value});
      };

      handleSubmit = event => {
          event.preventDefault();
        this.setState({
            email: "",
            password: ""
        });

        const data = {
          email: this.email,
          password: this.password
          }

          axios.post('https://localhost:8000/login', data)
          .then(res => {
            localStorage.setItem('token', res.data.token);
          })
          .catch(err => {
            console.log(err)
          })
      };

      
    render(){
         return(

            
             <form>
             <div className="mt-3 d-flex justify-content-center ">
             <h1>Login</h1>
             </div>
             <br/>
               
                <Form.Group controlId="UserName" onChange={this.handleChange}>
                <Form.Label>Email address</Form.Label>
                <Form.Control value={this.state.email} type="email" placeholder="Enter email" size="sm"/>
                <Form.Text className="text-muted">
                </Form.Text>
                </Form.Group>

                <Form.Group controlId="PassWord" onChange={this.handleChangePassWord}>
                <Form.Label>Password</Form.Label>
                <Form.Control value={this.state.password} type="password" placeholder="Password" size="sm"/>
                </Form.Group>

                <Form.Group controlId="formBasicCheckbox">
                <Form.Check type="checkbox" label="Remember me" />
                </Form.Group>
            
               <Button onClick={event => this.handleSubmit(event)} variant="primary" type="login">
                Login
           
          </Button> 
           
        </form>
    )
    }
        

}
