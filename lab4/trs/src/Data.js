import axios from 'axios';
function getProjects() {
    return axios('/getprojects');
};

function getActivities() {
    return axios('/getactivities');
}


export { getProjects, getActivities };

