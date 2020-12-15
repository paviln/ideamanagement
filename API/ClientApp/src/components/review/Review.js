import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import ideaService from '../../services/IdeaService';
import Saving from './Saving';
import AddTask from '../task/AddTask';
import AddUser from './AddUser';
import Comment from './Comment';

function Review() {

  const [loading, setLoading] = useState(true);
  const { id } = useParams();
  const [idea, setIdea] = useState();
  
  useEffect(() => {
    async function fetchData() {
      setLoading(true);

      await ideaService.get(id)
        .then(responce => {
          if (responce.status === 200) {
            setIdea(responce.data);
            setLoading(false);
          }
        })
        .catch(error => {
          console.log(error)
        });
    }
    fetchData();
  }, []);

  if (loading === true) {
    return null;
  }

  return (
    <div className="pb-4">
      <h3 className="pt-4">Review</h3>
      <Comment idea={idea} />
      <hr />
      <AddUser idea={idea} />
      <hr />
      <AddTask idea={idea} />
      <hr />
      <Saving idea={idea} />
    </div>
  )
}

export default Review
