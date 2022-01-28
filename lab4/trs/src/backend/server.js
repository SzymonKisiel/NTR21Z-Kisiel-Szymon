const express = require('express');
const path = require('path');
const app = express();
const model = require("./model");

const develop = process.argv[2] == "develop";

if (!develop) {
    console.log(path.join(__dirname, '../../build'));
    app.use(express.static(path.join(__dirname, '../../build')));
};

app.get('/test', (req, res) => res.json({ "test": [ {"test1": "abc"}, {"test2": "def"}]}));

app.get('/getprojects', (req, res) => {
    const projects = model.getProjects();
    res.json(projects);
});

app.get('/getmanagerprojects', (req, res) => {
    const manager = req.query.manager;

    const projects = model.getManagerProjects(manager);
    res.json(projects);
});


app.get('/getsubactivities', (req, res) => {
    const projectCode = req.query.projectCode;

    const subactivities = model.getSubactivities(projectCode);
    res.json(subactivities);
});

app.get('/createproject', (req, res) => {
    const project = JSON.parse(req.query.project);

    const result = model.addProject(project);
    res.json(result);
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

app.get('/createactivity', (req, res) => {
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

app.get('/updateactivity', (req, res) => {
    const username = req.query.username;
    const oldActivity = JSON.parse(req.query.oldActivity);
    const newActivity = JSON.parse(req.query.newActivity);

    const result = model.updateActivity(username, oldActivity, newActivity);
    res.json(result);
});

if (!develop) {
    console.log(path.join(__dirname, '../../build', 'index.html'));
    app.get('*', (req, res) => {
        res.sendFile(path.join(__dirname, '../../build', 'index.html'))
    });
};

const initMsg = develop 
    ? "Development server starting. Listening on port 5000." 
    : "Production server starting. Listening on port 5000.";
app.listen(5000, () => console.log(initMsg));