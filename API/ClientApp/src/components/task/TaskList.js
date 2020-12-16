import React, { useState, useEffect } from 'react';
import { useHistory } from 'react-router-dom';
import { useLocation } from 'react-router-dom';
import ideaService from '../../services/IdeaService';
import Table from 'react-bootstrap/Table';

function TaskList() {

  const history = useHistory();
  const location = useLocation();
  const [tasks, setTasks] = useState([]);

  useEffect(() => {
    async function fetchData() {
      try {
        var response = await ideaService.get(location.state.idea.site.link, location.state.idea.ideaId);
        setTasks(response.data.tasks);
      } catch (error) {
        console.log(error);
      }
    }

    fetchData();
  }, []);

  const populateTasks = () => {
    if (tasks.length > 0) {
      const list = [];
      for (let i = 0; i < tasks.length; i++) {
        list.push(
          <tr key={i} onClick={() => handleClick(tasks[i])}>
            <td>{tasks[i].taskId}</td>
            <td>{tasks[i].content}</td>
          </tr>
        );
      }

      return list;
    }

    return null;
  }

  const handleClick = (task) => {
    console.log(task)

    var idea = location.state.idea;
    history.push({
      pathname: "/" + idea.site.link + "/underimplementation/" + idea.ideaId + "/" + task.taskId,
      state: { task: task }
    });
  }

  return (
    <div>
      <h3 className="pt-4">Tasks</h3>
      <Table className="mt-4" bordered hover>
        <thead className="thead-dark">
          <tr>
            <th>Id</th>
            <th>Description</th>
          </tr>
        </thead>
        <tbody>
          {populateTasks()}
        </tbody>
      </Table>
    </div>
  );
}

export default TaskList
