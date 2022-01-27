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

    const activities = model.getDayActivities(username, date);
    res.json(activities);
});

app.get('/getprojectactivities', (req, res) => {
    const username = req.query.username;
    const month = req.query.month;
    const projectCode = req.query.projectCode; 

    const activities = model.getProjectActivities(username, month, projectCode);
    res.json(activities);
});

app.get('/addactivity', (req, res) => {
    const username = req.query.username;
    const activity = JSON.parse(req.query.activity);

    const result = model.addActivity(username, activity);
    res.json(result);
});

app.get('/deleteactivity', (req, res) => {
    const username = req.query.username;
    const activity = JSON.parse(req.query.activity);

    const result = model.deleteActivity(username, activity);
    res.json(result);
});

// debug
// model.getMonthActivities("nowak", "2021-11");
// model.getMonthActivities("2021-10");
// const test = model.getDayActivities("kowalski", "2021-11-07");
// console.log(JSON.stringify(test));

// model.createReportFile("tester", "2023-03");
// model.saveReportToFile("tester", "2023-03", { "frozen": true, "entries": [], "accepted": [] });
// const activity = {
//     "date": "2022-01-12",
//     "code": "ARGUS-123",
//     "subcode": "other",
//     "time": 45,
//     "description": "project meeting"
// }
// model.addActivity("tester", activity);
// const activity = {
//     "date": "2022-01-13",
//     "code": "ARGUS-123",
//     "subcode": "other",
//     "time": 50,
//     "description": "project meeting"
// }
// model.addActivity("tester", activity);

// model.deleteActivity("tester", {"date":"2022-01-12","code":"ARGUS-123","subcode":"other","time":45,"description":"project meeting"});

app.listen(5000);