import React, { useState, useEffect, useContext } from 'react';
import { getProjectActivities } from './Data';
import ActivitiesContent from './ActivitiesContent';
import { Link, useParams, useNavigate } from 'react-router-dom';
import { UserContext } from './UserProvider';

function ProjectActivities() {
    const [activities, setActivities] = useState();
    const { username } = useContext(UserContext);
    const navigate = useNavigate();
    const params = useParams();
    let type = params.type || 'month';
    const projectCode = params.projectCode;

    const dateNow = 
    type==="day" 
        ? new Date().toISOString().slice(0, 10)
        : new Date().toISOString().slice(0, 7);
    const [date, setDate] = useState(dateNow);

    useEffect(() => {
        const fetchData = async () => {
            var result = {};
            if (type === "day") {
                //result = await getDayActivities(username, date);
            }
            else {
                result = await getProjectActivities(username, date, projectCode);
            }
            
            const report = result.data;
            if (report && report.entries) {
                setActivities(report.entries);
            }
            else {
                setActivities([]);
            }
        };
        fetchData();
    }, [date]);

    function handleDateChange(e) {
        const { value } = e.target;
        setDate(value);
    }

    function addActivity() {
        // navigate("/addactivity", { test: "hej swiat!" });
        navigate("/addactivity", { state: { month: date, projectCode: projectCode} });
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