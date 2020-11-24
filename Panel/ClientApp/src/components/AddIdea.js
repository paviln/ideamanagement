import React, { Component } from 'react'
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button'
import Col from 'react-bootstrap/Col'

import IdeaService from '../services/IdeaService'

export default class AddIdea extends Component {
  constructor(props) {
    super(props);
    this.state = {
      input: {
        title: '',
        description: '',
        effort: '1',
        impact: '1'
      },
      errors: {
        title: false,
        description: false
      }
    };

    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
    this.validateTitle = this.validateTitle.bind(this);
  }

  handleChange(event) {
    const input = this.state.input;
    const target = event.target;
    const value = target.value;
    const name = target.name;

    input[name] = value;

    this.setState({
      input: input 
    });
  }

  handleSubmit(event) {
    event.preventDefault();

    const input = this.state.input;

    const idea = {
      title: input["title"],
      description: input["description"],
      effort: input["effort"],
      impact: input["impact"]
    }

    if (this.validate(idea)) {
      IdeaService.create(idea)
      .then(responce => {
        const input = {};
  
        input["title"] = "";
        input["description"] = "";
        input["effort"] = "1";
        input["impact"] = "1";
  
        this.setState({input: input});
      })
      .catch(error => {
        console.log(error.response.status);
      })
    }
  }

  validate(idea) {
    var isValid = false;
    let errors = this.state.errors;

    if (idea["title"].length <= 5) {
      this.state.errors["title"] = true;
    }
    else {
      errors["title"] = false;
      isValid = true;
    }
    if (idea["description"].length <= 20) {
      errors["description"] = true;
    }
    else {
      errors["description"] = false;
      isValid = true;
    }

    this.setState({errors: errors})

    return isValid;
  }

  validateTitle(event) {

  }

  render() {
    return (
      <div>
        <h3 className="pt-4">Create new Idea</h3>
        <Form onSubmit={this.handleSubmit}>
          <Form.Group controlId="formTitle">
            <Form.Label>Title</Form.Label>
            <Form.Control className={this.state.errors["description"] ? 'is-invalid' : ''} name="title" type="text" value={this.state.input["title"]} onChange={this.handleChange} />
            <Form.Text className="text-muted">
              Minimum 5 characters
            </Form.Text>
          </Form.Group>
          <Form.Group controlId="formDesciption">
            <Form.Label>Description</Form.Label>
            <Form.Control className={this.state.errors["description"] ? 'is-invalid' : ''} name="description" as="textarea" rows={3} value={this.state.input["description"]} onChange={this.handleChange} />
            <Form.Text className="text-muted">
              Minimum 20 characters
            </Form.Text>
          </Form.Group>
          <Form.Row>
            <Form.Group controlId="formEffort" as={Col}>
              <Form.Label>Estimated effort</Form.Label>
              <Form.Control name="effort" as="select" value={this.state.input["effort"]} onChange={this.handleChange}>
                <option value="1">1</option>
                <option value="2">2</option>
                <option value="3">3</option>
                <option value="4">4</option>
                <option value="5">5</option>
              </Form.Control>
            </Form.Group>
            <Form.Group controlId="formImpact" as={Col}>
              <Form.Label>Estimated impact</Form.Label>
              <Form.Control name="impact" as="select" value={this.state.input["impact"]} onChange={this.handleChange}>
                <option value="1">1</option>
                <option value="2">2</option>
                <option value="3">3</option>
                <option value="4">4</option>
                <option value="5">5</option>
              </Form.Control>
            </Form.Group>
          </Form.Row>
          <Form.Group>
            <Form.Label>Attach files</Form.Label>
            <Form.File 
              id="custom-file"
              label="File input"
              custom
              multiple
            />
          </Form.Group>
          <Button variant="primary" type="submit">
            Submit
          </Button>
        </Form>
      </div>
    )
  }
}
