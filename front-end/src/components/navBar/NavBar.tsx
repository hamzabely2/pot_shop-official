import React, {useState} from 'react';
import './NavBar.css'
import { Link } from "react-router-dom";
import Cookies from 'universal-cookie';
import {removeCookie} from "../../service/useAuth";
import Home from "../../page/pagePublic/home/Home";
import NavBarMobile from "../navBarMobile/NavBarMobile";

const NavBar :  React.FC  = () => {
    const cookies = new Cookies();
    const [authenticated, setAuthenticated] = React.useState(!!cookies.get('token'));
    const [isDropdownOpen, setIsDropdownOpen] = React.useState(false);
    const [isMenuOpen, setIsMenuOpen] = useState(false);
    const [isUserMenuOpen, setIsUserMenuOpen] = useState(false);
    const [isMobileMenuOpen, setIsMobileMenuOpen] = useState(false);


    const token = cookies.get('token');
    const logout = () => {
        removeCookie("token");
        setIsDropdownOpen(!isDropdownOpen)

        setAuthenticated(false);
        localStorage.removeItem('token');
    };

    React.useEffect(() => {
        const handleCookieChange = () => {
            setAuthenticated(!!cookies.get('token'));
        };
        cookies.addChangeListener(handleCookieChange);
        return () => {
            cookies.removeChangeListener(handleCookieChange);
        };
    }, []);


    const toggleUserMenu = () => {
        setIsUserMenuOpen(!isUserMenuOpen);
    };


    const toggleMobileMenu = () => {
        setIsMobileMenuOpen(!isMobileMenuOpen);
    };

    return (
        <div className="">

            <div className="relative text-white isolate bg-black  flex items-center gap-x-6 overflow-hidden  px-6 py-2.5 sm:px-3.5 sm:before:flex-1">
                <div className="text-white bg-black top-1/2 -z-10  transform-gpu blur-2xl" aria-hidden="true">
                </div>
                <div className="absolute  bg-black  top-1/2 -z-10 -translate-y-1/2 transform-gpu blur-2xl" aria-hidden="true">
                    <div className="aspect-[577/310] w-[36.0625rem] bg-black " ></div>
                </div>
                <div className="flex flex-wrap items-center gap-x-4 gap-y-2">
                    <p className="text-sm leading-6  text-white">
                        <strong className="font-semibold text-white">Pot shop 2024</strong>
                        <svg viewBox="0 0 2 2" className="mx-2 inline h-0.5 w-0.5 fill-current" aria-hidden="true">
                            <circle cx="1" cy="1" r="1" />
                        </svg>
                      Rejoignez-nous à Denver du 7 au 9 juin pour voir ce qui va suivre.
                    </p>
                    <Link to="/register" className="flex-none rounded-full bg-white text-black px-3.5 py-1 text-sm font-semibold  shadow-sm  focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2">
                        Profitez de cette promotion <span aria-hidden="true">&rarr;</span>
                    </Link>
                </div>
                <div className="flex flex-1 justify-end">
                    <button type="button" className="-m-3 p-3 focus-visible:outline-offset-[-4px]">
                        <span className="sr-only">Dismiss</span>
                        <svg className="h-5 w-5 text-gray-900" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
                            <path d="M6.28 5.22a.75.75 0 00-1.06 1.06L8.94 10l-3.72 3.72a.75.75 0 101.06 1.06L10 11.06l3.72 3.72a.75.75 0 101.06-1.06L11.06 10l3.72-3.72a.75.75 0 00-1.06-1.06L10 8.94 6.28 5.22z" />
                        </svg>
                    </button>
                </div>
            </div>

        <div className="min-h-full mb-2 ">
            <nav className="">
                <div className="mx-auto max-w-7xl px-4 sm:px-6 lg:px-8">
                    <div className="flex h-16  items-center justify-between">
                        <div className="flex items-center">
                            <div className="flex-shrink-0">
                                <img
                                    className="h-8 w-8 logo"
                                    src=""
                                    alt="Pot Shop"
                                />
                            </div>
                            <div className="hidden md:block">
                                <div className="ml-10 flex items-baseline space-x-4">
                                    <Link
                                        to={"/"}
                                        className="rounded-md px-3 py-2 text-m font-medium"
                                        aria-current="page"
                                    >
                                        Home
                                    </Link>
                                    <Link to={"/collection"}
                                        className="rounded-md px-3 py-2 text-m font-medium"
                                    >
                                        collection
                                    </Link>
                                    <Link
                                        to={"/contact"}
                                        className="rounded-md px-3 py-2 text-m font-medium"
                                    >
                                        contact
                                    </Link>
                                        {!authenticated ? (
                                            <div className="flex">
                                            <span className="rounded-md text-m font-medium">plus sur les pots</span>
                                            <img className="w-5 h-5"  alt="image serrure fermée" src="/img/icons/icons_cadenas.png"/>
                                            </div>
                                            ) : (
                                            <Link
                                                to={"/nous"}
                                                className="rounded-md text-m font-medium"
                                            >
                                                plus sur les pots
                                            </Link>
                                        )}
                                </div>
                            </div>
                        </div>
                        {authenticated &&
                        <div className="relative inline-block text-left">
                            <div className="ml-4 flex items-center md:ml-6">

                                <div className="relative ml-3">
                                    <div className="flex">
                                      <img
                                          className="mr-5"
                                          src="/img/icons/icons8-panier-32.png"
                                          alt=""
                                      />

                                        <button
                                            type="button"
                                            onClick={toggleUserMenu}
                                            className="relative flex max-w-xs items-center rounded-full bg-gray-800 text-sm focus-outline-none focus-ring-2 focus-ring-white focus-ring-offset-2 focus-ring-offset-gray-800"
                                            id="user-menu-button"
                                            aria-expanded={isUserMenuOpen}
                                            aria-haspopup="true"
                                        >
                                            <span className="absolute -inset-1.5"></span>
                                            <span className="sr-only">Open user menu</span>
                                            <img
                                                className="h-8 w-8 rounded-full"
                                                src="https://images.unsplash.com/photo-1472099645785-5658abf4ff4e?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80"
                                                alt=""
                                            />
                                        </button>

                                    </div>
                                    {isUserMenuOpen &&
                                    <div
                                        className={`absolute right-0 z-10 mt-2 w-48 origin-top-right rounded-md bg-white py-1 shadow-lg ring-1 ring-black ring-opacity-5 focus-outline-none ${
                                            isUserMenuOpen ? 'transform opacity-100 scale-100' : 'transform opacity-0 scale-95'
                                        }`}
                                        role="menu"
                                        aria-orientation="vertical"
                                        aria-labelledby="user-menu-button"
                                    >
                                        <a
                                            href="src/components#"
                                            className="block px-4 py-2 text-sm text-gray-700"
                                            role="menuitem"
                                        >
                                            Your Profile
                                        </a>
                                        <a
                                            href="src/components#"
                                            className="block px-4 py-2 text-sm text-gray-700"
                                            role="menuitem"
                                        >
                                            Settings
                                        </a>
                                        <button type="button"
                                          onClick={logout}
                                            className="block px-4 py-2 text-sm text-gray-700"
                                            role="menuitem"
                                        >
                                            Sign out
                                        </button>
                                    </div>
                                    }
                                </div>
                            </div>
                        </div>
                        }
                        {!authenticated &&
                            <div className="hidden md:block">
                              <div className="ml-10 flex items-baseline space-x-4">
                            <Link
                                to={"/login"}
                                className="rounded-md px-3 py-2 text-m font-medium"
                            >
                              login
                            </Link>
                                <Link
                                    to={"/register"}
                                    className="rounded-md px-3 py-2 text-m font-medium"
                                >
                                  register
                                </Link>
                              </div>
                            </div>
                        }
                        <div className="-mr-2  md:hidden">
                            <button
                                type="button"
                                onClick={toggleMobileMenu}
                                className="relative inline-flex items-center justify-center rounded-md bg-gray-800 p-2 text-gray-400 hover:bg-gray-700 hover:text-white focus:outline-none focus:ring-2 focus:ring-white focus:ring-offset-2 focus:ring-offset-gray-800"
                                aria-controls="mobile-menu"
                            >
                                <svg
                                    className="w-6 h-6"
                                    fill="none"
                                    viewBox="0 0 24 24"
                                    stroke="currentColor"
                                >
                                {isMobileMenuOpen ? (
                                    <path
                                        strokeLinecap="round"
                                        strokeLinejoin="round"
                                        d="M6 18L18 6M6 6l12 12"
                                    />
                                ) : (
                                    <path
                                        strokeLinecap="round"
                                        strokeLinejoin="round"
                                        d="M4 6h16M4 12h16M4 18h16"
                                    />
                                )}
                                </svg>
                            </button>
                        </div>
                    </div>

                </div>

                    {isMobileMenuOpen && (
                   <div className="md:hidden"
                    id="mobile-menu">
                    <div className="space-y-1 px-2 pb-3 pt-2 sm:px-3">

                        <Link
                            to={"/"}
                            className="rounded-md px-3 py-2 text-m font-medium"
                            aria-current="page"
                        >
                            Home
                        </Link>
                        <Link to={"/collection"}
                              className="rounded-md px-3 py-2 text-m font-medium"
                        >
                            collection
                        </Link>
                        <Link
                            to={"/contact"}
                            className="rounded-md px-3 py-2 text-m font-medium"
                        >
                            contact
                        </Link>
                            {!authenticated ? (
                                <div className="flex justify-center">
                                    <span className="rounded-md text-m font-medium"> pots</span>
                                    <img className="w-5 h-5"  alt="image serrure fermée" src="/img/icons/icons_cadenas.png"/>
                                </div>
                            ) : (
                                <Link
                                    to={"/nous"}
                                    className="rounded-md text-m font-medium"
                                >
                                    pots
                                </Link>
                            )}
                        <NavBarMobile/>
                    </div>

                   </div>
                    )}
            </nav>
        </div>
    </div>
    );
};

export default NavBar;