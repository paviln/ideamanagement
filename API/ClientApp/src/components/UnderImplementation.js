import React, { Component } from 'react';
import Dropdown from 'react-bootstrap/Dropdown';
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button';
import Table from 'react-bootstrap/Table';
import Modal from 'react-bootstrap/Modal';
import './My.css';
import EditButton from 'react-edit-button'
import EdiText from 'react-editext'

export default class UnderImplementation extends Component {
    constructor(props)
    {
        super(props)
        this.state={
            show:false,
            isEditing:false
        }
    }
    handleModal()
    {
       this.setState({show:!this.state.show})
    }
   
    onSave = val => {
        console.log('Edited Value -> ', val)
      }
    render() {
        return (
            <div>
                <h1>Under Implementation</h1>
               
                <br />
                <Dropdown onSelect={this.change}>
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
                <td>
                <div>
                 <EdiText
                type='text'
                value='Employee Management'
                onSave={this.onSave}
               />
                </div>
                </td>
                <td>
                <label></label>
                <select class="form-control">
                <option>Not started</option>
                <option>Pogress</option>
                <option>Done</option>
                </select>
                 </td>
                <td></td>
                <td class="text-center">
                <div>
                <button  class="btn btn-primary badge-pill" onClick={()=>{this.handleModal()}}>Add Comment</button>
                <Modal show={this.state.show} onHide={()=>{this.handleModal()}}>
                <Modal.Header closeButton>Comment</Modal.Header>
                <Modal.Body>
                <Form>
                <Form.Group controlId="formBasicText">
                <Form.Control type="text" placeholder="" />
                </Form.Group>
                </Form>
                </Modal.Body>
                <Modal.Footer>
                 <button class="btn btn-primary btn-lg badge-pill">Add</button>
                <button  class="btn btn-danger btn-lg badge-pill"  onClick={()=>{this.handleModal()}}>
                Close
                </button>
                </Modal.Footer>
                </Modal>
                 </div>

                </td>
                </tr>
                <tr>
                <td>2</td>
                <td>
                <div>
                <EdiText
                type='text'
                value='Improve Customer Service'
                onSave={this.onSave}
               />
                </div>          
                </td>
                <td>
                <label></label>
                <select class="form-control">
                <option>Not started</option>
                <option>Pogress</option>
                <option>Done</option>
                </select>
                </td>
                <td></td>
                <td className="text-center">
                <div>
                <button  class="btn btn-primary badge-pill" onClick={()=>{this.handleModal()}}>Add Comment</button>
                <Modal show={this.state.show} onHide={()=>{this.handleModal()}}>
                <Modal.Header closeButton>Comment</Modal.Header>
                <Modal.Body>
                <Form>
                <Form.Group controlId="formBasicText">
                <Form.Control type="text" placeholder="" />
                </Form.Group>
                </Form>
                </Modal.Body>
                <Modal.Footer>
                 <button class="btn btn-primary btn-lg badge-pill">Add</button>
                <button  class="btn btn-danger btn-lg badge-pill"  onClick={()=>{this.handleModal()}}>
                Close
                </button>
                </Modal.Footer>
                </Modal>
                 </div>                </td>
                 </tr>

                <tr>
                <td>3</td>
                <td>
                <div>
                <EdiText
                type='text'
                value='Improve IT System'
                onSave={this.onSave}
               />
                 </div>
                </td>
                <td>
                <label></label>
                <select class="form-control">
                <option>Not started</option>
                <option>Pogress</option>
                <option>Done</option>
                </select>
                </td>
                <td></td>
                <td className="text-center">
                <div>
                <button  class="btn btn-primary badge-pill" onClick={()=>{this.handleModal()}}>Add Comment</button>
                <Modal show={this.state.show} onHide={()=>{this.handleModal()}}>
                <Modal.Header closeButton>Comment</Modal.Header>
                <Modal.Body>
                <Form>
                <Form.Group controlId="formBasicText">
                <Form.Control type="text" placeholder="" />
                </Form.Group>
                </Form>
                </Modal.Body>
                <Modal.Footer>
                 <button class="btn btn-primary btn-lg badge-pill">Add</button>
                <button  class="btn btn-danger btn-lg badge-pill"  onClick={()=>{this.handleModal()}}>
                Close
                </button>
                </Modal.Footer>
                </Modal>
                 </div>                </td>
                </tr>
                </tbody>
                </table>
                </div>
                </Dropdown>  
            </div>
        )
    }
}
