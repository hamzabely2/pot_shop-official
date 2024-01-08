import axios from "axios";
interface registerClass
{
    lastName : string;
    userName : string;
    email : string;
    password : string;
}
interface loginClass
{
    email : string;
    password : string;
}
let userString = "User";
export const RegisterService = async(payload: registerClass)  => {

    try {
        return await axios.post(`${process.env.REACT_APP_URL}${userString}/register`,{
            lastName : payload.lastName,
            userName : payload.userName,
            email : payload.email,
            password : payload.password,
        })
    } catch (error : any) {
        return error
    }
}

export const LoginService = async(payload: loginClass)  => {
    try {
        return  await axios.post(`${process.env.REACT_APP_URL}${userString}/login`,{
            email : payload.email,
            password : payload.password,
        })
    } catch (error : any) {
        return error
    }
}

