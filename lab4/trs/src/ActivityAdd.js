import React from 'react';
import ActivityForm from './ActivityForm';
import { useLocation } from 'react-router-dom';

function ActivityAdd(props) {
    const location = useLocation();
    const projectCode = location.state.projectCode;
    const month = location.state.month;

    console.log(month);
    let d = new Date(month);
    // console.log(d.toISOString());
    let firstDay = new Date(d.getFullYear(), d.getMonth(), 1);
    let lastDay = new Date(d.getFullYear(), d.getMonth()+1, 0);
    console.log(firstDay.toISOString());
    console.log(lastDay.toISOString());

    return (
        <>
        <h1 className="Title">Add Activity to {projectCode}</h1>
        <ActivityForm code={projectCode}/>
        </>
        
    );
};

export default ActivityAdd;