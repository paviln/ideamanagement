import React from 'react';
import { IconContext } from "react-icons";
import { HiOutlineDocumentDownload } from "react-icons/hi";
import ideaService from '../services/IdeaService';
import saveAs from 'file-saver';

function Files(props) {

  const populateFiles = (files) => {
    const list = [];

    if (files !== null) {
      for (let i = 0; i < files.length; i++) {
        list.push(
          <li className="pt-2">
            <a className="btn" onClick={() => downloadFile(files[i])}>
              <i className="pr-2">
                <IconContext.Provider value={{ color: "black", size: "1.2em" }}>
                  <HiOutlineDocumentDownload />
                </IconContext.Provider>
              </i>
              {files[i].name}</a>
          </li>
        );
      }
    }

    return list;
  }

  const downloadFile = (file) => {
    ideaService.getIdeaFileData(file.fileId)
      .then( response => {
        if (response.status == '200') {
          saveAs(response.data, file.name);
        }
      })
      .catch(error => {
        console.log(error);
      });
  }

  var list = populateFiles(props.files);

  if (list.length > 0) {
    return (
      <div>
        <p className="pt-4">Files</p>
        <ul className="list-unstyled m-0">
          {list}
        </ul>
      </div>
    );
  }

  return null;

}

export default Files
