import React from 'react';
import { useParams } from 'react-router-dom';


function Activities() {
    let params = useParams();
    let type = params.type || 'month';
    return (
        <div>
            <p>Activities {type}</p>
        </div>
    );
};

export default Activities;