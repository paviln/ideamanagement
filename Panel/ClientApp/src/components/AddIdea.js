import React, { Component } from 'react'
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button'

import IdeaService from '../services/IdeaService'

export default class AddIdea extends Component {

  state = {
    title: '',
  }

  handleChange = event => {
    this.setState({ 
      title: event.target.value 
    });
  }

  handleSubmit = event => {
    event.preventDefault();

    const idea = {
      title: this.state.title
    }

    IdeaService.create(idea)
      .then(this.setState({ redirect: true }));

    this.setState({
      title: ''
    });
  }

  render() {
    return (
      <div>
        <Form>
          <Form.Group controlId="ideaForm.Title" onSubmit={this.handleSubmit}>
            <Form.Label>Title</Form.Label>
            <Form.Control type="text" />
          </Form.Group>
          <Form.Group controlId="exampleForm.ControlTextarea1">
            <Form.Label>Description</Form.Label>
            <Form.Control as="textarea" rows={3} />
          </Form.Group>
          <Form.Group controlId="exampleForm.ControlSelect1">
            <Form.Label>Estimated effort</Form.Label>
            <Form.Control as="select">
              <option>1</option>
              <option>2</option>
              <option>3</option>
              <option>4</option>
              <option>5</option>
            </Form.Control>
          </Form.Group>
          <Form.Group controlId="exampleForm.ControlSelect1">
            <Form.Label>Estimated impact</Form.Label>
            <Form.Control as="select">
              <option>1</option>
              <option>2</option>
              <option>3</option>
              <option>4</option>
              <option>5</option>
            </Form.Control>
          </Form.Group>
          <Button variant="primary" type="submit">
            Submit
          </Button>
        </Form>
      </div>
    )
  }
}
