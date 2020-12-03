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
import authService from './components/api-authorization/AuthorizeService';

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

  async getSite() {
    var url = window.location.href;
    url = url.split("/");
    url = url[3];

    if (url == 'authentication') {
      this.setState({
        ready: true
      });
    } else if (url) {
      siteService.findByLink(url)
      .then(response => {
        if (response.status == 200) {
          this.setState({
            site: {
              siteId: response.data.siteId,
              link: response.data.link
            },
            ready: true
          })
        }
      })
      .catch(error => {
        console.log(error);
      });
    }
  }

  async authSite() {
    if (await authService.isAuthenticated == true) {
      const user = await authService.getUser();
    } 
  }

  async populateState() {
    this.getSite();
    //this.authSite();
  }

  componentDidMount() {
    this.populateState();
  }

  render() {
    if (!this.state.ready) {
      return null;
    }

    const prefix = '/' + this.state.site.link;

    if (this.state.authenticated) {
      if (this.state.link !== "linak") {
        window.location.replace("https://localhost:5001/linak");
      }
    }

    return (
      <Layout prefix={prefix}>
        <Switch>
          <Route
            path={prefix}
            render={(props) => (
              <AddIdea {...props} siteId={this.state.site.siteId} />
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
