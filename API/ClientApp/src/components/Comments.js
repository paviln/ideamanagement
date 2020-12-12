import React from 'react'

function Comments(props) {

  const populateComments = (comments) => {
    const list = [];

    if (comments !== null) {
      for (let i = 0; i < comments.length; i++) {
        list.push(
          <li className="pt-2">
            {comments[i].name}
          </li>
        );
      }
    }

    return list;
  }

  var comments = populateComments(props.comments)

  if (comments.length > 0) {
    return (
      <div>
        <ul>
          {comments}
        </ul>
      </div>
    );
  }
}

export default Comments
