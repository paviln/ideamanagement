import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import ideaService from '../../services/IdeaService';
import authService from '../api-authorization/AuthorizeService';
import Comments from '../commen/Comments';

function Review() {

  const [loading, setLoading] = useState(true);
  const { id } = useParams();
  const [idea, setIdea] = useState();
  
  useEffect(() => {
    async function fetchData() {
      setLoading(true);

      await ideaService.get(id)
        .then(responce => {
          console.log(responce);
          if (responce.status == '200') {
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
    <div>
      <Comments comments={idea.ideaComments} />
    </div>
  )
}

export default Review
