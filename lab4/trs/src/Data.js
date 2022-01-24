
function getProjects() {
    var data = require('./data/activity.json');
    // let projects = [
    //     {
    //         code: "ALPHA",
    //         manager: "nowak",
    //         name: "Alpha",
    //         budget: 125,
    //         active: true,
    //         subactivities: [
    //             "database",
    //             "other"
    //         ]
    //     },
    //     {
    //         code: "BETA",
    //         manager: "smith",
    //         name: "Beta",
    //         budget: -1,
    //         active: true,
    //         subactivities: []
    //     }
    // ];
    return data.projects;
};

function getActivities() {
    let activities = [
        {
            time: 100,
            description: "kompilacja"
        },
        {
            time: 45,
            description: "meeting"
        }
    ];
    return activities;
};

export { getProjects, getActivities };

