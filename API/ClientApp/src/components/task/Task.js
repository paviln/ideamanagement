import React, { useState } from 'react'
import moment from 'moment';
import { IconContext } from "react-icons";
import { AiOutlineComment } from 'react-icons/ai';
import Comment from '../commen/Comment';

function Task(props) {

  const [commentsHidden, setcommentsHidden] = useState(true);

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

  const handleClick = () => {
    setcommentsHidden(commentsHidden ? false : true)
  }

  var taskStatus = {
    0: 'Not Started',
    1: 'In Progress',
    2: 'Done'
  }
  
  const getTaskStatus = (key) => {

    return taskStatus[key];
  }

  var task = props.task;

  console.log(task);

  return (
    <div className="d-flex bg-light border border-dark rounded p-3 mt-2">
      <div className="flex-grow-1">
        <p>{task.employee.name}</p>
        <p>{task.content}</p>
        <div>
          {commentsHidden == false &&
            populateComments(task.taskComments)
          }
        </div>
        <div className="d-flex border-top mt-2">
          <p className="btn p-1" onClick={() => handleClick()}>
            <i className="pr-2">
              <IconContext.Provider value={{ size: "1.5em" }}>
                <AiOutlineComment />
              </IconContext.Provider>
            </i>
              Comments
            </p>
          <p className="align-self-center">{getTaskStatus(task.taskStatus)}</p>
          <p className="align-self-center"> - {moment(task.date).format("DD/MM/YYYY, HH:mm:ss")}</p>

        </div>
      </div>
    </div>
  );
}

export default Task
