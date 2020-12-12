import React, { useState, useEffect } from 'react'
import { useParams } from 'react-router-dom';
import moment from 'moment';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import ProgressBar from 'react-bootstrap/ProgressBar';
import './My.css';
import ideaService from '../services/IdeaService';
import Files from './Files';
import Hashtags from './Hashtags';

function IdeaPage() {
  const [loading, setloading] = useState(true);

  const { id } = useParams();
  const [idea, setIdea] = useState();

  useEffect(() => {
    async function fetchData() {
      try {
        setloading(true);
        var idea = await ideaService.get(id);
        setIdea(idea.data);
      } catch (error) {
        throw error;
      } finally {
        setloading(false);
      }
    }
    fetchData();
  }, [])

  const now = 3;
  if (loading === true) {
    return null;
  }
  return (
    <div>
      <div className="d-flex justify-content-between align-items-center pt-4 pb-2">
        <h3>Idea Page</h3>
        <div>
          <p>Employee number: {idea.employeeNumber}</p>
          <p>Submission: {moment(idea.date).format("DD/MM/YYYY, HH:mm:ss")}</p>
          <p>Last edited: </p>
          <p>Status: {idea.status}</p>
        </div>
      </div>
      <h4>{idea.title}</h4>
      <p className="text-break">{idea.description}</p>
      <Row>
        <Col sm="6">
          <div className="pt-4">
            <p className="pr-2">Estimated effort</p>
            <ProgressBar className="flex-grow-1" now={20 * now} label={`${now}`} />
          </div>
        </Col>
        <Col sm="6">
          <div className="pt-4">
            <p className="pr-2">Priority</p>
            <ProgressBar className="flex-grow-1" now={0} label={`${now}`} />
          </div>
        </Col>
      </Row>
      <Row>
        <Col sm="6">
          <div className="pt-4">
            <p className="pr-2">Estimated impact</p>
            <ProgressBar className="flex-grow-1" now={20 * now} label={`${now}`} />
          </div>
        </Col>

        <Col sm="6">
          <div className="pt-4">
            <p className="pr-2">Estimated cost</p>
            <ProgressBar className="flex-grow-1" now={20 * now} label={`${now}`} />
          </div>
        </Col>
      </Row>
      <Files files={idea.files} />
      <Hashtags hashtags={idea.hashtags} />
    </div>
  );
}

export default IdeaPage;