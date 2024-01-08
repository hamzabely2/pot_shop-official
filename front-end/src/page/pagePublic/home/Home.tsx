import React from 'react';
import  ".//Home.css";
import PointFort from "../pointFort/PointFort";
import Item from "../item/Item";
import {ToastContainer} from "react-toastify";
import Header from "../../../components/header/Header";
import {Link} from "react-router-dom";
import NavBar from "../../../components/navBar/NavBar";



const Home = () => {
    const backgroundStyle = {
        backgroundImage: `url(https://images.pexels.com/photos/7718448/pexels-photo-7718448.jpeg?auto=compress&cs=tinysrgb&w=1600)`,

    };
    return (
        <div>
            <NavBar/>
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
                <div className="">
                    <div className="bg-white">
                        <div className=" xl:px-14">
                            <div style={backgroundStyle}
                                className="overflow-hidden bg-gradient-to-r from-amber-700 to-amber-900 shadow-m sm:rounded-3xl sm:px-20 md:pt-50 lg:flex lg:gap-x-20 lg:px-24 lg:pt0">
                                <div
                                    className="mx-auto max-w-md text-center lg:mx-0 lg:flex-auto lg:py-32 lg:text-left">
                                    <h2 className="text-3xl font-bold tracking-tight text-white sm:text-4xl">Cree ton vase maintenant.<br/>avec les 1000 posiibilite</h2>
                                    <p className="mt-6 text-lg leading-8 text-gray-300"></p>
                                    <div className="mt-10 flex items-center justify-center gap-x-6 lg:justify-start">
                                        <a href="src/page#"
                                           className="rounded-md bg-white px-3.5 py-2.5 text-sm font-semibold text-gray-900 shadow-sm hover:bg-gray-100 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-white">commencer</a>
                                        <a href="src/page#" className="text-sm font-semibold leading-6 text-white">Learn
                                            more <span aria-hidden="true">→</span></a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                 <PointFort/>
                <Item/>
                    <div className="flex justify-center shadow-xl ">
                    <div className="max-w-2xl flex justify-center m-7  bg-white rounded-md shadow-md overflow-hidden md:max-w-7xl">
                        <div className="md:flex">
                            <div className="md:shrink-0">
                                <video className="h-[350px] max-w  mx-auto " loop autoPlay muted>
                                    <source src="/video/production.mp4" type="video/mp4"/>
                                    Votre navigateur ne prend pas en charge la vidéo.
                                </video >
                            </div>
                            <div className="p-8">
                                <div className="uppercase tracking-wide text-sm text-indigo-500 font-semibold">Company
                                    retreats
                                </div>
                                <Link to={"/"}
                                   className="block mt-1 text-lg leading-tight font-medium text-black hover:underline">Incredible
                                    accommodation for your team</Link>
                                <p className="mt-2 text-slate-500">Looking to take your team away on a retreat to enjoy
                                    awesome food and take in some sunshine? We have a list of places to do just
                                    that.</p>
                            </div>
                        </div>
                    </div>
                    </div>
               <Header/>
            </div>
        </div>
    );
};

export default Home;