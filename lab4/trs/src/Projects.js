import React, { useState, useEffect } from 'react';
import { getProjects } from './Data';
import ProjectsContent from './ProjectsContent';
import { useNavigate } from 'react-router-dom';

function Projects() {
    let navigate = useNavigate();
    const [projects, setProjects] = useState();

    useEffect(() => {
        const fetchData = async () => {
            const result = await getProjects();
            setProjects(result.data);
        };
        fetchData();
    }, []);

    function addProject() {
        navigate("/addproject");
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