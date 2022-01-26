import React from 'react';
import { useNavigate } from 'react-router-dom';

function ActivityItem(props) {
    const navigate = useNavigate();

    let activity = props.activity;
    let editable = props.editable || true;

    function editActivity() {
        alert("edit");
        navigate("/editactivity", { state: { oldActivity: activity }});
    }
    function deleteActivity() {
        alert("delete");
    }

    return (
        <tr>
            <td>{activity.date}</td>
            <td>{activity.code}</td>
            <td>{activity.subcode}</td>
            <td>{activity.time}</td>
            <td>{activity.description}</td>
            { editable &&
                <>
                <td><a href="" onClick={editActivity}>Edit</a></td>
                <td><a href="" onClick={deleteActivity}>Delete</a></td>
                </>
            }
        </tr>
    );
};

export default ActivityItem;