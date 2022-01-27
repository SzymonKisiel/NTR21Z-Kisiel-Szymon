import React, { useState, useContext } from "react";
import { addActivity } from "./Data";
import { UserContext } from "./UserProvider";

function ActivityForm(props) {
    const { username } = useContext(UserContext);
    const month = props.month;
    const code = props.code;

    const [inputField , setInputField] = useState(
        props.activity || 
        {
            date: '',
            code: code,
            subcode: '',
            time: 0,
            description: ''
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
            addActivity(username, inputField);
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