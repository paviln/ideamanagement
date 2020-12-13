import React from 'react'

function Hashtags(props) {

  const populateHashtags = (hashtags) => {
    var list = [];

    if (hashtags !== null) {
      for (let i = 0; i < hashtags.length; i++) {
        list.push(
          <p className="pt-2">#{hashtags[i].name}</p>
        );
      }
    }

    return list;
  }

  var list = populateHashtags(props.hashtags);

  if (list.length > 0) {

    return (
      <div>
        <p className="pt-4">Hashtags</p>
        {list}
      </div>
    );
  }

  return null;
}

export default Hashtags
