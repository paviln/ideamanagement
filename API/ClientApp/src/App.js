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
import Idea from './components/idea/Idea';
import NewIdeas from './components/NewIdeas';
import Implemented from './components/Implemented';
import UnderImplementation from './components/UnderImplementation';
import Overview from './components/Overview';
import Browse from './components/Browse';
import './App.scss';
import Reviews from './components/review/Reviews';
import Review from './components/review/Review';
import Implement from './components/task/Implement';
import Evaluate from './components/idea/Evaluate';
import TaskList from './components/task/TaskList';


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

  async validateSite() {
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
    
    const isAuthenticated = await authService.isAuthenticated();

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

  async populateState() {
    this.validateSite();
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
            <Route
              exact path={prefix}
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
                  link={this.state.site.link}
                  prefix={prefix}
                />
              )}
            />
            <Route
              exact path={prefix + "/idea/:id"}
              render={props => (
                <Idea  {...props}
                  link={this.state.site.link}
                />
              )}
            />
            <Route
              exact path={prefix + "/browse"}
              render={props => (
                <Browse {...props}
                  siteId={this.state.site.siteId}
                />
              )}
            />
            <AuthorizeRoute exact path={prefix + "/newideas"} component={NewIdeas} />
            <AuthorizeRoute exact path={prefix + "/underreview"} component={Reviews} />
            <AuthorizeRoute exact path={prefix + "/underreview/:id"} component={Review} />
            <AuthorizeRoute exact path={prefix + "/underimplementation"} component={UnderImplementation} />
            <AuthorizeRoute exact path={prefix + "/underimplementation/:id"} component={TaskList} />
            <AuthorizeRoute exact path={prefix + "/underimplementation/:id/:id"} component={Implement} />
            <AuthorizeRoute exact path={prefix + "/implemented"} component={Implemented} />
            <AuthorizeRoute exact path={prefix + "/implemented/:id"} component={Evaluate} />
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
