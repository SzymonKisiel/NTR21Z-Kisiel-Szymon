import React from 'react';
import { getProjects } from './Data';
import { useParams } from 'react-router-dom';
import { useLocation } from 'react-router-dom';
import ActivityForm from './ActivityForm';


function ActivityEdit(props) {
    const location = useLocation();
    // let projects = getProjects();
    // let params = useParams();

    // let code = props.code || params.code;
    // let project = projects.find(p => p.code === code);

    const oldActivity = location.state.oldActivity;

    return (
        <>
        <h1 className="Title">Edit Activity</h1>
        { true && <ActivityForm activity={oldActivity}/> }
        </>
    );
};

export default ActivityEdit;