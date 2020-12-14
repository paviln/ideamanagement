import React, { Component } from 'react';
import { Redirect, Route, Switch } from 'react-router-dom';
import { Layout } from './components/Layout';
import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants';
import siteService from './services/SiteService';
import AddIdea from './components/AddIdea';
import NoMatch from './components/NoMatch';
import authService from './components/api-authorization/AuthorizeService';
import userService from './services/UserService';
import NewIdeas from './components/NewIdeas';
import Implemented from './components/Implemented';
import Implemented2 from './components/Implemented2';
import IdeaPage from './components/IdeaPage';
import UnderView from './components/UnderView';
import UnderView2 from './components/UnderView2';
import UnderImplementation from './components/UnderImplementation';
import Overview from './components/Overview';
import Browse from './components/Browse';
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
    if (this.state.authenticated == false) {
      const isAuthenticated = await authService.isAuthenticated();
      const user = await authService.getUser();

      if (isAuthenticated) {
        userService.getSite()
          .then(response => {
            this.setState({
              site: {
                siteId: response.data.siteId,
                link: response.data.link
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
  }

  async populateState() {
    this.getSite();
    this.authSite();
  }

  componentDidMount() {
    this.populateState();
  }

  render() {
    if (this.state.ready) {
      if (this.getLink() != this.state.site.link) {
        window.location.replace('https://localhost:5001/' + this.state.site.link);
        return null;
      }
      const prefix = '/' + this.state.site.link;
      return (
        <Layout prefix={prefix}>
          <Switch>
            <Route exact path={prefix}>
              <Redirect to={prefix + "/idea"} />
            </Route>
            <Route
              exact path={prefix + "/idea"}
              render={props => (
                <AddIdea {...props}
                  siteId={this.state.site.siteId}
                />
              )}
            />
            <Route
              exact path={prefix + "/overview"}
              render={props => (
                <Overview {...props}
                  authenticated={this.authenticated}
                  siteId={this.state.site.siteId}
                  prefix={prefix}
                />
              )}
            />
            <Route path={prefix + "/overview/:id"} children={<IdeaPage />} />
            <Route
              exact path={prefix + "/browse"}
              render={props => (
                <Browse {...props}
                  siteId={this.state.site.siteId}
                />
              )}
            />
            <AuthorizeRoute exact path={prefix + "/newideas"} component={NewIdeas} />
            <AuthorizeRoute exact path={prefix + "/implemented"} component={Implemented} />
            <AuthorizeRoute exact path={prefix + "/implemented2"} component={Implemented2} />
            <AuthorizeRoute exact path={prefix + "/ideapage"} component={IdeaPage} />
            <AuthorizeRoute exact path={prefix + "/underimplementation"} component={UnderImplementation} />
            <AuthorizeRoute exact path={prefix + "/underview"} component={UnderView} />
            <AuthorizeRoute exact path={prefix + "/underview2"} component={UnderView2} />
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
