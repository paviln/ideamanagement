import React, { useState, useEffect } from 'react';
import { useParams, useLocation, useHistory} from 'react-router-dom';
import ideaService from '../../services/IdeaService';
import Button from 'react-bootstrap/Button';
import Saving from './Saving';
import AddTask from '../task/AddTask';
import AddUser from './AddUser';
import Comment from './Comment';

function Review() {

  const history = useHistory();
  const location = useLocation();
  const [loading, setLoading] = useState(true);
  const { id } = useParams();
  const [idea, setIdea] = useState();

  useEffect(() => {
    async function fetchData() {
      setLoading(true);

      await ideaService.get(location.state.link, id)
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

  const accept = async () => {
    idea.status = 2;
    var response = await ideaService.update(idea.ideaId, idea);
    if (response.status === 204) {
      history.push({
        pathname: "/" + idea.site.link + "/underimplementation/" + idea.ideaId,
        state: { idea: idea}
      });
    }
  }

  return (
    <div className="py-4">
      <div className="d-flex justify-content-between align-items-center pt-4 pb-2">
        <h3>Review</h3>
        <div>
          <Button variant="secondary" onClick={accept}>Move to implementation</Button>
        </div>
      </div>
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
