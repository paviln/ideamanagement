import React, { Component } from 'react';
import AddIdea from './AddIdea';
import ListIdeas from './ListIdeas';

export class Idea extends Component {
  constructor(props) {
    super(props);

    this.state = { 
      ideas: [], 
      loading: true,
      isAdd: false,
    };
  }

  toogleShow = event => {
    if (!this.state.isAdd)
    {
      this.setState({ isAdd: true })
    }
    else {
      this.setState({ isAdd: false })
    }
  }

  render() {
    if (this.state.isAdd === false) {
      return (
        <div>
          <h1 id="tabelLabel" >Ideas</h1>
          <form onSubmit={this.toogleShow}>
            <button type="submit" className="btn btn-default">Add Idea</button>
          </form>
          <ListIdeas loading={this.state.loading}></ListIdeas>
        </div>
      );
    } else {
      return (
        <div>
          <form onSubmit={this.toogleShow}>
            <button type="submit" className="btn btn-default">Go back</button>
          </form>
          <AddIdea></AddIdea>
        </div>
      );
    }
  }
}
