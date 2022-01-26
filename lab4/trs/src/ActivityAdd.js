import React from 'react';
import ActivityForm from './ActivityForm';


function ActivityAdd(props) {
    return (
        <>
        <h1 className="Title">Add Activity</h1>
        <ActivityForm code="ARGUS-123"/>
        </>
    );
};

export default ActivityAdd;