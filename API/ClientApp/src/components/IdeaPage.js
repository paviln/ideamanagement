import React,{Component, useState} from 'react';
import Table from 'react-bootstrap/Table';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import { ButtonToolbar } from 'react-bootstrap';
import { Container, Row, Col} from 'react-bootstrap';
import './My.css';

export default class IdeaPage extends Component {

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