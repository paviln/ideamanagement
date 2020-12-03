import React, { Component } from 'react'
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button'
import Col from 'react-bootstrap/Col'

import IdeaService from '../services/IdeaService'

export default class AddIdea extends Component {
  constructor(props) {
    super(props);
    this.state = {
      idea: {
        title: '',
        description: '',
        effort: '1',
        impact: '1',
        files: []
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
    const idea = this.state.idea;

    const target = event.target;
    const name = target.name;

    if (name === "files" ) {
      idea[name] = target.files;
    } else {
      idea[name] = target.value;
    }

    this.setState(idea);
  }

  handleSubmit(event) {
    event.preventDefault();

    const idea = this.state.idea;


    var fileData = new FormData();
    if (idea.files.length > 0) {
      for (let i = 0; i < idea.files.length; i++) {
        fileData.append('files', idea.files[i]);
      }
    }

    fileData.append('title', idea['title']);
    fileData.append('description', idea['description']);
    fileData.append('effort', idea['effort']);
    fileData.append('impact', idea['impact']);
    fileData.append('siteId', this.props.sideId);

    if (this.validate(idea)) {
      IdeaService.create(fileData)
      .then(responce => {
        const idea = {};
  
        idea["title"] = "";
        idea["description"] = "";
        idea["effort"] = "1";
        idea["impact"] = "1";

        this.setState({idea: idea});
      })
      .catch(error => {
        console.log(error.response.status);
      })
    }
  }

  validate(idea) {
    var isValid = true;
    let errors = this.state.errors;

    if (idea["title"].length < 5) {
      errors["title"] = true;
      isValid = false;
    }
    else {
      errors["title"] = false;
    }
    if (idea["description"].length <= 20) {
      errors["description"] = true;
      isValid = false;
    }
    else {
      errors["description"] = false;
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
            <Form.Control className={this.state.errors["title"] ? 'is-invalid' : ''} name="title" type="text" value={this.state.idea["title"]} onChange={this.handleChange} />
            <Form.Text className="text-muted">
              Minimum 5 characters
            </Form.Text>
          </Form.Group>
          <Form.Group controlId="formDesciption">
            <Form.Label>Description</Form.Label>
            <Form.Control className={this.state.errors["description"] ? 'is-invalid' : ''} name="description" as="textarea" rows={3} value={this.state.idea["description"]} onChange={this.handleChange} />
            <Form.Text className="text-muted">
              Minimum 20 characters
            </Form.Text>
          </Form.Group>
          <Form.Row>
            <Form.Group controlId="formEffort" as={Col}>
              <Form.Label>Estimated effort</Form.Label>
              <Form.Control name="effort" as="select" value={this.state.idea["effort"]} onChange={this.handleChange}>
                <option value="1">1</option>
                <option value="2">2</option>
                <option value="3">3</option>
                <option value="4">4</option>
                <option value="5">5</option>
              </Form.Control>
            </Form.Group>
            <Form.Group controlId="formImpact" as={Col}>
              <Form.Label>Estimated impact</Form.Label>
              <Form.Control name="impact" as="select" value={this.state.idea["impact"]} onChange={this.handleChange}>
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
              name="files"
              custom
              multiple
              onChange={this.handleChange}
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
