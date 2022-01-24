import React, { Fragment } from 'react';

function Project(props) {
    let project = props.project;
    return (
        <Fragment>
            <tr>
                <td>{project.code}</td>
                <td>{project.manager}</td>
                <td>{project.name}</td>
                <td>{project.budget}</td>
                <td>{project.active ? <p>Active</p> : <p>Inactive</p>}</td>
                <td>{project.subactivities.map((s) => <p>{s}</p>)}</td>
                {/* <td>project.code</td> */}
            </tr>
        </Fragment>
    );
};

export default Project;