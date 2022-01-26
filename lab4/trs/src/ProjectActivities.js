import React, { useState } from 'react';
import { getActivities } from './Data';
import ActivitiesContent from './ActivitiesContent';
import { Link, useParams, useNavigate } from 'react-router-dom';

function ProjectActivities() {
    let params = useParams();

    const projectCode = params.projectCode;

    let type = 'month';
    let navigate = useNavigate();
    let activities = getActivities(); // getProjectActivities

    const dateNow = 
        type==="day" 
            ? new Date().toISOString().slice(0, 10)
            : new Date().toISOString().slice(0, 7);

    console.log(dateNow);

    const [date, setDate] = useState(dateNow);

    function handleDateChange(e) {
        const { value } = e.target;
        setDate(value);
    }

    return (
        <div>
            <h1 className="Title">{projectCode} Activities</h1>
            <form>
                <input type={type==="day" ? "date" : "month"} onChange={handleDateChange} value={date} />    
            </form>
            <ActivitiesContent activities={activities} />
        </div>
    );
};

export default ProjectActivities;