import React from 'react';
import ActivityForm from './ActivityForm';
import { useLocation } from 'react-router-dom';

function ActivityAdd(props) {
    const location = useLocation();
    const test = location.state.test;
    return (
        <>
        <h1 className="Title">Add Activity {test}</h1>
        <ActivityForm code="ARGUS-123"/>
        </>
    );
};

export default ActivityAdd;