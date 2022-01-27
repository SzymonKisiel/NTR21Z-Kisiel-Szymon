import axios from 'axios';
function getProjects() {
    var data = require('./data/activity.json');
    return data.projects;
};

function getActivities() {
    let activities = [
        {
            "date": "2021-11-07",
            "code": "ARGUS-123",
            "subcode": "database",
            "time": 45,
            "description": "data import"
        },
        {
            "date": "2021-11-07",
            "code": "OTHER",
            "subcode": "",
            "time": 120,
            "description": "picie kawy"
        },
        {
            "date": "2021-11-08",
            "code": "ARGUS-123",
            "subcode": "",
            "time": 45,
            "description": "kompilacja"
        },
        {
            "date": "2021-11-08",
            "code": "OTHER",
            "subcode": "",
            "time": 120,
            "description": "office arrangement"
        },
        {
            "date": "2021-11-12",
            "code": "ARGUS-123",
            "subcode": "other",
            "time": 45,
            "description": "project meeting"
        }
        // {
        //     time: 100,
        //     description: "kompilacja"
        // },
        // {
        //     time: 45,
        //     description: "meeting"
        // }
    ];

    console.log(activities);

    return activities;
};

function backendGetActivities() {
    const fetchData = async () => {
        const result = await axios('/getactivities').then(
            (res) => {
                return res.data;
            }
        );
    };
    const data = fetchData();
    return data;
}

export { getProjects, getActivities, backendGetActivities };

