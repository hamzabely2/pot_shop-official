import React, {useState} from 'react';
import {Link} from "react-router-dom";
import {removeCookie} from "../../service/useAuth";
import Cookies from "universal-cookie";

const NavBarMobile =() =>{
    const cookies = new Cookies();
    const [authenticated, setAuthenticated] = React.useState(!!cookies.get('token'));
    const [isDropdownOpen, setIsDropdownOpen] = React.useState(false);
    const [isUserMenuOpen, setIsUserMenuOpen] = useState(false);

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


    return (
        <div>
            {authenticated ? (

                <div className="ml-4 flex items-center md:ml-6">

                    <div className="relative ml-3">
                        <div className="flex justify-end">
                            <img
                                className="mr-5"
                                src="/img/icons/icons8-panier-32.png"
                                alt="image panier"
                            />

                            <button
                                type="button"
                                onClick={toggleUserMenu}
                                className="relative flex max-w-xs items-center rounded-full bg-gray-800 text-sm focus-outline-none focus-ring-2 focus-ring-white focus-ring-offset-2 focus-ring-offset-gray-800"
                                id="user-menu-button"
                                aria-expanded={isUserMenuOpen}
                                aria-haspopup="true"
                            >
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

            ) : (

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
            )}
        </div>
    );
}

export default NavBarMobile;