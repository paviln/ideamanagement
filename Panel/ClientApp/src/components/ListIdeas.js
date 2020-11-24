import React, { Component } from 'react';

import IdeaService from '../services/IdeaService';

export class ListIdeas extends Component {

  constructor(props) {
    super(props);


  }

  componentDidMount() {
    IdeaService.getAll().then((res) => {
      this.setState({ ideas: res.data });
      this.setState({ loading: false })
    })
  }

  static deleteIdea(e) {
    console.log(e.target.parentNode.getAttribute("data-key"));
    IdeaService.remove(e.target.parentNode.getAttribute("data-key"));
  }

  static renderIdeasTable(ideas) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Title</th>
          </tr>
        </thead>
        <tbody>
          {ideas.map(idea =>
            <tr key={idea.id} data-key={idea.id}>
              <td>{idea.title}</td>
              <td><button className="btn btn-secondary" onClick={this.deleteIdea}>Delete</button></td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }
  
  render() {
    let contents = this.props.loading
    ? <p><em>Loading...</em></p>
    : ListIdeas.renderIdeasTable(this.state.ideas);

    return (
      <div>
        {contents}
      </div>
    )
  }
}

export default ListIdeas
