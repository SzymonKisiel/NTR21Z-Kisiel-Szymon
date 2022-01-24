import React from 'react';
import { getProjects } from './Data';
import Project from './Project';
import { Table } from 'react-bootstrap';

function Projects() {
    let projects = [];
    projects = getProjects();
    return (
        <div>
            <h1 className="Title">Projects</h1>
            <Table striped bordered hover>
                <thead>
                    <tr>
                    <th>Code</th>
                    <th>Manager</th>
                    <th>Name</th>
                    <th>Budget</th>
                    <th>Active</th>
                    </tr>
                </thead>
                <tbody>
                    {projects.map(p => <Project project={p} />)}
                </tbody>
            </Table>
        </div>
    );
};

export default Projects;