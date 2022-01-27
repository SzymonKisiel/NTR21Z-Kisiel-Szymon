const glob = require("glob");
const fs = require("fs");

function loadFromFiles(searchPattern) {
    let result = [];
    glob.sync(`./src/backend/data/${searchPattern}.json`).forEach((file) => {
        console.log(file);
        const data = fs.readFileSync(file);
        // return JSON.parse(data);
        result.push(JSON.parse(data)); 
    });
    return result;
};

function saveToFile() {};
function createFile(username, month) {};


function getProjects() {
    var data = require('./data/activity.json');
    return data.projects;
};

function addProject(project) {};
function editProject(projectCode, newProject) {};
function deleteProject(projectCode) {};

function getSubactivities(projectCode) {};

function closeProject(projectCode) {};
function isActive(projectCode) {};
function getBudget(projectCode) {};

function getActivities() {
    console.log("getall");
    let test = loadFromFiles("*-*");
    console.log(test);
    return test;
    // let activities = [
    //     {
    //         "date": "2021-11-07",
    //         "code": "ARGUS-123",
    //         "subcode": "database",
    //         "time": 45,
    //         "description": "data import"
    //     },
    //     {
    //         "date": "2021-11-07",
    //         "code": "OTHER",
    //         "subcode": "",
    //         "time": 120,
    //         "description": "picie kawy"
    //     },
    //     {
    //         "date": "2021-11-08",
    //         "code": "ARGUS-123",
    //         "subcode": "",
    //         "time": 45,
    //         "description": "kompilacja"
    //     },
    //     {
    //         "date": "2021-11-08",
    //         "code": "OTHER",
    //         "subcode": "",
    //         "time": 120,
    //         "description": "office arrangement"
    //     },
    //     {
    //         "date": "2021-11-12",
    //         "code": "ARGUS-123",
    //         "subcode": "other",
    //         "time": 45,
    //         "description": "project meeting"
    //     }
    // ];
    // return activities;
};


function getMonthActivities(month) {
    return loadFromFiles(`*-${month}`);
};

function getMonthActivities(username, month) {
    console.log(username + " " + month);
    return loadFromFiles(`${username}-${month}`);
};

// function getMonthActivities(month, projectCode) {}

function getMonthActivities(username, month, projectCode) {
    //TODO
    return loadFromFiles(`${username}-${month}`);
};

function getDayActivities(date) {};
function getDayActivities(username, date) {};

function deleteActivity(username, date, projectCode) {};
function updateActivity(username, date, projectCode, newActivity) {};

function closeMonth(username, month) {};
function isMonthClosed(username, month) {};

function getUsers(month, projectCode) {};

function getAcceptedTime(username, month, projectCode) {};
function setAcceptedTime(username, month, projectCode, newAcceptedTime) {};

function isReportEditable(username, month, projectCode) {};
function getAcceptedTimeSum(projectCode) {};
function getAcceptedTimeSum(projectCode, month) {};

module.exports = { getProjects, getActivities, getMonthActivities };