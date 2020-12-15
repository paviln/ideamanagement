import React, { useEffect, useState } from 'react';
import { useHistory } from 'react-router-dom';
import ideaService from '../services/IdeaService';
import IdeaTable from './idea/IdeaTable';

const NewIdeas = () => {

  const history = useHistory();
  const [ideas, setIdeas] = useState([]);

  useEffect(() => {
    async function fetchData() {
      try {
        var response = await ideaService.getUserIdeasWithStatus(0);
        setIdeas(response.data);
      } catch (error) {
        console.log(error);
      }
    }

    fetchData();
  }, []);

  const handleClick = (ideaId, link) => {
    history.push("/" + link + "/idea/" + ideaId);
  }

  return (
    <div>
      <h3 className="pt-4">New Ideas</h3>
      <IdeaTable ideas={ideas} handleClick={handleClick} />
    </div>
  );
}
export default NewIdeas;