import React, { useState } from 'react'
import axios from 'axios';
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button'

const Test = () => {
  const [file, setFile] = useState();
  const [fillName, setFileName] = useState();

  const handleChange = (e) => {
    console.log(e.target.files[0]);
    setFile(e.target.files[0]);
    setFileName(e.target.files[0].name);
  };

  const uploadFile = async (e) => {
    e.preventDefault();
    const url = 'https://localhost:5001/api/test';
    const formData = new FormData();
    formData.append("formFile", file);
    formData.append("fileName", fillName);
    const config = {
      headers: {
        'content-type': 'multipart/form-data'
      }
    }

    const res = await axios.post(url, formData, config);
    console.log(res);
  };

  return (
    <div>
      <Form onSubmit={uploadFile} method="post" encType="multipart/form-data">
        <Form.Group>
          <Form.Label>Attach files</Form.Label>
          <Form.File
            id="custom-file"
            label="File input"
            name="files"
            custom
            onChange={handleChange}
          />
        </Form.Group>
        <Button variant="primary" type="submit">
          Submit
        </Button>
      </Form>
    </div>
  );
};

export default Test;
