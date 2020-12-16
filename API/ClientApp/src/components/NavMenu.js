import React, { Component } from 'react';
import { Container, Navbar, Nav } from 'react-bootstrap';
import { LinkContainer, IndexLinkContainer } from 'react-router-bootstrap'

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
        <Navbar fixed="top" collapseOnSelect expand="lg" bg="dark" variant="dark">
          <Container>
            <IndexLinkContainer to={prefix}>
              <Navbar.Brand>IdeaManagement</Navbar.Brand>
            </IndexLinkContainer>
            <Navbar.Toggle aria-controls="responsive-navbar-nav" />
            <Navbar.Collapse id="responsive-navbar-nav">
              <Nav className="ml-auto">
                <IndexLinkContainer to={prefix}>
                 <Nav.Link>Create idea</Nav.Link>
                </IndexLinkContainer>
                <LinkContainer to={prefix + "/overview"}>
                  <Nav.Link>The overview</Nav.Link>
                </LinkContainer>
                <LinkContainer to={prefix + "/browse"}>
                  <Nav.Link>Browse ideas</Nav.Link>
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
