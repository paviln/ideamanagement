import React from 'react'
import BTable from 'react-bootstrap/Table';

function Table(props) {

  const populateIdeas = () => {
    var ideas = props.ideas;
    if (ideas.length > 0) {
      const list = [];
      for (let i = 0; i < ideas.length; i++) {
        list.push(
          <tr key={i}>
            <td>{ideas[i].title}</td>
          </tr>
        );
      }

      return list;
    }

    return null;
  }

  return (
    <BTable className="mt-4" bordered hover>
      <thead className="thead-dark">
        <tr>
          <th>{props.title}</th>
        </tr>
      </thead>
      <tbody>
        { props.loading
          ? <p>loading</p>
          : populateIdeas()
        }
      </tbody>
    </BTable>
  )
}

export default Table
