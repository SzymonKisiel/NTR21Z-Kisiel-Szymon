import React from 'react';
import { getProjects } from './Data';
import { useParams } from 'react-router-dom';
import { useLocation } from 'react-router-dom';
import ActivityForm from './ActivityForm';


function ActivityEdit(props) {
    const location = useLocation();
    const oldActivity = location.state.oldActivity;

    return (
        <>
        <h1 className="Title">Edit Activity</h1>
        { true && <ActivityForm activity={oldActivity}/> }
        </>
    );
};

export default ActivityEdit;