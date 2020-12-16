import React, { useState } from 'react';
import Form from 'react-bootstrap/Form';
import { useLocation } from 'react-router-dom';
import Button from 'react-bootstrap/Button';
import ideaService from '../../services/IdeaService';

function Evaluate() {
  const location = useLocation();
  const [challenge, setChallenge] = useState('');
  const [result, setResult] = useState('');
  var idea = location.state.idea;
  
console.log(idea)
  
  const save = async (e) => {
    e.preventDefault();
    console.log(idea)

    try {
      idea.challenge = challenge;
      idea.result = result;

      var response = await ideaService.update(idea.ideaId, idea);
      if (response.status == 204) {

      }
    } catch (error) {
      console.log(error);
    }
  }

  return (
    <div className="pb-4">
      <h3 className="pt-4">Review</h3>
      <Form onSubmit={save}>
        <Form.Group controlId="exampleForm.ControlTextarea1">
          <Form.Label>Challenges</Form.Label>
          <Form.Control as="textarea" rows={3} value={challenge} onChange={(e) => setChallenge(e.target.value)} />
        </Form.Group>
        <Form.Group controlId="exampleForm.ControlTextarea1">
          <Form.Label>Results</Form.Label>
          <Form.Control as="textarea" rows={3} value={result} onChange={(e) => setResult(e.target.value)} />
        </Form.Group>
        <Button variant="primary" type="submit">
          Submit
        </Button>
      </Form>
    </div>
  );
}

export default Evaluate
