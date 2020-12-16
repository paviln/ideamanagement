import React, { useState, useEffect } from 'react';
import { useHistory } from 'react-router-dom';
import { useLocation } from 'react-router-dom';
import ideaService from '../../services/IdeaService';
import Table from 'react-bootstrap/Table';
import Button from 'react-bootstrap/Button';

function TaskList() {

  const history = useHistory();
  const location = useLocation();
  const [tasks, setTasks] = useState([]);
  var idea = location.state.idea;

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
    history.push({
      pathname: "/" + idea.site.link + "/underimplementation/" + idea.ideaId + "/" + task.taskId,
      state: { task: task }
    });
  }

  const accept = async () => {
    idea.status = 3;
    var response = await ideaService.update(idea.ideaId, idea);
    if (response.status == '204') {
      history.push({
        pathname: "/" + idea.site.link + "/implemented/" + idea.ideaId,
        state: { idea: idea}
      });
    }
  }

  return (
    <div className="pt-4">
      <div className="d-flex justify-content-between align-items-center pt-4 pb-2">
        <h3>Tasks</h3>
        <div>
          <Button variant="secondary" onClick={accept}>Accept implementation</Button>       
         </div>
      </div>
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
