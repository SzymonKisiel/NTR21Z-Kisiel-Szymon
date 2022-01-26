import { useState } from "react";
import { createContext, useEffect } from "react";

const UserContext = createContext({username: "", isLoggedIn: false});

const UserProvider = ({children}) => {
    const initialUsername = JSON.parse(localStorage.getItem("user")) || "";
    const initialLoggedIn = JSON.parse(localStorage.getItem("isLoggedIn")) || false;

    const [username, setUsername] = useState(initialUsername);
    const [isLoggedIn, setLoggedIn] = useState(initialLoggedIn);

    const login = (name) => {
        // console.log("login");
        localStorage.setItem("user", JSON.stringify(name));
        localStorage.setItem("isLoggedIn", JSON.stringify(true));
        setUsername(name);
        setLoggedIn(true);
    };

    const logout = () => {
        localStorage.clear();
        // console.log("logout");
        setUsername("");
        setLoggedIn(false);
    };

    return (
        <UserContext.Provider value={{ username, isLoggedIn, login, logout }}>
            {children}
        </UserContext.Provider>
    );
}

export { UserContext, UserProvider };