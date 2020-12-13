import React from 'react';
import Comment from './commen/Comment';

function Comments(props) {

  const populateComments = (comments) => {
    const list = [];

    if (comments !== null) {
      for (let i = 0; i < comments.length; i++) {
        list.push(
          <Comment comment={comments[i]} />
        );
      }
    }

    return list;
  }

  var comments = populateComments(props.ideaComments)

  if (comments.length > 0) {
    return (
      <div>
        <h5 className="pt-2">Comments</h5>
        {comments}
      </div>
    );
  }
  return null;
}

export default Comments
