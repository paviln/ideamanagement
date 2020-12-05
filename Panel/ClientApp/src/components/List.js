import React, {useState} from 'react'
import Button from 'react-bootstrap/Button'

const List = (props) => {

  const populateList = () => {
    const list = [];
    
    const data = props.data;
    for (let i = 0; i < data.length; i++) {
      list.push(<li>{data[i]}</li>)
    }

    return (
      list
    );
  }
  
  
  return (
    <ul>
      {populateList()}
    </ul>
  )
}

export default List
