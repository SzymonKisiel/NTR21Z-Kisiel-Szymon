import React from 'react';
import { getProjects } from './Data';
import Project from './Project';
import { Table } from 'react-bootstrap';

function Manager() {
    let projects = getProjects();
    return (
        <div>
            <h1 className="Title">Manager</h1>
            <Table striped bordered hover>
                <thead>
                    <tr>
                    <th>Code</th>
                    <th>Manager</th>
                    <th>Name</th>
                    <th>Budget</th>
                    <th>Active</th>
                    <th>Subactivities</th>
                    </tr>
                </thead>
                <tbody>
                    {projects.map(p => <Project project={p} />)}
                </tbody>
            </Table>
        </div>
    );
};

export default Manager;