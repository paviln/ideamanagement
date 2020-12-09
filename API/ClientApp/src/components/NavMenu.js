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
            <LinkContainer to={prefix}>
              <Navbar.Brand>IdeaManagement</Navbar.Brand>
            </LinkContainer>
            <Navbar.Toggle aria-controls="responsive-navbar-nav" />
            <Navbar.Collapse id="responsive-navbar-nav">
              <Nav className="ml-auto">
                <LinkContainer to={prefix}>
                 <Nav.Link>Idea</Nav.Link>
                </LinkContainer>
                <LinkContainer to={prefix + "/newideas"}>
                 <Nav.Link>NewIdeas</Nav.Link>
                </LinkContainer>
                <LinkContainer to={prefix + "/implemented"}>
                 <Nav.Link>implemented</Nav.Link>
                 </LinkContainer>
                <LinkContainer to={prefix + "/implemented2"}>
                 <Nav.Link>implemented2</Nav.Link>
                </LinkContainer>
                <LinkContainer to={prefix + "/managerview"}>
                 <Nav.Link>managerview</Nav.Link>
                </LinkContainer>
                <LinkContainer to={prefix + "/ideapage"}>
                 <Nav.Link>ideapage</Nav.Link>
                </LinkContainer>
                <LinkContainer to={prefix + "/underimplementation"}>
                 <Nav.Link>underimplementation</Nav.Link>
                </LinkContainer>
                <LinkContainer to={prefix + "/underview"}>
                 <Nav.Link>underview</Nav.Link>
                </LinkContainer>
                <LinkContainer to={prefix + "/underview2"}>
                 <Nav.Link>underview2</Nav.Link>
                </LinkContainer>
                <LinkContainer to={prefix}>
                  <Nav.Link>The overview</Nav.Link>
                </LinkContainer>
                <LinkContainer to={prefix}>
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
