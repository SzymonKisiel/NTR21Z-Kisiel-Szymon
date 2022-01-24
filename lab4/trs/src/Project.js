import React from 'react';

function Project(props) {
    let project = props.project;
    return (
        <tr>
            <td>{project.code}</td>
            <td>{project.manager}</td>
            <td>{project.name}</td>
            <td>{project.budget}</td>
            <td>{project.active ? <p>Active</p> : <p>Inactive</p>}</td>
            {/* <td>project.code</td> */}
        </tr>
    );
};

export default Project;