import axios from 'axios';

function getProjects() {
    return axios('/getprojects');
};

// function getSubactivities() {

// }

function getManagerProjects() {
    return axios('/getprojects'); // TODO: getmanagerprojects
}

// function getActivities() {
//     return axios('/getactivities');
// }

function getActivities(username, month) {
    // console.log("front: " + username + " " + month);
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
    // console.log("frontend: " + username + " " + date);
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
    // console.log("frontend: " + username + " " + month + " " + projectCode);
    return axios('/getprojectactivities', { 
        params: {
            username: username,
            month: month,
            projectCode: projectCode
        }
    });
}

function addActivity(username, activity) {
    return axios('/addactivity', { 
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


export { 
    getProjects, 
    getActivities, getDayActivities, getManagerProjects, getProjectActivities, 
    addActivity, deleteActivity 
};

