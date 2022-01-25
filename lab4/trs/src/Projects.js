import React from 'react';
import { getProjects } from './Data';
import ProjectsContent from './ProjectsContent';
import { useNavigate } from 'react-router-dom';

function Projects() {
    let navigate = useNavigate();
    let projects = getProjects();

    function addProject() {
        navigate("/projects/add");
    };

    return (
        <div>
            <h1 className="Title">Projects</h1>
            <ProjectsContent projects={projects} />
            <input type="button" onClick={addProject} value="Add project" />
        </div>
    );
};

export default Projects;