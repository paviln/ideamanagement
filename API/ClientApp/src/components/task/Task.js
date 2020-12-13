import React, {useState} from 'react'
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

  var task = props.task;

  return (
    <div className="d-flex bg-light border border-dark rounded p-3 mt-2">
      <div className="flex-grow-1">
        <p>{task.employee.name}</p>
        <p>{task.content}</p>
        <div>
          { commentsHidden == false &&
            populateComments(task.taskComments)
          }
        </div>
        <div className="d-flex allign-items-center border-top mt-2">
          <div>
            <a className="btn p-1 align-middle" onClick={() => handleClick()}>
              <i className="pr-2">
                <IconContext.Provider value={{ size: "1.5em" }}>
                  <AiOutlineComment />
                </IconContext.Provider>
              </i>
                  Comments
            </a>
          </div>
          <div className="align-self-center">
            <a> - {moment(task.date).format("DD/MM/YYYY, HH:mm:ss")}</a>
          </div>
        </div>
      </div>
    </div>
  );
}

export default Task
