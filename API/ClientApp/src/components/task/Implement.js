import React, { useEffect, useState } from 'react';
import { useParams, useLocation} from 'react-router-dom';
import taskService from '../../services/TaskService';
import Tasks from './Tasks';

function Implement() {

  const location = useLocation();
  const [ideas, setIdeas] = useState([]);

  useEffect(() => {
    async function fetchData() {
      try {
        var response = await taskService.get(location.state.idea.ideaId);
        setIdeas(response.data);
        console.log(response)
      } catch (error) {
        console.log(error);
      }
    }

    fetchData();
  }, []);

  return (
    <div>
      <Tasks tasks={ideas} />
    </div>
  )
}

export default Implement
