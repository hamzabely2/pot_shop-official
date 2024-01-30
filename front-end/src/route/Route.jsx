import React from 'react';
import { Navigate,} from 'react-router-dom';




export const ProtectedRoute= ({role, allowedRoles, component: Component, ...rest
}) => {
    if(role === undefined || null )
        role = "visitor"

    let isAuthorized = role && allowedRoles.includes(role);
    console.log("role",role)

    return (
            isAuthorized ?
                <Component/> :
                <Navigate to="/"/>
    );
};