import React, { useState, useContext } from "react";
import { UserContext } from './UserProvider';
import './App.css';
import { Fragment } from 'react';
import { addProject } from './Data';

function ProjectForm(props) {
    const { username } = useContext(UserContext);

    const [subactivity, setSubactivity] = useState('');
    const [inputField , setInputField] = useState(
        props.project || 
    {
        code: '',
        manager: username,
        name: '',
        budget: 0,
        active: true,
        subactivities: []
    });

    var editForm = false;
    if (props.project)
        editForm = true;
  
    function handleAddSubactivity(e) {
        if (subactivity === '') {
            alert('Subactivity name can not be empty'); 
            return;       
        }
        
        let newSubactivities = inputField.subactivities.slice();
        newSubactivities.push(subactivity);

        setInputField((prevState) => ({
            ...prevState,
            subactivities: newSubactivities,
        }));
        setSubactivity('');
    };

    function handleDeleteSubactivity(index, e) {
        let newSubactivities = inputField.subactivities.slice();
        newSubactivities.splice(index, 1);

        setInputField((prevState) => ({
            ...prevState,
            subactivities: newSubactivities,
        }));
    }

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
            addProject(inputField);
        }
        
    };

    return (
        <div className="Form">
            <label>Code: </label>
            <input 
            name="code" 
            type="text" 
            onChange={handleChange} 
            placeholder="Code" 
            value={inputField.code}/>

            <label>Name: </label>
            <input 
            name="name" 
            type="text" 
            onChange={handleChange} 
            placeholder="Name" 
            value={inputField.name}/>

            <label>Budget: </label>
            <input 
            name="budget" 
            type="number" 
            onChange={handleChange} 
            placeholder="Budget" 
            value={inputField.budget}/>

            <label>Subactivity: </label>
            <input 
            name="subactivity" 
            type="text" 
            onChange={e => setSubactivity(e.target.value)}
            placeholder="Subactivity" 
            value={subactivity}/>

            <br/>
            <button onClick={handleAddSubactivity}>Add subactivity</button>
            
            {inputField.subactivities.map((name, index) => 
                <Fragment>
                    <br/>
                    <div>
                        {name} 
                        <button onClick={e => handleDeleteSubactivity(index, e)}>-</button>
                    </div>
                </Fragment>)
            }

            <br/>

            <button onClick={handleSubmit}>Submit</button>
        </div>
    );
};

export default ProjectForm;