import React, { useState } from 'react'
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button';
import commentService from '../../services/CommentService';

function Comment(props) {

  const [comment, setComment] = useState('');
  
  const addComment = async (e) => {
    e.preventDefault();

    if (comment) {
      await commentService.post(props.idea.ideaId, comment)
      .then(response => {
        if (response.status === 200) {
          setComment('');
        }
      });
    }
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
