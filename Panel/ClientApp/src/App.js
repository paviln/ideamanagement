import React, { Component } from 'react';
import { Route, Switch, useLocation } from 'react-router-dom';
import { Layout } from './components/Layout';
import axios from 'axios';

import AddIdea from './components/AddIdea';
import NoMatch from './components/NoMatch';
import { Test } from './components/Test';
import ManagerView  from './components/ManagerView';
import NewIdeaTable  from './components/NewIdeaTable';
import IdeaPage  from './components/IdeaPage';
import UnderView  from './components/UnderView';
import Implemented  from './components/Implemented';
import UnderImplementation  from './components/UnderImplementation';
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
          <Route exact path='/manager' component={ManagerView} />
          <Route exact path='/idea table' component={NewIdeaTable} />
          <Route exact path='/idea page' component={IdeaPage} />
          <Route exact path='/under view' component={UnderView} />
          <Route exact path='/under implementation' component={UnderImplementation} />
          <Route exact path='/implemented' component={Implemented} />
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
