import React from 'react'
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';

function Cost() {
  return (
    <div>
      <h5>Estimated cost savings</h5>
      <Form>
        <Form.Group controlId="cost">
          <Form.Control type="text" />
        </Form.Group>
        <Button variant="primary" type="submit">
          Save
        </Button>
      </Form>
    </div>
  )
}

export default Cost
