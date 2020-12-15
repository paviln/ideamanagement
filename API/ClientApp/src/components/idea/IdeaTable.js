import React, { useState, useEffect } from 'react';
import Table from 'react-bootstrap/Table';

function IdeaTable(props) {

  const ideas = props.ideas;
  
  const populateIdeas = () => {

    if (ideas.length > 0) {
      const list = [];
      for (let i = 0; i < ideas.length; i++) {
        list.push(
          <tr key={i} onClick={() => props.handleClick(ideas[i])}>
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
  )
}

export default IdeaTable
