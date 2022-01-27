const express = require('express');
const app = express();
const model = require("./model");

const data = { "test": [ {"test1": "abc"}, {"test2": "def"}]}

app.get('/test', (req, res) => res.json(data));

app.get('/set', (req, res) => {
    console.log("set");
    console.log(JSON.stringify(req.query));
    console.log(req.query.id);
});

app.get('/getactivities', (req, res) => {
    const activities = model.getActivities();
    res.json(activities);
});

app.get('/getprojects', (req, res) => {
    const activities = model.getProjects();
    res.json(activities);
});

app.listen(5000);