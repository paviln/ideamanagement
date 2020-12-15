import React, { useState, useEffect } from 'react';
import { useHistory } from 'react-router-dom';
import ideaService from '../services/IdeaService';
import IdeaTable from './idea/IdeaTable';

function UnderImplementation() {
  const [ideas, setIdeas] = useState([]);
  const history = useHistory();

  useEffect(() => {
    async function fetchData() {
      try {
        var response = await ideaService.getUserIdeasWithStatus(2);
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
      <h3 className="pt-4">Under Implementation</h3>
      <IdeaTable ideas={ideas} handleClick={handleClick} />
    </div>
  );
}

export default UnderImplementation;

