import React, { useState }from 'react'
import axios from 'axios';

const Test = () => {
    const [file, setFile] = useState();
    const [fillName, setFileName] = useState();

    const SaveFile = (e) => {
        console.log(e.target.files[0]);
        setFile(e.target.files[0]);
        setFileName(e.target.files[0].name);
    };

    const uploadFile = async (e) => {
        const formData = new FormData();
        formData.append("formFile", file);
        formData.append("fileName", fillName);

        try {
            const res = await axios.post("https://localhost:5001/api/test", formData);
            console.log(res);
        } catch (error) {
            console.log(error);
        }
    };

    return (
        <div>
            <input type="file" onChange={SaveFile} />
            <input type="button" value="upload" onClick={uploadFile} />
        </div>
    );
};

export default Test;
