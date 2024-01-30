
import { CalendarDaysIcon, HandRaisedIcon } from '@heroicons/react/24/outline'
import {FaFacebookSquare, FaInstagramSquare, FaSnapchatSquare} from "react-icons/fa";
import React from "react";

export default function Header() {

    return (
        <div className="relative isolate overflow-hidden bg-gray-900 py-16 sm:py-5 lg:py-20">
            <div className="mx-auto max-w-7xl h-[80px] px-1 lg:px-8">
                <div className="mx-auto grid max-w-2xl grid-cols-1 gap-x-8 gap-y-16 lg:max-w-none lg:grid-cols-2">
                    <div className="max-w-xl lg:max-w-lg">
                        <div className="mt-6 flex max-w-md gap-x-4">
                            <label htmlFor="email-address" className="sr-only">
                                Email address
                            </label>
                            <input
                                id="email-address"
                                name="email"
                                type="email"
                                autoComplete="email"
                                required
                                className="min-w-0 flex-auto rounded-md border-0 bg-white/5 px-3.5 py-2 text-white shadow-sm ring-1 ring-inset ring-white/10 focus:ring-2 focus:ring-inset focus:ring-indigo-500 sm:text-sm sm:leading-6"
                                placeholder="Enter your email"
                            />
                            <button
                                type="submit"
                                className="flex-none rounded-md bg-indigo-500 px-3.5 py-2.5 text-sm font-semibold text-white shadow-sm hover:bg-indigo-400 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-500"
                            >
                                Subscribe
                            </button>
                        </div>
                    </div>
                    <dl className="grid grid-cols-1 gap-x-8 gap-y-10 sm:grid-cols-2 lg:pt-2 mt-2">
                        <div className="flex  items-start">
                            <div className="rounded-md bg-white/5 p-2 m-1 ring-1 ring-white/10">
                                <CalendarDaysIcon className="h-6 w-6 text-white" aria-hidden="true" />
                            </div>
                            <div className="rounded-md bg-white/5 p-2 m-1 ring-1 ring-white/10">
                                <FaSnapchatSquare className="h-6 w-6 text-white" aria-hidden="true" />
                            </div>
                            <div className="rounded-md bg-white/5 p-2 m-1 ring-1 ring-white/10">
                                <FaFacebookSquare className="h-6 w-6 text-white" aria-hidden="true" />
                            </div>
                            <div className="rounded-md bg-white/5 p-2 m-1 ring-1 ring-white/10">
                                <FaInstagramSquare  className="h-6 w-6 text-white" aria-hidden="true" />
                            </div>
                        </div>
                    </dl>
                </div>
            </div>
        </div>
    )
}
