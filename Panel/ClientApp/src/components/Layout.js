import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu';

export class Layout extends Component {
  constructor (props) {
    super(props);
  }

  render () {
    return (
      <div>
        <NavMenu prefix={this.props.prefix}/>
        <Container>
          {this.props.children}
        </Container>
      </div>
    );
  }
}
