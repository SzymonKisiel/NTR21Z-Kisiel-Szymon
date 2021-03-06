import React, { useState, useEffect, useContext } from "react";
import { addActivity, editActivity, getSubactivities } from "./Data";
import { UserContext } from "./UserProvider";
import './App.css';

function ActivityForm(props) {
    const { username } = useContext(UserContext);
    // const month = props.month;
    const oldActivity = props.activity;
    const code = props.code || oldActivity.code;

    const defaultDay = new Date().toISOString().slice(0, 10);

    const [subactivities, setSubactivities] = useState([]);
    const [inputField , setInputField] = useState(
        oldActivity || 
        {
            date: defaultDay,
            code: code,
            subcode: '',
            time: 0,
            description: ''
        }
    );

    let editForm = false;
    if (props.activity)
        editForm = true;

    useEffect(() => {
        const fetchData = async () => {
            const result = await getSubactivities(code);
            setSubactivities(result.data);
        };
        fetchData();
    }, [code]);

    function handleChange(e) {
        const { name, value } = e.target;
        setInputField((prevState) => ({
            ...prevState,
            [name]: value,
        }));
    };

    function handleSubmit(e) {
        if (editForm) {
            editActivity(username, oldActivity, inputField);
            alert("Edit:\n" + JSON.stringify(inputField));
        }
        else {
            addActivity(username, inputField);
            alert("Create:\n" + JSON.stringify(inputField));
        }
        
    };

    return (
        <div className="Form">
            <label>Date: </label>
            <input 
            name="date" 
            type="date" 
            onChange={handleChange} 
            placeholder="Date" 
            value={inputField.date}/>

            <label>Subactivity: </label>
            <select name="subcode" value={inputField.subcode} onChange={handleChange} >
                <option value="">-</option>
                {subactivities.map(subactivity => <option key={subactivity} >{subactivity}</option>)}
            </select>

            <label>Time: </label>
            <input 
            name="time" 
            type="number" 
            onChange={handleChange} 
            placeholder="Time" 
            value={inputField.time}/>

            <label>Description: </label>
            <textarea 
            name="description" 
            type="textarea" 
            onChange={handleChange} 
            placeholder="Description" 
            value={inputField.description}/>

            <br/>

            <button onClick={handleSubmit}>Submit</button>
        </div>
    );
};

export default ActivityForm;