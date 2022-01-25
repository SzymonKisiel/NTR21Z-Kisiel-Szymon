import React, { useState } from "react";

function ProjectForm(props) {
    const [subactivity, setSubactivity] = useState('');
    const [inputField , setInputField] = useState(
        props.project || 
    {
        code: '',
        manager: '',
        name: '',
        budget: 0,
        active: true,
        subactivities: []
    });

    var editForm = false;
    if (props.project)
        editForm = true;

    
    // if (props.project) {
    //     setInputField(props.project);
    //     setInputField({
    //         code: props.project.code,
    //         manager: props.project.manager,
    //         name: props.project.name,
    //         budget: props.project.budget,
    //         active: props.project.active,
    //         subactivities: props.project.subactivities
    //     });
    //     editForm = true;
    // }
  
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
        }
        
    };

    return (
        <div>
            <input 
            name="code" 
            type="text" 
            onChange={handleChange} 
            placeholder="Code" 
            value={inputField.code}/>

            <br/>

            <input 
            name="manager" 
            type="text" 
            onChange={handleChange} 
            placeholder="Manager" 
            value={inputField.manager}/>

            <br/>

            <input 
            name="name" 
            type="text" 
            onChange={handleChange} 
            placeholder="Name" 
            value={inputField.name}/>

            <br/>

            <input 
            name="budget" 
            type="number" 
            onChange={handleChange} 
            placeholder="Budget" 
            value={inputField.budget}/>

            <br/>

            <input 
            name="subactivity" 
            type="text" 
            onChange={e => setSubactivity(e.target.value)}
            placeholder="Subactivity" 
            value={subactivity}/>

            <button onClick={handleAddSubactivity}>Add subactivity</button>

            <br/>
            
            {inputField.subactivities.map((name, index) => 
                <div>
                    {name} 
                    <button onClick={e => handleDeleteSubactivity(index, e)}>-</button>
                </div>)
            }

            <br/>

            <button onClick={handleSubmit}>Submit</button>
        </div>
    );
};

export default ProjectForm;