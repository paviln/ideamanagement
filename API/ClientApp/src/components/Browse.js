import React, { useState, useEffect } from 'react';
import ideaService from '../services/IdeaService';
import Table from 'react-bootstrap/Table';

const Overview = () => {

  const [ideas, setIdeas] = useState([]);

  useEffect(() => {
    async function fetchData() {
      try {
        const response = await ideaService.getSiteIdeas(1);
        setIdeas(response.data);
        console.log(response);
      } catch (error) {
        console.log(error);
      }
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
          </tr>
        );
      }

      return list;
    }

    return null;
  }
  return (
    <p>To be</p>
  );
}

export default Overview
