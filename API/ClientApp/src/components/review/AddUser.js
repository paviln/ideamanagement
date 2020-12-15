import React , { useState } from 'react';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import employeeService from '../../services/EmployeeService';

function AddUser(props) {

  const [postition, setPostition] = useState('');
  const [name, setName] = useState('');

  const addComment = async (e) => {
    e.preventDefault();

    if (postition && name) {
      await employeeService.post(props.idea.ideaId, postition, name)
        .then(response => {
          if (response.status === 200) {
            setPostition('');
            setName('');
          }
        });
    }
  }
  return (
    <div>
      <h5>Employee</h5>
      <Form onSubmit={addComment}>
        <Form.Group controlId="addUserPostition">
          <Form.Label>Postition</Form.Label>
          <Form.Control type="text" value={postition} onChange={(e) => setPostition(e.target.value)} />
        </Form.Group>
        <Form.Group controlId="addUserName">
          <Form.Label>Name</Form.Label>
          <Form.Control type="text" value={name} onChange={(e) => setName(e.target.value)} />
        </Form.Group>
        <Button variant="primary" type="submit">
          Add Employee
        </Button>
      </Form>
    </div>
  );
}

export default AddUser
