import React, { useState, useEffect } from 'react'
import { useParams } from 'react-router-dom';
import authService from '../api-authorization/AuthorizeService';
import moment from 'moment';
import RangeSlider from 'react-bootstrap-range-slider';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import ProgressBar from 'react-bootstrap/ProgressBar';
import ideaService from '../../services/IdeaService';
import Files from './Files';
import Hashtags from './Hashtags';
import Comments from './Comments';
import Employees from './Employees';
import Tasks from '../task/Tasks';
import Form from 'react-bootstrap/Form';

function Idea() {
  const [loading, setloading] = useState(true);
  const { id } = useParams();
  const [idea, setIdea] = useState();
  const [auth, setAuth] = useState();
  const [priority, setPriority] = useState(0); 

  useEffect(() => {
    async function fetchData() {
      setloading(true);

      setAuth(await authService.isAuthenticated());

      await ideaService.get(id)
        .then(responce => {
          if (responce.status == '200') {
            setIdea(responce.data);
            setloading(false);
          }
        })
        .catch(error => {
          console.log(error)
        });
    }
    fetchData();
  }, [])

  const now = 3;
  if (loading === true) {
    return null;
  }

  var ideaStatus = {
    0: 'New',
    1: 'Under Review',
    2: 'Under Implementation',
    3: 'Implemented'
  }

  const getIdeaStatus = (key) => {

    return ideaStatus[key];
  }

  return (
    <div className="mb-4">
      <div className="d-flex justify-content-between align-items-center pt-4 pb-2">
        <h3>Idea</h3>
        <div>
          <p>Employee number: {idea.employeeNumber}</p>
          <p>Submission: {moment(idea.date).format("DD/MM/YYYY, HH:mm:ss")}</p>
          <p>Last edited: </p>
          <p>Status: {getIdeaStatus(idea.status)}</p>
        </div>
      </div>
      <h4>{idea.title}</h4>
      <p className="text-break">{idea.description}</p>
      <Row>
        <Col sm="6">
          <div className="pt-2">
            <h5 className="pr-2">Estimated effort</h5>
            <ProgressBar now={20 * now} label={`${now}`} />
          </div>
        </Col>
        <Col sm="6">
          <div className="pt-2">
            <h5 className="pr-2">Estimated impact</h5>
            <ProgressBar now={20 * now} label={`${now}`} />
          </div>
        </Col>
      </Row>
      <Row>
        <Col sm="6">
          <div className="pt-2">
            <h5 className="pr-2">Priority</h5>
            {auth
              ? <Form>
                  <Form.Group className="mb-0" controlId="formBasicRange">
                    <RangeSlider
                      value={priority}
                      min="0" 
                      max="3" 
                      step="1"
                      tooltip="auto"
                      tooltipPlacement="top"
                      onChange={changeEvent => setPriority(changeEvent.target.value)}
                    />
                  </Form.Group>
                </Form>
              : <ProgressBar now={0} label={`${now}`} />
            }
          </div>
        </Col>
      </Row>
      <Row>
        <Col sm="6">
          <div className="pt-4">
            <h5>Estimated cost</h5>
            <p>100$</p>
          </div>
        </Col>
      </Row>
      <Files files={idea.files} />
      <Hashtags hashtags={idea.hashtags} />
      <Comments ideaComments={idea.ideaComments} />
      <Employees employees={idea.employees} />
      <Tasks tasks={idea.tasks} />
      {idea.challenge &&
        <div className="mt-2">
          <h5>Challenges</h5>
          <p>{idea.challenge}</p>
        </div>
      }
      {idea.result &&
        <div className="mt-2">
          <h5>Results</h5>
          <p>{idea.result}</p>
        </div>
      }
    </div>
  );
}

export default Idea;