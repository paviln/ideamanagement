import React,{Component, useState} from 'react';
import Select from 'react-select';

export class NewIdea extends Component {

    render () {
        const data = [
            {
                value: 1,
                name: "New ideas"
            },
            {
                value: 2,
                name: "Under View"
            },
            {
                value: 3,
                name: "Under implementation"
            },
            {
                value: 4,
                name: "Implemented"
            }
        ];
        //get selected value
        const [selectedValue, setSelectedValue] = useState(3);
        const handleChange = obj => {
            setSelectedValue(obj.value);
        }
         return (
          
        <div className="App">
            Manager option Tab<br/>

            <Select
            value={data.find(x => x.value === selectedValue)}
            options={data}
            onChange={handleChange}
            getOptionLabel={option => option.name}
            />
            <br/>
            <b>Selected Value:</b>
            <pre>{JSON.stringify(selectedValue, null, 2)}</pre>
            
        </div>
      
     
         )
    
    }
        

}
