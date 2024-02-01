import React, {useEffect, useState} from 'react';
import {GetAllItem} from "../../../service/ServiceItem";
import {Link} from "react-router-dom";
import SkeletonItem from "../../../components/skeletons/SkeletonItem";


const  ItemHome = () => {
    const { data, loading, error } = GetAllItem();

    if (loading) {
        return <SkeletonItem/>;
    }

    if (error) {
        return (
            <div >
                <div className="flex justify-center">
                    <h1 className="text-xl text-white mt-2 bg-red-600 w-96 m-3 rounded-md">le serveur ne répond pas pour le moment, veuillez réessayer plus tard</h1>
                </div>
                    <SkeletonItem/>
            </div>
      )
    }
    return (
        <div>
            <div className="relative justify-center flex items-center">
                <div className=""><img alt="decoration" className="w-40 mr-4" src="/img/decoration/decoration_right.jpg"></img></div>
                <h2 className="text_nav leading-7 text-gray-950 sm:truncate sm:text-3xl sm:tracking-tight">Notre produits</h2>
                <div className=""><img alt="decoration" className="w-40 ml-4" src="/img/decoration/decoration_left.jpg"/></div>
            </div>
                <div className="mx-auto sm:px-40 sm:py-10">
                    <div className="grid grid-cols-2 gap-x-6 gap-y-5 sm:grid-cols-3 lg:grid-cols-4 xl:grid-cols-5 xl:gap-x-12">
                        {data.map((item ) => (
                            <Link  to={`/itemDetails/${item.id}`} state={{item :item}} >
                                <div className="aspect-h-1 aspect-w-1 w-full overflow-hidden rounded-lg bg-gray-200 xl:aspect-h-8 xl:aspect-w-7">
                                    <img
                                        src={item.image}
                                        alt={item.name}
                                        className="h-full w-full object-cover object-center group-hover:opacity-75"
                                    />
                                    <div className="relative cursor-pointer gap-4 flex justify-center bg-white">
                                        <div
                                            className="w-7 h-7 bg-[#f6cda8] transition-all rounded-full block ring-[#f6cda8] hover:ring-2 ring-offset-1 "></div>
                                        <div
                                            className="w-7 h-7 bg-[#d89d94] transition-all rounded-full block ring-[#d89d94] hover:ring-2 ring-offset-1 "></div>
                                        <div
                                            className="w-7 h-7 bg-[#dd6b6c] transition-all rounded-full block ring-[#dd6b6c] hover:ring-2 ring-offset-1 "></div>
                                    </div>

                                </div>
                                <h3 className="mt-4 text-md text-gray-700">{item.name}</h3>
                                <p className="mt-1 text-lg font-medium text-gray-900">{item.price}$</p>
                            </Link>
                        ))}
                    </div>
                </div>
        </div>
    );
};

export default ItemHome;