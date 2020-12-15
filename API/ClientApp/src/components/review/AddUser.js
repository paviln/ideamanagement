import React from 'react';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';

function AddUser() {
  return (
    <div>
      <h5>Employee</h5>
      <Form>
        <Form.Group controlId="addUserPostition">
          <Form.Label>Postition</Form.Label>
          <Form.Control type="text" />
        </Form.Group>
        <Form.Group controlId="addUserName">
          <Form.Label>Name</Form.Label>
          <Form.Control type="text" />
        </Form.Group>
        <Button variant="primary" type="submit">
          Add Employee
        </Button>
      </Form>
    </div>
  );
}

export default AddUser
