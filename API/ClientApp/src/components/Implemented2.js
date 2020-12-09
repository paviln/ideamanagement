import React,{Component, useState} from 'react';
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button';
import InputGroup from 'react-bootstrap/InputGroup';
import FormControl from 'react-bootstrap/FormControl';
// this page is shown when each implemented task is clicked
export default class Implemented extends Component {

    render () {  
         return (
             <div>
                 <h1>Challenegs and Resluts Input</h1>
                 <br/>
                 <form>
                <InputGroup className="mb-3"><span class="border border-primary"></span>
                <FormControl
                placeholder=" Challenges"
                aria-label="estimate cost"
                aria-describedby="basic-addon2"/>
                <InputGroup.Append>
                <button class="btn btn-primary pull-right badge-pill" type="button">Add</button>
                </InputGroup.Append>
                </InputGroup>

                <InputGroup className="mb-3"><span class="border border-primary"></span>
                <FormControl
                placeholder=" Results"
                aria-label="add task"
                aria-describedby="basic-addon2"/>
                <InputGroup.Append>
                <button class="btn btn-primary pull-right badge-pill" type="button">Add</button>
                </InputGroup.Append>
                </InputGroup>
                </form>
             </div>
         )
    }
}