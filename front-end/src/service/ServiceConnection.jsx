import axios from "axios";
const userString = "User";
export const RegisterService = async(payload)  => {

    try {
        return await axios.post(`${process.env.REACT_APP_URL}${userString}/register`,{
            lastName : payload.lastName,
            userName : payload.userName,
            email : payload.email,
            password : payload.password,
        })
    } catch (error ) {
        return error
    }
}

export const LoginService = async(payload)  => {
    try {
        return  await axios.post(`${process.env.REACT_APP_URL}${userString}/login`,{
            email : payload.email,
            password : payload.password,
        })
    } catch (error ) {
        return error
    }
}

