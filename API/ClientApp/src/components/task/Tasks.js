import React from 'react';
import Task from './Task';

function Tasks(props) {

  const populateTasks = (tasks) => {
    const list = [];

    if (tasks !== null) {
      for (let i = 0; i < tasks.length; i++) {
        list.push(
          <Task task={tasks[i]} />
        );
      }
    }

    return list;
  }

  var tasks = populateTasks(props.tasks)

  if (tasks.length > 0) {
    return (
      <div>
        <h5 className="pt-2">Tasks</h5>
        {tasks}
      </div>
    );
  }

  return null;
}

export default Tasks
