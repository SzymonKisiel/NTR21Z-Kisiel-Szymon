import React from 'react';
import { Table } from 'react-bootstrap';
import ActivityItem from './ActivityItem';

function ActivitiesContent(props) {
    let activities = props.activities || [];
    
    return (
        <div>
            <Table striped bordered hover>
                <thead>
                    <tr>
                    <th>Date</th>
                    <th>Code</th>
                    <th>Subcode</th>
                    <th>Time</th>
                    <th>Description</th>
                    </tr>
                </thead>
                <tbody>
                    {activities.map((a, index) => <ActivityItem key={"activity"+index} activity={a} />)}
                </tbody>
            </Table>
        </div>
    );
};

export default ActivitiesContent;