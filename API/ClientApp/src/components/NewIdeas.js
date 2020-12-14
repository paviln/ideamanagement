import React, { useEffect, useState } from 'react';
import Table from 'react-bootstrap/Table';
import ideaService from '../services/IdeaService';
const NewIdeas = () => {

  const [ideas, setIdeas] = useState([]);

  useEffect(() => {
    async function fetchData() {
      const response = await ideaService.getAll();
      setIdeas(response.data);
    }
    fetchData();
  }, []);

  const populateIdeas = () => {
    if (ideas.length > 0) {
      const list = [];
      for (let i = 0; i < ideas.length; i++) {
        list.push(
          <tr key={i}>
            <td>{ideas[i].ideaId}</td>
            <td>{ideas[i].title}</td>
            <td>{ideas[i].effort}</td>
            <td>{ideas[i].impact}</td>
          </tr>
        );
      }

      return list;
    }

    return null;
  }

  return (
    <div>
      <h1>New Ideas</h1>
      <br />
      <Table striped bordered hover>
        <thead className="thead-dark">
          <tr  onclick="location.href ='/ideapage';">
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