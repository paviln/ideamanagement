import React, { Component } from 'react'
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button'
import Row from 'react-bootstrap/Row'
import Col from 'react-bootstrap/Col'
import ListGroup from 'react-bootstrap/ListGroup';
import validator from 'validator';

import IdeaService from '../services/IdeaService'

export default class AddIdea extends Component {
  constructor(props) {
    super(props);
    this.state = {
      input: {
        hastag: ''
      },
      idea: {
        title:  '',
        description: '',
        effort: '1',
        impact: '1',
        employeeNumber: '',
        hashtags: [],
        files: []
      },
      validated: false
    };

    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
    this.addHashtag = this.addHashtag.bind(this);
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

  handleSubmit = (event) => {
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
    fileData.append('employeeNumber', idea['employeeNumber']);
    fileData.append('siteId', this.props.siteId);

    IdeaService.create(fileData)
    .then(responce => {
      const idea = {};

      idea["title"] = "";
      idea["description"] = "";
      idea["effort"] = "1";
      idea["impact"] = "1";
      idea["employeeNumber"] = "";
      idea["hashtags"] = [];
      idea["files"] = [];

      this.setState({
        idea: idea,
        validated: false
      });
    })
    .catch(error => {
      console.log(error.response.status);
    });
  }

  handleChangeHashtag(event) {
    this.setState({
      input: {
        file: event.target.value
      }
    });
  }

  addHashtag(event) {
    const idea = this.state.idea;
    idea.hashtags.push(this.state.hashtag);
    this.setState({
      idea: idea
    });
    console.log(this.state.idea);
  }

  render() {
    var filesList = [];
    for (let i = 0; i < this.state.idea.files.length; i++) {
      filesList.push(<li>{this.state.idea.files[i].name}</li>);
    }

    var hashtagsList = [];
    for (let i = 0; i < this.state.idea.hashtags.length; i++) {
      hashtagsList.push(<Button variant="secondary">{this.state.idea.hashtags[i]}</Button>);
    }

    return (
      <div>
        <h3 className="pt-4">Create new Idea</h3>
        <Form className="pt-4" id="ideaform" onSubmit={this.handleSubmit}>
          <Form.Row>
            <Form.Group controlId="formEmployee" as={Col}>
              <Form.Label>Employee number</Form.Label>
              <Form.Control 
                required
                minLength="5"
                pattern="\d*"
                name="employeeNumber" 
                type="text" 
                value={this.state.idea["employeeNumber"]} 
                onChange={this.handleChange} />
              <Form.Text className="text-muted">
                Minimum 5 digits
              </Form.Text>
            </Form.Group>
            <Form.Group controlId="formTitle" as={Col}>
              <Form.Label>Title</Form.Label>
              <Form.Control 
                required
                minLength="5"
                name="title" 
                type="text" 
                value={this.state.idea["title"]} 
                onChange={this.handleChange} 
                />
              <Form.Text className="text-muted">
                Minimum 5 characters
              </Form.Text>
            </Form.Group>
          </Form.Row>
          <Form.Group controlId="formDesciption">
            <Form.Label>Description</Form.Label>
            <Form.Control 
              required
              minLength="25"
              name="description" 
              as="textarea" rows={3} 
              value={this.state.idea["description"]} 
              onChange={this.handleChange} />
            <Form.Text className="text-muted">
              Minimum 20 characters
            </Form.Text>
          </Form.Group>
          <Form.Row>
            <Form.Group controlId="formEffort" as={Col}>
              <Form.Label>Estimated effort</Form.Label>
              <Form.Control 
                required
                name="effort" 
                as="select" 
                value={this.state.idea["effort"]} 
                onChange={this.handleChange}>
                <option value="1">1</option>
                <option value="2">2</option>
                <option value="3">3</option>
                <option value="4">4</option>
                <option value="5">5</option>
              </Form.Control>
            </Form.Group>
            <Form.Group controlId="formImpact" as={Col}>
              <Form.Label>Estimated impact</Form.Label>
              <Form.Control 
                required
                name="impact" 
                as="select" 
                value={this.state.idea["impact"]} 
                onChange={this.handleChange}>
                <option value="1">1</option>
                <option value="2">2</option>
                <option value="3">3</option>
                <option value="4">4</option>
                <option value="5">5</option>
              </Form.Control>
            </Form.Group>
          </Form.Row>
          <Form.Group controlId="formFiles">
            <Form.Label>Attach files</Form.Label>
            <Form.File 
              id="custom-file"
              label="File input"
              name="files"
              custom
              multiple
              onChange={this.handleChange}
            />
            <Form.Text className="text-muted">
            <ul className="pt-1">
              {filesList}
            </ul>
            </Form.Text>
          </Form.Group>
          <ListGroup>
          </ListGroup>
          <Form.Row>
            <Form.Group controlId="formHashtagsInput" as={Col}>
              <Form.Label>Hashtags</Form.Label>
              <div className="form-inline">
                <Form.Control 
                  name="hashtag" 
                  type="text" 
                  onChange={this.handleChange} />
                <button className="btn btn-secondary ml-2" onClick={this.addHashtag}>Add</button>
              </div>
            </Form.Group>
            <Form.Group controlId="formHashtagsButton" as={Col}>
            </Form.Group>
          </Form.Row>
          <Form.Group>
            {hashtagsList}
          </Form.Group>
          <Button variant="primary" type="submit">
            Submit
          </Button>
        </Form>
      </div>
    )
  }
}
