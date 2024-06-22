import React, { createContext, useState, useEffect } from 'react';
import * as jwt_decode from "jwt-decode";

export const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
  const [userData, setUserData] = useState(null);
// const [username, setUsername] = useState(""); 
//   const [role, setRole] = useState(""); // Rola użytkownika (admin, user)
//   const [token, setToken] = useState(""); 

  // const setUserData = (userData) => {
  //   setUsername(userData.username);
  //   setRole(userData.role);
  //   setToken(userData.token);
  // };

  // const [userData, setUserData] = useState(() => {
  //   const token = localStorage.getItem("authToken");
  //   return token ? { token, ...jwt_decode(token) } : null;
  // });

  // useEffect(() => {
  //   const token = localStorage.getItem("authToken");
  //   if (token) {
  //     setUserData({ token, ...jwt_decode(token) });
  //   }
  // }, []);

  useEffect(() => {
    // const token = localStorage.getItem('authToken');
    const username = localStorage.getItem('username');
    console.log(username)
    if(username) {
      setUserData({username: username, role: 'admin', token: "34324"});
    }
    // console.log(token)
    // if (token) {
      // const decodedToken = jwt_decode.jwtDecode(token);
      // console.log(decodedToken)
      // setUserData({ username: decodedToken.email, role: decodedToken.role, token });
    // }
  }, []);

  const logout = () => {
    // setUsername("");
    // setRole("");
    // setToken("");
    setUserData(null);
    localStorage.removeItem('authToken');
    localStorage.removeItem('username');
  };

  return (
    <AuthContext.Provider value={{ userData, setUserData, logout }}>
      {children}
    </AuthContext.Provider>
  );
};
