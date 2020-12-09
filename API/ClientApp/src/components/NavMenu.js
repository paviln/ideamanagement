import React, { Component } from 'react';
import { Container, Navbar, Nav } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap'

import { LoginMenu } from './api-authorization/LoginMenu';

import './NavMenu.css';

export class NavMenu extends Component {
  constructor (props) {
    super(props);
  }

  render () {
    const prefix = this.props.prefix;

    return (
      <header>
        <Navbar collapseOnSelect expand="lg" bg="dark" variant="dark">
          <Container>
            <LinkContainer to={prefix + "/idea"}>
              <Navbar.Brand active={false}>IdeaManagement</Navbar.Brand>
            </LinkContainer>
            <Navbar.Toggle aria-controls="responsive-navbar-nav" />
            <Navbar.Collapse id="responsive-navbar-nav">
              <Nav className="ml-auto">
                <LinkContainer to={prefix + "/idea"}>
                 <Nav.Link active={false}>Idea</Nav.Link>
                </LinkContainer>
                <LinkContainer to={prefix + "/overview"}>
                  <Nav.Link active={false}>The overview</Nav.Link>
                </LinkContainer>
                <LinkContainer to={prefix + "/browse"}>
                  <Nav.Link active={false}>Browse ideas</Nav.Link>
                </LinkContainer>
                <LoginMenu prefix={prefix}></LoginMenu>
              </Nav>
            </Navbar.Collapse>
          </Container>
        </Navbar>
      </header>
    );
  }
}
