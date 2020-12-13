import React from 'react';
import ListGroup from 'react-bootstrap/ListGroup';

function Comments(props) {

  const populateComments = (comments) => {
    const list = [];

    if (comments !== null) {
      for (let i = 0; i < comments.length; i++) {
        list.push(
          <ListGroup.Item>
            {comments[i].text}
          </ListGroup.Item>
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
        <ListGroup>
          {comments}
        </ListGroup>
      </div>
    );
  }
  return null;
}

export default Comments
