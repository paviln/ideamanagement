import React, { useEffect, useState } from 'react';
import Table from 'react-bootstrap/Table';
import ideaService from '../services/IdeaService';

const NewIdeas = (props) => {
  const [ideas, setIdeas] = useState('');
  useEffect(async() => {
    const result = await ideaService.getAll();
    setIdeas(result.data);
  }, []);
 
  const populateIdeas = () => {
    if (ideas != '')
    {
      const list = [];

    const data = ideas.data;
    console.log(data);
    for (let i = 0; i < data.length; i++) {
      list.push(
        <tr>
          <td>{data.ideaId}</td>
          <td>{data.title}</td>
          <td>{data.effort}</td>
          <td>{data.impact}</td>
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