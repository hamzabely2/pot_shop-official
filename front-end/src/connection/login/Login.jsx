import React, {useState} from 'react';
import {ToastContainer} from "react-toastify";
import {ToastError, ToastSuccess} from "../../components/poPup/Toast";
import { LoginService} from "../../service/ServiceConnection";
import {Link, useNavigate} from "react-router-dom";
import {setCookie} from "../../service/useAuth";


const Login = () => {
    const [email, setEmail] = useState("")
    const [password, setPassword] = useState("")
    const navigate = useNavigate();

    const displayApiErrors = (errors) => {
        for (const key in errors ) {
            if (errors.hasOwnProperty(key)) {
                const errorMessages = errors[key];
                if (Array.isArray(errorMessages)) {
                    errorMessages.forEach((errorMessage) => {
                        ToastError(errorMessage);
                    });
                }
            }
        }
    };
    const handleLogin = async (event) =>{
        event.preventDefault();

        try {
            const response = await LoginService({email, password});
            if (response.status === 200) {
                setTimeout(() => {
                    ToastSuccess(response.data.message);
                }, 200)
                let token =  response.data.result
                setCookie("token", token,7);
                navigate("public/home")
            }
            if (response.response.status === 400) {
                ToastError(response.response.data.message);
                displayApiErrors(response.response.data.errors);
            }
        }catch (error){
            console.error(error);
            ToastError("le serveur ne répond pas pour le moment, veuillez réessayer plus tard");
            return error
        }
    }
    const backgroundStyle = {
        backgroundImage: `url("/img/imgConnection.jpg")`,
    };

    return (
        <div>
            <div className="flex">
                <div className="flex flex-row w-full">
                    <ToastContainer
                        position="top-right"
                        autoClose={5000}
                        hideProgressBar={false}
                        newestOnTop={false}
                        closeOnClick
                        rtl={false}
                        pauseOnFocusLoss
                        draggable
                        pauseOnHover
                        theme="colored"
                    />

                    <div className="flex bg-image h-screen w-screen items-center justify-center backdrop-blur-xl  bg-cover bg-no-repeat"
                         style={backgroundStyle}>
                        <Link to="/public/home" className="bg-white absolute flex p-2 rounded-md m-5 bottom-[750px] left-0">
                            <img className="w-5 m-1" alt="icons_flèche_gauche" src="/img/icons/icons_flèche_gauche.png"></img>
                            <p className="m-1 font-medium ">Home</p>
                        </Link>
                        <div className="rounded-xl bg-gray-800 bg-white  w-[400px] flex justify-center mt-10 border-5 border-amber-gray-900  drop-shadow-xl backdrop-blur-md max-sm:px-8">
                            <div className="flex flex-1 flex-col justify-center space-y-5 max-w-md">

                                <div className="flex min-h-full flex-col justify-center px-6 py-12 lg:px-8">
                                    <div className="sm:mx-auto sm:w-full sm:max-w-sm">

                                        <img
                                            className="mx-auto w-16 w-auto"
                                            src="/img/icons/icons8-poterie-100.png"
                                            alt="Your Company"
                                        />
                                        <h2 className="mt-2 mb-0 text-center text-2xl font-bold leading-9 tracking-tight text-gray-900">
                                            Connectez-vous à votre compte
                                        </h2>
                                    </div>

                                    <div className="mt-10 sm:mx-auto sm:w-full sm:max-w-sm">
                                        <form className="space-y-6" onSubmit={handleLogin} >
                                            <div>
                                                <label
                                                    htmlFor="email"
                                                    className="block text-sm font-medium leading-6 text-gray-900"
                                                >
                                                    Adresse e-mail
                                                </label>
                                                <div className="mt-2">
                                                    <input
                                                        onChange={(e) => setEmail(e.target.value)}
                                                        id="email"
                                                        name="email"
                                                        type="email"
                                                        autoComplete="email"
                                                        placeholder="hamza88@gmail.com"
                                                        required
                                                        className="block h-10 p-3  w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset  sm:text-sm sm:leading-6"
                                                    />
                                                </div>
                                            </div>
                                            <div>
                                                <div className="flex items-center justify-between">
                                                    <label
                                                        htmlFor="password"
                                                        className="block text-sm font-medium leading-6 text-gray-900"
                                                    >
                                                        Password
                                                    </label>
                                                    <div className="text-sm">
                                                        <a
                                                            href="#"
                                                            className="font-semibold text-indigo-600 hover:text-indigo-500"
                                                        >
                                                            Forgot password?
                                                        </a>
                                                    </div>
                                                </div>
                                                <div className="mt-2">
                                                    <input
                                                        onChange={(e) => setPassword(e.target.value)}
                                                        id="password"
                                                        name="password"
                                                        type="password"
                                                        autoComplete="current-password"
                                                        placeholder="*********"
                                                        required
                                                        className="block p-3 h-10 w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset  sm:text-sm sm:leading-6"
                                                    />
                                                </div>
                                            </div>

                                            <div>
                                                <button
                                                    type="submit"
                                                    className="flex h-10 w-full justify-center rounded-md bg-black px-3 py-1.5 text-sm font-semibold leading-6 text-white shadow-sm  focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
                                                >
                                                    Se connecter
                                                </button>
                                            </div>
                                        </form>
                                        <p className="mt-10 text-center text-sm text-gray-500">
                                            Pas encore membre ?
                                            <Link to={"/register"}
                                               className="font-semibold leading-6 text-indigo-600 hover:text-indigo-500">  Inscrivez-vous maintenant</Link>
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        {/*<div className="rounded-xl bg-gray-800 bg-white px-16 py-10 mt-10 border-5 border-amber-gray-900  drop-shadow-xl backdrop-blur-md max-sm:px-8">
                        <div className="flex flex-1 flex-col  justify-center space-y-5 max-w-md">
                            <div className="flex flex-col space-y-2 text-center">
                                <h2 className="text-4xl md:text-4xl font-bold">Login</h2>
                            </div>
                            <div className="flex flex-col max-w-md space-y-2">
                                <p className="flex justify-start " >Email</p>
                                <input onChange={(e) => setEmail(e.target.value)} type="email" placeholder="Email" className="flex px-3 py-3 w-64  border-2  border-black rounded-lg font-medium placeholder:font-normal" />

                                <p className="flex justify-start">Password</p>
                                <input  onChange={(e) => setPassword(e.target.value)} type="password" placeholder="Password" className="flex  px-3 py-3 w-64 border-2 border-black rounded-lg font-medium placeholder:font-normal" />

                                <button onClick={handleLogin} className="flex items-center justify-center flex-none px-3 py-2 md:px-4 md:py-3 border-2 rounded-lg font-medium border-black bg-black text-white">Confirm</button>
                                <div className="flex justify-center items-center">
                                    <span className="w-full border border-black"></span>
                                    <span className="px-4">Or</span>
                                    <span className="w-full border border-black"></span>
                                </div>
                                <button className="flex items-center justify-center flex-none px-3 py-2 md:px-4 md:py-3 border-2 rounded-lg font-medium border-black relative">
              <span className="absolute left-4">
                <svg width="24px" height="24px" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg" xmlnsXlink="http://www.w3.org/1999/xlink">
                  <path fill="#EA4335 " d="M5.26620003,9.76452941 C6.19878754,6.93863203 8.85444915,4.90909091 12,4.90909091 C13.6909091,4.90909091 15.2181818,5.50909091 16.4181818,6.49090909 L19.9090909,3 C17.7818182,1.14545455 15.0545455,0 12,0 C7.27006974,0 3.1977497,2.69829785 1.23999023,6.65002441 L5.26620003,9.76452941 Z"/>
                  <path fill="#34A853" d="M16.0407269,18.0125889 C14.9509167,18.7163016 13.5660892,19.0909091 12,19.0909091 C8.86648613,19.0909091 6.21911939,17.076871 5.27698177,14.2678769 L1.23746264,17.3349879 C3.19279051,21.2936293 7.26500293,24 12,24 C14.9328362,24 17.7353462,22.9573905 19.834192,20.9995801 L16.0407269,18.0125889 Z"/>
                  <path fill="#4A90E2" d="M19.834192,20.9995801 C22.0291676,18.9520994 23.4545455,15.903663 23.4545455,12 C23.4545455,11.2909091 23.3454545,10.5272727 23.1818182,9.81818182 L12,9.81818182 L12,14.4545455 L18.4363636,14.4545455 C18.1187732,16.013626 17.2662994,17.2212117 16.0407269,18.0125889 L19.834192,20.9995801 Z"/>
                  <path fill="#FBBC05" d="M5.27698177,14.2678769 C5.03832634,13.556323 4.90909091,12.7937589 4.90909091,12 C4.90909091,11.2182781 5.03443647,10.4668121 5.26620003,9.76452941 L1.23999023,6.65002441 C0.43658717,8.26043162 0,10.0753848 0,12 C0,13.9195484 0.444780743,15.7301709 1.23746264,17.3349879 L5.27698177,14.2678769 Z"/>
              </svg>
              </span>
                                    <span>Sign in with Google</span>
                                </button>
                            </div>
                        </div>

                    </div>*/}
                </div>

            </div>
            </div>

        </div>
    );
}

export default Login;