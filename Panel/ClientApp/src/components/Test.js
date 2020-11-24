import React, { Component } from 'react'
import { Route, Switch } from 'react-router-dom'

export class Test extends Component {
  render() {
    return (
      <div>
        dsadsa
        <Switch>
          <Route path={`${this.props.match.url}/:about`}>
            <About></About>
          </Route>
        </Switch>
      </div>
    )
  }
}

export default Test

function About() {
  return (
    <div>
      test
    </div>
  )
}
