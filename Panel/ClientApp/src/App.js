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
      site: {
        siteId: null,
        link: ''
      }
    }
  }

  componentDidMount() {
    var url = window.location.href;
    url = url.split("/");
    url = url[3];

    if (url) {
      siteService.findByLink(url)
      .then(response => {
        if (response.status != 204) {
          this.setState({
            site: {
              siteId: response.data.siteId,
              link: response.data.link
            }
          })
        }
      })
      .catch(error => {
        console.log(error);
      });
    }
  }

  render() {
    if (this.state.site.siteId === null) {
      return null;
    }

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
              <AddIdea {...props} siteId={this.state.site} />
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
