import React, { useEffect, useState } from 'react';
import { useHistory } from 'react-router-dom'
import Table from 'react-bootstrap/Table';
import ideaService from '../services/IdeaService';

const NewIdeas = (props) => {

  const history = useHistory();
  const [ideas, setIdeas] = useState([]);

  useEffect(() => {
    async function fetchData() {
      const response = await ideaService.getSiteIdeas(props.siteId);
      setIdeas(response.data);
    }
    fetchData();
  }, []);

  const populateIdeas = () => {
    if (ideas.length > 0) {
      const list = [];
      for (let i = 0; i < ideas.length; i++) {
        if (ideas[i].status == 0) {
          list.push(
            <tr key={i} onClick={() => handleClick(ideas[i].ideaId)}>
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

    return null;
  }

  const handleClick = (ideaId) => {
    history.push(props.prefix + "/ideapage/" + ideaId);
  }

  return (
    <div>
      <h3 className="pt-4">New Ideas</h3>
      <br />
      <Table striped bordered hover>
        <thead className="thead-dark">
          <tr>
            <th>S.no</th>
            <th>Title</th>
            <th>Effort</th>
            <th>Impact</th>
          </tr>
        </thead>
        <tbody>
          {populateIdeas()}
        </tbody>
      </Table>
    </div>
  );
}
export default NewIdeas;