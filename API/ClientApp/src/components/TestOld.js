import React, { Component } from 'react'
import { Route, Switch } from 'react-router-dom'
import authService from './api-authorization/AuthorizeService'

export class Test extends Component {
  constructor(props) {
    super(props);

    this.state = {
      ready: false,
      user: ''
    }
  }

  async getSite() {
    const token = await authService.getAccessToken();
    const response = await fetch('api/ApplicationUser', {
      headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
    });
    const data = await response.json();
    console.log(data);
    this.setState({ user: data, ready: true });
  }

  componentDidMount() {
    this.getSite();
  }

  render() {
    console.log(this.state)
    if (this.props.ready) {
      return (this.props.user);
    }
    return (
      <div>

      </div>
    )
  }
}

export default Test