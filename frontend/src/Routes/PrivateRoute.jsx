import React from 'react'
import { Outlet, Navigate } from 'react-router-dom'



export default function PrivateRoutes() {
    const token = localStorage.getItem('token');
   
    return (
        <>
        {!token ? (
         <Navigate to="/login" />
           
        ) : (
            <Outlet  />
        )}
           
        </>

    )

}