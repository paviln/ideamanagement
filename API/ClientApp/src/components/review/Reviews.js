import React, { useEffect, useState } from 'react';
import { useHistory } from 'react-router-dom';
import Table from 'react-bootstrap/Table';
import authService from '../api-authorization/AuthorizeService';
import ideaService from '../../services/IdeaService';

function Reviews() {
  const history = useHistory();
  const [site, setSite] = useState();
  const [ideas, setIdeas] = useState([]);

  useEffect(() => {
    async function fetchData() {
      try {
        var res = await authService.getSite();
        setSite(res);
        var response = await ideaService.getSiteIdeasUnderReview(res);
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
          </tr>
        );
      }
    }

    return list;
  }

  const handleClick = (ideaId) => {
    history.push("/" + site + "/idea/" + ideaId);
  }

  return (
    <div>
      <h3 className="pt-4">Under Review</h3>
      <Table striped bordered hover>
        <thead class="thead-dark">
          <tr >
            <th>S.no</th>
            <th>Idea</th>
          </tr>
        </thead>
        <tbody>
          {populateIdeas()}
        </tbody>
      </Table>
    </div>
  );
}

export default Reviews;