import React,{Component, useState} from 'react';
import Table from 'react-bootstrap/Table';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import { ButtonToolbar } from 'react-bootstrap';
import { Container, Row, Col} from 'react-bootstrap';
import './My.css';
import { confirmAlert } from 'react-confirm-alert'; 

export default class IdeaPage extends Component {
  // To accept the idea
  submit = () => {
    confirmAlert({
      title: 'Confirm to Accept',
      message: 'Are you sure to accept the idea.',
      buttons: [
        {
          label: 'Yes',
          onClick: () => alert('Click Yes')
        },
        {
          label: 'No',
          onClick: () => alert('Click No')
        }
      ]
    });
  };
  // To reject the idea
  submit1 = () => {
    confirmAlert({
      title: 'Confirm to Reject',
      message: 'Are you sure to reject the idea.',
      buttons: [
        {
          label: 'Yes',
          onClick: () => alert('Click Yes')
        },
        {
          label: 'No',
          onClick: () => alert('Click No')
        }
      ]
    });
  };
    render () {  
         return (
             <div>
            <Container>
            <p/> 
            <div>
            <h1>IDEAS</h1>
            </div>
            <br/>
            <div>
             <div className="row">
            <div class="col-md-12 text-right">
            <button class="btn btn-primary badge-pill" badge-pill onClick={this.submit}>Accept Idea</button>{' '}
            <button class="btn btn-danger badge-pill" onClick={this.submit1}>Reject Idea</button>{' '}
            </div>

              </div>
              <br/>
               <Row className="rows">
                  <Col className="columns">Title:</Col>
                  <Col className="columns" md={2}></Col>
                  <Col  className="columns">Description:</Col>
                  <Col className="columns" md={4}></Col>
                  <Col className="columns">Date of submission:</Col>
                  <Col className="columns"></Col>
                  
              </Row>
                </div>
                <br/>
                <div>
               <Row className="rows">
                <Col className="columns">Date of Edited:</Col>
                <Col className="columns" sm={2}></Col>
                <Col className="columns">Priority:</Col>
                <Col className="columns"></Col>
                <Col className="columns">Cost of saving:</Col>
                <Col className="columns"></Col>
                </Row>
                </div>
                <br/>
                <div >
                <Row className="rows">
                <Col className="columns">Status:</Col>
                <Col className="columns"></Col>
                <Col className="columns">Comments:</Col>
                <Col className="columns"></Col>
                </Row>
                </div>
                <br/>
                <div >
                <p>TASK IMPLEMENTATION</p>
                <Row className="rows">
                <Col className="columns">Task related to Implementation:</Col>
                <Col className="columns"></Col>
                <Col className="columns">Status:</Col>
                <Col className="columns"></Col>
                 <Col className="columns">Challenges:</Col>
                <Col className="columns"></Col>
                <Col className="columns">Results:</Col>
                <Col className="columns"></Col>   
                <Col className="columns">Comments:</Col>
                <Col className="columns"></Col>
                </Row>
                </div>
                
             </Container>
                <br/>
                <h1>Add User</h1>
                <Form>
                <Form.Group controlId="formBasicEmail">
                <Form.Label>Email address</Form.Label>
                <Form.Control type="email" placeholder="Enter email" />
                <Form.Text className="text-muted">
                </Form.Text>
                </Form.Group>

                <Button variant="primary" type="adduser">
                Add
                </Button>
                </Form>
          </div>
          
         );
         
    }
}