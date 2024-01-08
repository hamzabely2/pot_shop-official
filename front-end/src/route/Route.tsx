import React from 'react';
import { Navigate,redirect} from 'react-router-dom';

export type UserRole =string

export interface User {
    id: string;
    username: string;
    email: string;
    role: string;
}

interface ProtectedRouteProps  {
    allowedRoles: UserRole[];
    component: React.ComponentType<any>;

    role : string;
}

export const ProtectedRoute: React.FC<ProtectedRouteProps> = ({role, allowedRoles, component: Component, ...rest
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