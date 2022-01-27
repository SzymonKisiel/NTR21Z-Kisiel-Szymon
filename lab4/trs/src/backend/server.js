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

app.get('/getprojects', (req, res) => {
    const activities = model.getProjects();
    res.json(activities);
});

app.get('/getactivities', (req, res) => {
    const activities = model.getActivities();
    res.json(activities);
});

app.get('/getmonthactivities', (req, res) => {
    const month = req.query.month; 
    const activities = model.getMonthActivities(month);
    res.json(activities);
});

// debug
model.getMonthActivities("nowak", "2021-11");
// model.getMonthActivities("2021-10");

app.listen(5000);