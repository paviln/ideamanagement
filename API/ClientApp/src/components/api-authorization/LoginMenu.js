import React, { Component, Fragment } from 'react';
import { Nav, NavDropdown } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap'
import authService from './AuthorizeService';
import { ApplicationPaths } from './ApiAuthorizationConstants';

export class LoginMenu extends Component {
  constructor(props) {
    super(props);

    this.state = {
      isAuthenticated: false,
      userName: null
    };
  }

  componentDidMount() {
    this._subscription = authService.subscribe(() => this.populateState());
    this.populateState();
  }

  componentWillUnmount() {
    authService.unsubscribe(this._subscription);
  }

  async populateState() {
    const [isAuthenticated, user] = await Promise.all([authService.isAuthenticated(), authService.getUser()])
    this.setState({
      isAuthenticated,
      userName: user && user.name
    });
  }

  render() {
    const { isAuthenticated, userName } = this.state;
    if (!isAuthenticated) {
      const registerPath = `${ApplicationPaths.Register}`;
      const loginPath = `${ApplicationPaths.Login}`;
      return this.anonymousView(registerPath, loginPath);
    } else {
      const profilePath = `${ApplicationPaths.Profile}`;
      const logoutPath = { pathname: `${ApplicationPaths.LogOut}`, state: { local: true } };
      return this.authenticatedView(userName, profilePath, logoutPath);
    }
  }

  authenticatedView(userName, profilePath, logoutPath) {
    const prefix = this.props.prefix;

    return (<Fragment>
      <NavDropdown title="Manager" id="basic-nav-dropdown">
        <LinkContainer to={prefix + "/newideas"}>
          <NavDropdown.Item>NewIdeas</NavDropdown.Item>
        </LinkContainer>
        <LinkContainer to={prefix + "/implemented"}>
          <NavDropdown.Item>Implemented</NavDropdown.Item>
        </LinkContainer>
        <LinkContainer to={prefix + "/implemented2"}>
          <NavDropdown.Item>Implemented2</NavDropdown.Item>
        </LinkContainer>
        <LinkContainer to={prefix + "/underimplementation"}>
          <NavDropdown.Item>Underimplementation</NavDropdown.Item>
        </LinkContainer>
        <LinkContainer to={prefix + "/underview"}>
          <NavDropdown.Item>Underview</NavDropdown.Item>
        </LinkContainer>
        <LinkContainer to={prefix + "/underview2"}>
          <NavDropdown.Item>Underview2</NavDropdown.Item>
        </LinkContainer>
        <NavDropdown.Divider />
        <LinkContainer to={profilePath}>
          <NavDropdown.Item>Account</NavDropdown.Item>
        </LinkContainer>
      </NavDropdown>
      <LinkContainer to={logoutPath}>
        <Nav.Link>Logout</Nav.Link>
      </LinkContainer>
    </Fragment>);
  }

  anonymousView(registerPath, loginPath) {
    return (<Fragment>
      <LinkContainer to={loginPath}>
        <Nav.Link>Manager Login</Nav.Link>
      </LinkContainer>
    </Fragment>);
  }
}
