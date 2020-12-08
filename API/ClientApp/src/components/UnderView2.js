import React,{Component, useState} from 'react';
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button';
import InputGroup from 'react-bootstrap/InputGroup';
import FormControl from 'react-bootstrap/FormControl';

export default class UnderView2 extends Component {
// this page is shown when a task is clicked in UnderView page
    render () {
         return (
             <div>
                 <h1>Add User</h1>
                <Form>
                <Form.Group controlId="formBasicEmail">
                <Form.Label>Email address</Form.Label>
                <Form.Control type="email" placeholder="Enter email" />
                <Form.Text className="text-muted">
                </Form.Text>

                </Form.Group>
                <Button className="badge-pill btn btn-lg" variant="primary" type="adduser">
                Add
                </Button>
                </Form>
                
                <br/>
                <form>
                <InputGroup className="mb-3"><span class="border border-primary"></span>
                <FormControl
                placeholder=" Estimate the cost"
                aria-label="estimate cost"
                aria-describedby="basic-addon2"/>
                <InputGroup.Append>
                <button class="btn btn-primary pull-right badge-pill" type="button">Add</button>
                </InputGroup.Append>
                </InputGroup>

                <InputGroup className="mb-3"><span class="border border-primary"></span>
                <FormControl
                placeholder=" Add Task"
                aria-label="add task"
                aria-describedby="basic-addon2"/>
                <InputGroup.Append>
                <button class="btn btn-primary pull-right badge-pill" type="button">Add</button>
                </InputGroup.Append>
                </InputGroup>
           
                <br/>
                <Form.Group controlId="exampleForm.ControlTextarea1">
                <Form.Label>Comments</Form.Label>
                <Form.Control as="textarea" rows={3}/>
                </Form.Group>
                <button class="btn btn-primary pull-right badge-pill btn-lg" type="button">Add</button>
                </form>
                </div>
            )
    }
}