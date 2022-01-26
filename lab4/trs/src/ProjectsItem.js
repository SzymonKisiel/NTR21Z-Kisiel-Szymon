import React from 'react';
import { Link } from 'react-router-dom';

function ProjectsItem(props) {
    let project = props.project;
    let isManager = props.isManager || false;
    return (
        <tr>
            <td>{project.code}</td>
            <td>{project.manager}</td>
            <td>{project.name}</td>
            <td>{project.budget}</td>
            <td>{project.active ? <p>Active</p> : <p>Inactive</p>}</td>
            <td>{project.subactivities.map((s) => <p>{s}</p>)}</td>
            
            { isManager 
                ?
                    <>
                    <td><Link to="/logo">Details</Link></td>
                    <td><Link to="/logo">Close</Link></td>
                    </>
                :
                    <td><Link to={"/details/" + project.code}>Details</Link></td>
            }
        </tr>
    );
};

export default ProjectsItem;