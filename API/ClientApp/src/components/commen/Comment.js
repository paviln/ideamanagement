import React from 'react'
import moment from 'moment';

function Comment(props) {

  var comment = props.comment;

  return (
    <div className="d-flex bg-light border border-dark rounded p-2 mt-2">
      <div className="flex-grow-1">
        <p>{comment.name}</p>
        <p>{comment.text}</p>
      </div>
      <div className="align-self-center">
        <p >{moment(comment.date).format("DD/MM/YYYY, HH:mm:ss")}</p>
      </div>
    </div>
  )
}

export default Comment
