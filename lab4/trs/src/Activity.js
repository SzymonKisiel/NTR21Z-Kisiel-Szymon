import React from 'react';
import { Link } from 'react-router-dom';

function Activity(props) {
    let activity = props.activity;
    let editable = props.editable || true;
    return (
        <tr>
            <td>{activity.date}</td>
            <td>{activity.code}</td>
            <td>{activity.subcode}</td>
            <td>{activity.time}</td>
            <td>{activity.description}</td>
            { editable &&
                <>
                <td><Link to="/logo">Edit</Link></td>
                <td><Link to="/logo">Delete</Link></td>
                </>
            }
        </tr>
    );
};

export default Activity;