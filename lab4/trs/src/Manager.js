import React from 'react';
import { getProjects } from './Data';
import ProjectsContent from './ProjectsContent';
import { useNavigate } from 'react-router-dom';

function Manager() {
    let navigate = useNavigate();
    let projects = getProjects();

    function addProject() {
        navigate("/logo");
    };

    return (
        <div>
            <h1 className="Title">Manager</h1>
            <ProjectsContent projects={projects} isManager={true} />
            <input type="button" onClick={addProject} value="Add project" />
        </div>
    );
};

export default Manager;