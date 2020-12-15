import React, { useEffect, useState } from 'react';
import { useHistory } from 'react-router-dom';
import ideaService from '../services/IdeaService';
import IdeaTable from './idea/IdeaTable';

function Implemented() {

    const history = useHistory();
    const [ideas, setIdeas] = useState([]);

    useEffect(() => {
        async function fetchData() {
            try {
                var response = await ideaService.getUserIdeasWithStatus(3);
                setIdeas(response.data);
            } catch (error) {
                console.log(error);
            }
        }

        fetchData();
    }, []);

    const handleClick = (ideaId, link) => {
        history.push("/" + link + "/implemented/" + ideaId);
    }
    return (
        <div>
            <div>
                <h3 className="pt-4">Implemented</h3>
                <IdeaTable ideas={ideas} handleClick={handleClick} />
            </div>
        </div>
    )
}

export default Implemented
