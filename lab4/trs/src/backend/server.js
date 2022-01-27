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
    const username = req.query.username;
    const month = req.query.month; 

    const activities = model.getMonthActivities(username, month);
    res.json(activities);
});

app.get('/getdayactivities', (req, res) => {
    const username = req.query.username;
    const date = req.query.date; 
    
    console.log("frontend: " + username + " " + date);

    const activities = model.getDayActivities(username, date);
    res.json(activities);
});

// debug
// model.getMonthActivities("nowak", "2021-11");
// model.getMonthActivities("2021-10");
const test = model.getDayActivities("kowalski", "2021-11-07");
console.log(JSON.stringify(test));

app.listen(5000);