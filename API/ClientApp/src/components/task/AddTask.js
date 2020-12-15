import React from 'react'
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button';

function AddTask() {
  return (
    <div>
      <h5>Task</h5>
      <Form>
        <Form.Group controlId="exampleForm.ControlTextarea1">
          <Form.Control as="textarea" rows={3} />
        </Form.Group>
        <Button variant="primary" type="submit">
          Add new task
        </Button>
      </Form>
    </div>
  )
}

export default AddTask
