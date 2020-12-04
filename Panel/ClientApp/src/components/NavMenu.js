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

    return (
      <header>
        <Navbar collapseOnSelect expand="lg" bg="dark" variant="dark">
          <Container>
            <LinkContainer to="/">
              <Navbar.Brand>Panel</Navbar.Brand>
            </LinkContainer>
            <Navbar.Toggle aria-controls="responsive-navbar-nav" />
            <Navbar.Collapse id="responsive-navbar-nav">
              <Nav className="ml-auto">
                <LinkContainer to="/">
                 <Nav.Link>Idea</Nav.Link>
                </LinkContainer>
                <LinkContainer to="/">
                  <Nav.Link>The overview</Nav.Link>
                </LinkContainer>
                <LinkContainer to="/">
                  <Nav.Link>Browse ideas</Nav.Link>
                </LinkContainer>
                <LoginMenu></LoginMenu>
              </Nav>
            </Navbar.Collapse>
          </Container>
        </Navbar>
      </header>
    );
  }
}
