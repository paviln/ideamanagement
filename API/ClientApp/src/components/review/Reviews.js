import React, { useEffect, useState } from 'react';
import { useHistory } from 'react-router-dom';
import ideaService from '../../services/IdeaService';
import IdeaTable from '../idea/IdeaTable';

function Reviews() {
  const history = useHistory();
  const [site, setSite] = useState();
  const [ideas, setIdeas] = useState([]);

  useEffect(() => {
    async function fetchData() {
      try {
        var response = await ideaService.getUserIdeasWithStatus(1);
        setIdeas(response.data);
      } catch (error) {
        console.log(error);
      }
    }
    fetchData();
  }, []);

  const populateIdeas = () => {
    const list = [];

    if (ideas !== null) {
      for (let i = 0; i < ideas.length; i++) {
        list.push(
          <tr onClick={() => handleClick(ideas[i].ideaId)}>
            <td>{ideas[i].ideaId}</td>
            <td>{ideas[i].title}</td>
            <td>{ideas[i].effort}</td>
            <td>{ideas[i].impact}</td>
          </tr>
        );
      }
    }

    return list;
  }

  const handleClick = (idea) => {
    history.push({
      pathname: "/" + idea.site.link + "/underview/" + idea.ideaId,
      state: { link: idea.site.link }
    });
  }

  return (
    <div>
      <h3 className="pt-4">Under Review</h3>
      <IdeaTable ideas={ideas} handleClick={handleClick} />
    </div>
  );
}

export default Reviews;