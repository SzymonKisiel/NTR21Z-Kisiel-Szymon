const glob = require("glob");
const fs = require("fs");

function loadReportsFromFiles(searchPattern) {
    let result = [];
    glob.sync(`./src/backend/data/${searchPattern}.json`).forEach((file) => {
        // console.log(file);
        const data = fs.readFileSync(file);
        result.push(JSON.parse(data)); 
    });
    return result;
};

function saveReportToFile(username, month, report) {
    const filename = `${username}-${month}.json`;
    fs.writeFileSync(`./src/backend/data/${filename}`, JSON.stringify(report));
};

function createReportFile(username, month) {
    const filename = `${username}-${month}.json`;
    const newReport = { "frozen": false, "entries": [], "accepted": [] };
    fs.writeFileSync(`./src/backend/data/${filename}`, JSON.stringify(newReport));
    return newReport;
};

function loadProjectsFromFile() {
    var result = {}
    glob.sync(`./src/backend/data/activity.json`).forEach((file) => {
        console.log(file);
        const data = fs.readFileSync(file);
        result = JSON.parse(data); 
    });
    // console.log(result.projects);
    return result.projects;
};

function saveProjectsToFile(projects) {
    const data = { "projects": projects };
    fs.writeFileSync(`./src/backend/data/activity.json`, JSON.stringify(data));
};

function getProjects() {
    return loadProjectsFromFile();
};

function addProject(project) {
    const projects = getProjects();
    projects.push(project);
    saveProjectsToFile(projects);
    return true;
};

// function getManagerProjects(manager) {
//     const projects = getProjects();
//     projects.filter((project) => { return project.manager == manager });
// }

function editProject(projectCode, newProject) {};
function deleteProject(projectCode) {};

function getSubactivities(projectCode) {
    const projects = getProjects();
    const project = projects.find(
        (project) => {
            return project.code == projectCode;
        }
    );
    if (project)
        return project.subactivities;
    return [];
};

function closeProject(projectCode) {};
function isActive(projectCode) {};
function getBudget(projectCode) {};

function getActivities() {
    let test = loadReportsFromFiles("*-*");
    return test;
};


function getMonthActivities(month) {
    return loadReportsFromFiles(`*-${month}`);
};

function getMonthActivities(username, month) {
    return loadReportsFromFiles(`${username}-${month}`)[0];
};

// function getMonthActivities(month, projectCode) {}

function getProjectActivities(username, month, projectCode) {
    var report = getMonthActivities(username, month);
    return toProjectReport(report, projectCode);
};

function getDayActivities(date) {};

function getDayActivities(username, date) {
    const month = date.slice(0, 7);
    var report = getMonthActivities(username, month);
    return toDayReport(report, date);
    
};

function addActivity(username, activity) {
    const month = activity.date.slice(0, 7);
    var report = getMonthActivities(username, month);
    if (!report || report.length === 0) {
        report = createReportFile(username, month);
    }
    report.entries.push(activity);
    saveReportToFile(username, month, report);

    return true;
};

function deleteActivity(username, activity) {
    const month = activity.date.slice(0, 7);
    var report = getMonthActivities(username, month);
    report.entries = report.entries.filter(function(entry) {
        return entry.code !== activity.code ||
        entry.date !== activity.date ||
        entry.subcode !== activity.subcode ||
        entry.time !== activity.time ||
        entry.description !== activity.description
    });
    saveReportToFile(username, month, report);

    return true;
};

function updateActivity(username, oldActivity, newActivity) {
    const month = oldActivity.date.slice(0, 7);
    var report = getMonthActivities(username, month);
    const index = report.entries.findIndex(function(entry) {
        return entry.code == oldActivity.code &&
        entry.date == oldActivity.date &&
        entry.subcode == oldActivity.subcode &&
        entry.time == oldActivity.time &&
        entry.description == oldActivity.description
    });
    if (index !== -1) {
        report.entries[index] = newActivity;
        saveReportToFile(username, month, report);
        return true;
    }
    return false;
};

function closeMonth(username, month) {};
function isMonthClosed(username, month) {};

function getUsers(month, projectCode) {};

function getAcceptedTime(username, month, projectCode) {};
function setAcceptedTime(username, month, projectCode, newAcceptedTime) {};

function isReportEditable(username, month, projectCode) {};
function getAcceptedTimeSum(projectCode) {};
function getAcceptedTimeSum(projectCode, month) {};


function toDayReport(report, date) {
    var result = { entries: [] };
    report.entries.forEach(entry => {
        if (entry.date == date)
            result.entries.push(entry);
    });
    return result;
}

function toProjectReport(report, projectCode) {
    var result = { entries: [] };
    if (report && report.entries) {
        report.entries.forEach(entry => {
            if (entry.code == projectCode)
                result.entries.push(entry);
        });
    }
    return result;
}
    

module.exports = { 
    getProjects, getSubactivities,
    addProject,
    getActivities, getMonthActivities, getDayActivities, getProjectActivities, 
    addActivity, deleteActivity, updateActivity
    // createReportFile, saveReportToFile 
};