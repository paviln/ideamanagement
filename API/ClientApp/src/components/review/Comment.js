import React, { useState } from 'react'
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button';
import ideaService from '../../services/IdeaService';

function Comment(props) {

  const [comment, setComment] = useState("");
  
  const handleChange = () => {

  }

  const addComment = async (e) => {
    e.preventDefault();
    console.log(comment)

    await ideaService.postIdeaComment(comment)
    .then(response => {
      if (response == '200') {
      }
      console.log(response);

    });
  }

  return (
    <div>
      <h5>Comment</h5>
      <Form onSubmit={addComment}>
        <Form.Group controlId="exampleForm.ControlTextarea1">
          <Form.Control name="content" value={comment} as="textarea" rows={3} onChange={(e) => setComment(e.target.value)} />
        </Form.Group>
        <Button variant="primary" type="submit">
          Add new comment
        </Button>
      </Form>
    </div>
  )
}

export default Comment
