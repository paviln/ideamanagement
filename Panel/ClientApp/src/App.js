import React, { Component } from 'react';
import { Route, Switch } from 'react-router-dom';
import { Layout } from './components/Layout';

import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants';
import authService from './components/api-authorization/AuthorizeService';
import SiteService from './services/SiteService';
import AddIdea from './components/AddIdea';
import NoMatch from './components/NoMatch';
import Test from './components/Test';
import Manager from './components/Manager';

import './App.scss';

export default class App extends Component {
  
  constructor(props) {
    super(props);

    this.state = {
      ready: false,
      link: "",
      authenticated: false,
    }
  }

  componentDidMount() {
    this.populateState();
  }

  async getLink() {
    var url = window.location.href;
    url = url.split("/");
    url = url[3];

    var link = "";
    if (url && url !== "authentication") {
      link = await SiteService.findByLink(url).then(result => {
        return result.data.link;
      });
    } else if (url === "authentication") {
      return ("authentication");
    }
    return link;
  }

  async populateState() {
    const [auth, link] = await Promise.all([authService.isAuthenticated(), this.getLink()]);
    
    this.setState({
      authenticated: auth,
      link: link,
      ready: true
    });
  }

  render() {
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
          <Route exact path={prefix} component={AddIdea} />
          <Route path={prefix + '/test'} component={Test} />
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
