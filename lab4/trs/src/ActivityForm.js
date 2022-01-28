import React, { useState, useEffect, useContext } from "react";
import { addActivity, editActivity, getSubactivities } from "./Data";
import { UserContext } from "./UserProvider";

function ActivityForm(props) {
    const { username } = useContext(UserContext);
    const month = props.month;
    const code = props.code;
    const oldActivity = props.activity;

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
        <div>
            <input 
            name="date" 
            type="date" 
            onChange={handleChange} 
            placeholder="Date" 
            value={inputField.date}/>

            <br/>

            {/* <input 
            name="subcode" 
            type="text" 
            onChange={handleChange} 
            placeholder="Subactivity" 
            value={inputField.subcode}/> */}
            <select value={inputField.subactivity}>
                {subactivities.map(subactivity => <option key={subactivity}>{subactivity}</option>)}
            </select>

            <br/>

            <input 
            name="time" 
            type="number" 
            onChange={handleChange} 
            placeholder="Time" 
            value={inputField.time}/>

            <br/>

            {/* <input 
            name="description" 
            type="textarea" 
            onChange={handleChange} 
            placeholder="Description" 
            value={inputField.description}/> */}
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