import React, { useState, useEffect } from 'react';
import { getActivities } from './Data';
import { backendGetActivities } from './Data';
import ActivitiesContent from './ActivitiesContent';
import { Link, useParams, useNavigate } from 'react-router-dom';

import axios from 'axios';

function Activities() {
    const [activities, setActivities] = useState();
    let params = useParams();
    let type = params.type || 'month';

    useEffect(() => {
        const fetchData = async () => {
            const result = await getActivities();
            setActivities(result.data);
        };
        fetchData();
    }, []);

    const dateNow = 
        type==="day" 
            ? new Date().toISOString().slice(0, 10)
            : new Date().toISOString().slice(0, 7);
    const [date, setDate] = useState(dateNow);

    function handleDateChange(e) {
        const { value } = e.target;
        setDate(value);
    }

    return (
        <div>
            <h1 className="Title">{type==="day" ? <>Day</> : <>Month</>} Activities {date}</h1>
            <form>
                <input type={type==="day" ? "date" : "month"} onChange={handleDateChange} value={date} />    
            </form>
            <ActivitiesContent activities={activities} />
            { type==="month" &&
                <Link to="/logo">Close month</Link>
            }
        </div>
    );
};

export default Activities;