import React, { createContext, useState, useEffect } from 'react';
import * as jwt_decode from "jwt-decode";

export const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
  const [userData, setUserData] = useState(null);

  useEffect(() => {
    const token = localStorage.getItem('authToken');
    console.log(token)
    if (token) {
      const decodedToken = jwt_decode.jwtDecode(token);
      console.log(decodedToken)

      setUserData({ username: decodedToken["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"], role: decodedToken["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"], token });
    }
  }, []);


  const login = (token) => {
    const decodedToken = jwt_decode.jwtDecode(token);
    setUserData({
      username: decodedToken["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"],
      role: decodedToken["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"],
      token: token,
    });
    localStorage.setItem("authToken", token);
  };

  const logout = () => {
    setUserData(null);
    localStorage.removeItem('authToken');
  };

  return (
    <AuthContext.Provider value={{ userData, setUserData, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
};
