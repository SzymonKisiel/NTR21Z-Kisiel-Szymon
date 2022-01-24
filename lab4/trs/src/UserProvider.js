import { useState } from "react";
import UserContext from "./UserContext";

const UserProvider = ({children}) => {
    const [username, setUsername] = useState("");
    const [isLoggedIn, setLoggedIn] = useState(false);
    

    const login = (name) => {
        setUsername(name);
        setLoggedIn(true);
    };

    const logout = () => {
        setUsername('');
        setLoggedIn(false);
    };

    return (
        <UserContext.Provider value={{ username, isLoggedIn, login, logout }}>
            {children}
        </UserContext.Provider>
    );
}

export default UserProvider;