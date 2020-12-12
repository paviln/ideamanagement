import React from 'react';
import { IconContext } from "react-icons";
import { HiOutlineDocumentDownload } from "react-icons/hi";

function Files(props) {

  const populateFiles = (files) => {
    if (files !== undefined) {
      const list = [];
      for (let i = 0; i < files.length; i++) {
        list.push(
          <li className="pt-2">
            <a className="text-decoration-none" href="">
              <i className="pr-2">
                <IconContext.Provider value={{ color: "black", size: "1.2em" }}>
                  <HiOutlineDocumentDownload />
                </IconContext.Provider>
              </i>
              {files[i].name}</a>
          </li>
        );
      }

      return list;
    }
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
