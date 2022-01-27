const express = require('express');
const app = express();
// const cors = require("cors");

const data = { "test": [ {"abc": "hej"}, {"abc": "niehej"}]}

// app.use(cors());
app.get('/hey', (req, res) => res.json(data));

app.get('/express_backend', (req, res) => {
    res.send({ express: 'Express backend contected to react.'});
});

app.get('/set', (req, res) => {
    console.log("set");
    console.log(JSON.stringify(req.query));
    console.log(req.query.id);
});

app.get('/getactivities', (req, res) => {
    console.log("getactivities");
    const activities = getActivities();
    res.json(activities);
});

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
    return activities;
};

app.listen(5000);