import React, { Component } from 'react';
import { Route, Switch } from 'react-router-dom';
import { Layout } from './components/Layout';

import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants';
//import authService from './components/api-authorization/AuthorizeService';
import siteService from './services/SiteService';
import AddIdea from './components/AddIdea';
import NoMatch from './components/NoMatch';
//import Test from './components/Test';
import Manager from './components/Manager';

import './App.scss';

export default class App extends Component {

  constructor(props) {
    super(props);

    this.state = {
      ready: false,
      authenticated: false,
      side: {
        sideId: null,
        link: ''
      }
    }
  }

  componentDidMount() {
    var url = window.location.href;
    url = url.split("/");
    url = url[3];

    siteService.get(2)
    .then(response => {
      const data = response.data;
      console.log(data['sideId']);
      this.setState({
        side: data
      })
    });
  }

  async getSite() {
    var url = window.location.href;
    url = url.split("/");
    url = url[3];

    try {
      const sitePromise = await siteService.get(2);
      this.setState({ 
        side: await sitePromise.data
      });
    } catch (error) {
      
    }
  }

  async populateState() {
    this.getSite();
  }

  render() {
    if (this.state.side.sideId === null) {
      return null;
    }
    console.log(this.state);
    var prefix = "/";

    if (this.state.ready) {
      if (this.state.authenticated) {
        prefix = "/linak";
        if (this.state.link !== "linak") {
          window.location.replace("https://localhost:5001/linak");
        }
      } else if (this.state.link && this.state.link !== "authentication") {
        prefix = "/" + this.state.link;
      }
    }

    return (
      <Layout prefix={prefix}>
        <Switch>
          <Route
            path={prefix}
            render={(props) => (
              <AddIdea {...props} sideId={this.state.side} />
            )}
          />
          <AuthorizeRoute path='/manager' component={Manager} />
          <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />
          <Route path="*">
            <NoMatch></NoMatch>
          </Route>
        </Switch>
      </Layout>
    );
  }
}
