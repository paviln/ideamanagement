import React, { Component } from 'react'
import { Route, Switch, useLocation } from 'react-router-dom';
import AddIdea from './components/AddIdea';
import NoMatch from './components/NoMatch';

export class Test extends Component {
  constructor() {
    super();
  }
  render() {
    console.log(this.props.url)
    return (
      <Switch>
        <Route exact path='${this.state.url}/' component={AddIdea} />
        <Route path="/test" component={Test}></Route>
        <Route path="*">
          <NoMatch></NoMatch>
        </Route>
    </Switch>
    )
  }
}

export default Test
