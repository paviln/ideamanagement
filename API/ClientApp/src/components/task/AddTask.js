import React, { useState } from 'react'
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button';
import taskService from '../../services/TaskService';

function AddTask(props) {
  const [task, setTask] = useState('');

  const addTask = async (e) => {
    e.preventDefault();

    if (task) {
      await taskService.post(props.idea.ideaId, task)
        .then(response => {
          if (response.status === 200) {
            setTask('');
          }
        });
    }
  }

  return (
    <div onSubmit={addTask}>
      <h5>Task</h5>
      <Form>
        <Form.Group controlId="exampleForm.ControlTextarea1">
          <Form.Control value={task} onChange={(e) => setTask(e.target.value)} as="textarea" rows={3} />
        </Form.Group>
        <Button variant="primary" type="submit">
          Add new task
        </Button>
      </Form>
    </div>
  )
}

export default AddTask
