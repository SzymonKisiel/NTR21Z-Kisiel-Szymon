import React from 'react';
import { UserContext } from './UserProvider';
import { useState, useContext, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';

function Login() {
    let navigate = useNavigate();

    const { username, isLoggedIn, login, logout } = useContext(UserContext);
    const [name, setName] = useState('');

    function handleSubmit() {
        login(name);
        navigate("/");
    };

    return (
        <div> 
        {
            isLoggedIn
            ?
                <>
                <p>Logged in as {username}</p>
                <input type="button" onClick={logout} value="Logout" />
                </>
            :
                <form onSubmit={handleSubmit}>
                    <label>
                        Username:
                        <input
                        type="text"
                        value={name}
                        onChange={e => setName(e.target.value)}
                        />
                    </label>
                    <input type="submit" value="Submit" />
                </form>
        }
        </div>
    );
};

export default Login;