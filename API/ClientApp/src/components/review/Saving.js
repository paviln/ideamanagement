import React, { useState, useEffect } from 'react';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import ideaService from '../../services/IdeaService';

function Saving(props) {

  const [saving, setSaving] = useState(props.idea.saving);

  const addSaving = async (e) => {
    e.preventDefault();

    if (saving) {
      await ideaService.update(props.idea.ideaId, saving)
        .then(response => {
          if (response.status === 204) {

          }
        })
        .catch(error => {
          console.log(error)
        });
    }
  }

  return (
    <div>
      <h5>Estimated cost savings</h5>
      <Form onSubmit={addSaving}>
        <Form.Group controlId="cost">
          <Form.Control type="number" value={saving} onChange={(e) => setSaving(e.target.value)} />
        </Form.Group>
        <Button variant="primary" type="submit">
          Save
        </Button>
      </Form>
    </div>
  )
}

export default Saving
