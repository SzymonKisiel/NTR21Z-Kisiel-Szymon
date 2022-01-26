import React, { useState } from "react";

function ActivityForm(props) {
    const month = props.month;
    const code = props.code;

    const [inputField , setInputField] = useState(
        props.activity || 
        {
            date: '',
            code: code,
            subcode: '',
            time: 0,
            description: true
        }
    );

    let editForm = false;
    if (props.activity)
        editForm = true;

    function handleChange(e) {
        const { name, value } = e.target;
        setInputField((prevState) => ({
            ...prevState,
            [name]: value,
        }));
    };

    function handleSubmit(e) {
        if (editForm) {
            alert("Edit:\n" + JSON.stringify(inputField));
        }
        else {
            alert("Create:\n" + JSON.stringify(inputField));
        }
        
    };

    return (
        <div>
            <input 
            name="date" 
            type="date" 
            onChange={handleChange} 
            placeholder="Date" 
            value={inputField.date}/>

            <br/>

            <input 
            name="subcode" 
            type="text" 
            onChange={handleChange} 
            placeholder="Subactivity" 
            value={inputField.subcode}/>

            <br/>

            <input 
            name="time" 
            type="number" 
            onChange={handleChange} 
            placeholder="Time" 
            value={inputField.time}/>

            <br/>

            <input 
            name="description" 
            type="textbox" 
            onChange={handleChange} 
            placeholder="Description" 
            value={inputField.description}/>

            <br/>

            <button onClick={handleSubmit}>Submit</button>
        </div>
    );
};

export default ActivityForm;