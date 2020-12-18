import React, { useEffect, useState } from 'react';
import { useLocation } from 'react-router-dom';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import taskService from '../../services/TaskService';

function Implement() {

  const location = useLocation();
  const [status, setStatus] = useState(location.state.task.taskStatus);
  const [comment, setComment] = useState('');
  var task = location.state.task;

  const changeStatus = async (e) => {
    e.preventDefault();

    try {
      task.taskStatus = status;
      var response = await taskService.update(task.taskId, task);
      if (response.status === 202) {
        console.log("Success");
      }
    } catch (error) {
      console.log(error);
    }
  }

  const saveComment = async (e) => {
    e.preventDefault();

    try {
      var response = await taskService.saveComment(task.taskId, comment);
      if (response.status === 200) {
        setComment('');
      }
    } catch (error) {
      console.log(error);
    }
  }

  return (
    <div>
      <div className="pb-4">
        <h3 className="pt-4">Implement</h3>
        <Form onSubmit={changeStatus}>
          <Form.Group controlId="status">
            <Form.Label>Status</Form.Label>
            <Form.Control as="select" value={status} onChange={(e) => setStatus(e.target.value)}>
              <option value="0">Not started</option>
              <option value="1">In Progress</option>
              <option value="2">Done</option>
            </Form.Control>
          </Form.Group>
          <Button variant="primary" type="submit">
            Save status
          </Button>
        </Form>
        <Form onSubmit={saveComment} className="mt-4">
          <Form.Group controlId="comment">
            <Form.Label>Comment</Form.Label>
            <Form.Control as="textarea" value={comment} onChange={(e) => setComment(e.target.value)} rows={3} />
          </Form.Group>
          <Button variant="primary" type="submit">
            Save comment
          </Button>
        </Form>
      </div>
    </div>
  )
}

export default Implement
