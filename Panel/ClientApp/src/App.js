import React, { Component } from 'react';
import { Redirect, Route, Switch } from 'react-router-dom';
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

  getLink() {
    var url = window.location.href;
    url = url.split("/");
    url = url[3];

    return url;
  }

  async getSite() {
    var url = this.getLink();

    if (url) {
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
    const isAuthenticated = await authService.isAuthenticated();

    if (isAuthenticated) {
      authService.getUser()
      .then(response => {
        this.setState({
          site: {
            siteId: 1,
            link: 'linak'
          },
          authenticated: true,
          ready: true
        });
      })
      .catch(error => {
        console.log(error);
      });
    } 
  }

  async populateState() {
    this.getSite();
    this.authSite();
  }

  componentDidMount() {
    this.populateState();
  }

  render () {
    if (this.state.ready) {
      if (this.getLink() != this.state.site.link) {
        window.location.replace('https://localhost:5001/' + this.state.site.link);
        return null;
      }

      const prefix = '/' + this.state.site.link;
      return (
        <Layout>
          <Switch>
            <Route exact path={prefix} component={AddIdea} />
            <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />
            <Route path="*">
              <NoMatch></NoMatch>
            </Route>
          </Switch>
        </Layout>
      );
    }
    return (
      <Switch>
        <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />
      </Switch>
    );
  }
}
