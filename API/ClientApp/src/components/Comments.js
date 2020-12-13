import React from 'react';
import moment from 'moment';

function Comments(props) {

  const populateComments = (comments) => {
    const list = [];

    if (comments !== null) {
      for (let i = 0; i < comments.length; i++) {
        list.push(
          <div className="d-flex bg-light border border-dark rounded p-2 mt-2">
            <div className="flex-grow-1">
              <p>{comments[i].name}</p>
              <p>{comments[i].text}</p>
            </div>
            <div className="align-self-center">
              <p >{moment(comments[i].date).format("DD/MM/YYYY, HH:mm:ss")}</p>
            </div>
          </div>
        );
      }
    }

    return list;
  }

  var comments = populateComments(props.ideaComments)

  if (comments.length > 0) {
    return (
      <div>
        <p className="pt-4">Comments</p>
        {comments}
      </div>
    );
  }
  return null;
}

export default Comments
