import React, { useState, useEffect, useContext } from 'react';
import { getActivities } from './Data';
import ActivitiesContent from './ActivitiesContent';
import { Link, useParams, useNavigate } from 'react-router-dom';
import { UserContext } from './UserProvider';

function Activities() {
    const [activities, setActivities] = useState();
    const { username } = useContext(UserContext);
    let params = useParams();
    let type = params.type || 'month';

    const dateNow = 
    type==="day" 
        ? new Date().toISOString().slice(0, 10)
        : new Date().toISOString().slice(0, 7);
    const [date, setDate] = useState(dateNow);

    useEffect(() => {
        const fetchData = async () => {
            const result = await getActivities(username, date);
            const report = result.data[0];
            if (report && report.entries) {
                // console.log(report.entries);
                setActivities(report.entries);
            }
            else {
                setActivities([]);
            }
            
            // console.log(result.data[0]);
            // const test = JSON.parse(JSON.stringify(result.data));
            // console.log(test);
            // console.log(JSON.stringify(result.data));
            // console.log(JSON.stringify(result.data)["entries"]);
            // 
        };
        fetchData();
    }, [date]);

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