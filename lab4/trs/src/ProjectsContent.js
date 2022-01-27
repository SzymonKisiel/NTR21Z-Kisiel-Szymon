import React from 'react';
import { getProjects } from './Data';
import ProjectsItem from './ProjectsItem';
import { Table } from 'react-bootstrap';
import { useNavigate } from 'react-router-dom';

function ProjectsContent(props) {
    let projects = props.projects || [];
    let isManager = props.isManager || false;

return (
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
                {projects.map((p, index) => <ProjectsItem key={p.code} project={p} isManager={isManager} />)}
            </tbody>
        </Table>
    );
};

export default ProjectsContent;