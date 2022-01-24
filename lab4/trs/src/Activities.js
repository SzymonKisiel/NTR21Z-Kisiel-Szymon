import React from 'react';
import { Link, useParams } from 'react-router-dom';
import { getActivities } from './Data';
import { Table } from 'react-bootstrap';
import Activity from './Activity';

function Activities() {
    let params = useParams();
    let type = params.type || 'month';

    let activities = getActivities();
    return (
        <div>
            <h1 className="Title">{type==="day" ? <>Day</> : <>Month</>} Activities</h1>
            <form>
                <input type="date" />    
            </form>
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
                    {activities.map(a => <Activity activity={a} />)}
                </tbody>
            </Table>
            { type==="month" &&
                <Link to="/logo">Close month</Link>
            }
        </div>
    );
};

export default Activities;