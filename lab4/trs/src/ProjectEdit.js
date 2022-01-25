import React from 'react';
import { getProjects } from './Data';
import { useParams } from 'react-router-dom';
import ProjectForm from './ProjectForm';


function ProjectEdit(props) {
    let projects = getProjects();
    let params = useParams();

    let code = props.code || params.code;
    let project = projects.find(p => p.code === code)

    return (
        <>
        <h1 className="Title">Edit Project</h1>
        { project && <ProjectForm project={project}/> }
        </>
    );
};

export default ProjectEdit;