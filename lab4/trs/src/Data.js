import axios from 'axios';

function getProjects() {
    return axios('/getprojects');
};

function getSubactivities(projectCode) {
    return axios('/getsubactivities', { 
        params: {
            projectCode: projectCode
        }
    });
}

function addProject(project) {
    return axios('/createproject', { 
        params: {
            project: project
        }
    });
}


function getManagerProjects() {
    return axios('/getprojects'); // TODO: getmanagerprojects
}

// function getActivities() {
//     return axios('/getactivities');
// }

function getActivities(username, month) {
    if (username && month) {
        return axios('/getmonthactivities', { 
            params: {
                username: username,
                month: month
            }
        });
    }
    else {
        return axios('/getactivities');
    }
}

function getDayActivities(username, date) {
    if (username && date) {
        return axios('/getdayactivities', { 
            params: {
                username: username,
                date: date
            }
        });
    }
}

function getProjectActivities(username, month, projectCode) {
    return axios('/getprojectactivities', { 
        params: {
            username: username,
            month: month,
            projectCode: projectCode
        }
    });
}

function addActivity(username, activity) {
    return axios('/createactivity', { 
        params: {
            username: username,
            activity: activity
        }
    });
}

function deleteActivity(username, activity) {
    return axios('/deleteactivity', { 
        params: {
            username: username,
            activity: activity
        }
    });
}

function editActivity(username, oldActivity, newActivity) {
    return axios('/updateactivity', { 
        params: {
            username: username,
            oldActivity: oldActivity,
            newActivity: newActivity
        }
    });
}

export { 
    getProjects, getSubactivities,
    addProject,
    getActivities, getDayActivities, getManagerProjects, getProjectActivities, 
    addActivity, deleteActivity, editActivity 
};

