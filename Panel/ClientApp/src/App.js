import React, { Component } from 'react';
import { Route, Switch, useLocation } from 'react-router-dom';
import { Layout } from './components/Layout';

import AddIdea from './components/AddIdea';
import NoMatch from './components/NoMatch';
import { Test } from './components/Test';
import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants';

import './App.scss';

export default class App extends Component {
  constructor(props) {
    super(props);
  }

  render () {
    return (
      <Layout>
        <Switch>
          <Route exact path='/' component={AddIdea} />
          <AuthorizeRoute path='/Test' component={Test} />
          <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />
          <Route path="*">
            <NoMatch></NoMatch>
          </Route>
        </Switch>
      </Layout>
    );
  }
}
