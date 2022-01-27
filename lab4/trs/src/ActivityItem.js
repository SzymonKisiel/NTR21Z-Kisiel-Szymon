import React, { useContext } from 'react';
import { useNavigate } from 'react-router-dom';
import { UserContext } from './UserProvider';
import { deleteActivity } from './Data';

function ActivityItem(props) {
    const { username } = useContext(UserContext);
    const navigate = useNavigate();

    let activity = props.activity;
    let editable = props.editable || true;

    function handleEdit() {
        alert("edit");
        navigate("/editactivity", { state: { oldActivity: activity }});
    }
    function handleDelete() {
        alert("delete");
        deleteActivity(username, activity);
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
                <td><a href="" onClick={handleEdit}>Edit</a></td>
                <td><a href="" onClick={handleDelete}>Delete</a></td>
                </>
            }
        </tr>
    );
};

export default ActivityItem;