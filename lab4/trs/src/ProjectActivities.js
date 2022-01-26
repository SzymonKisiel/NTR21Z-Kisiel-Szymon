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

    const dateNow = new Date().toISOString().slice(0, 7);

    const [date, setDate] = useState(dateNow);

    function handleDateChange(e) {
        const { value } = e.target;
        setDate(value);
    }

    function addActivity() {
        // navigate("/addactivity", { test: "hej swiat!" });
        navigate("/addactivity", { state: { test: "hej swiat!"} });
    }

    return (
        <div>
            <h1 className="Title">{projectCode} Activities {date}</h1>
            <form>
                <input type="month" onChange={handleDateChange} value={date} />    
            </form>
            <ActivitiesContent activities={activities} />
            <input type="button" onClick={addActivity} value="Add activity" />
        </div>
    );
};

export default ProjectActivities;