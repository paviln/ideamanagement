import React, { Component, Fragment } from 'react';
import { Nav, NavDropdown } from 'react-bootstrap';
import { Link } from 'react-router-dom';
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
                <NavDropdown.Item as={Link} to={prefix+"/newideas"}>NewIdeas</NavDropdown.Item>
                <NavDropdown.Item as={Link} to={prefix + "/implemented"}>Implemented</NavDropdown.Item>
                <NavDropdown.Item as={Link} to={prefix + "/implemented2"}>Implemented2</NavDropdown.Item>
                <NavDropdown.Item as={Link} to={prefix + "/ideapage"}>Ideapage</NavDropdown.Item>
                <NavDropdown.Item as={Link} to={prefix + "/underimplementation"}>Underimplementation</NavDropdown.Item>
                <NavDropdown.Item as={Link} to={prefix + "/underview"}>Underview</NavDropdown.Item>
                <NavDropdown.Divider />
                <NavDropdown.Item as={Link} to={profilePath}>Account</NavDropdown.Item>
            </NavDropdown>
            <Nav.Link as={Link} to={logoutPath}>Logout</Nav.Link>
        </Fragment>);

    }

    anonymousView(registerPath, loginPath) {
        return (<Fragment>
            <Nav.Link as={Link} to={loginPath}>Manager Login</Nav.Link>
        </Fragment>);
    }
}
