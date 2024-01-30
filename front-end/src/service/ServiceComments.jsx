import axios, {AxiosError} from "axios";
import React from "react";

export const RegisterService = async()  => {

    const instance = axios.create({
        baseURL: 'https://votre-api-backend.com',
        headers: {
            'Authorization': `Bearer ${"token"}`, // Incluez le token ici
            'Content-Type': 'application/json',
        },
    });


    try {
        return await instance.post(`${process.env.REACT_APP_URL}User/register`,{

        })

    } catch (error) {
        console.log(error )
        return  error
    }
}
