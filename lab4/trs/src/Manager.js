import React, { useState, useEffect, useContext } from 'react';
import { getManagerProjects } from './Data';
import ProjectsContent from './ProjectsContent';
import { useNavigate } from 'react-router-dom';
import { UserContext } from './UserProvider';

function Manager() {
    const [projects, setProjects] = useState();
    const { username } = useContext(UserContext);
    const navigate = useNavigate();

    useEffect(() => {
        const fetchData = async () => {
            const result = await getManagerProjects(username);
            setProjects(result.data);
        };
        fetchData();
    }, [username]);

    function addProject() {
        navigate("/addproject");
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