import React from 'react';

function Hashtags(props) {

  const populateHashtags = (hashtags) => {
    var list = [];

    if (hashtags !== null) {
      for (let i = 0; i < hashtags.length; i++) {
        list.push(
          <p className="pl-2">#{hashtags[i].name}</p>
        );
      }
    }

    return list;
  }

  var list = populateHashtags(props.hashtags);

  if (list.length > 0) {

    return (
      <div>
        <h5 className="pt-2">Hashtags</h5>
        <div className="d-flex">
          {list}
        </div>
      </div>
    );
  }

  return null;
}

export default Hashtags
