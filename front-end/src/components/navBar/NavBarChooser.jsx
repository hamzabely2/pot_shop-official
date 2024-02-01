import React from 'react';
import { useLocation } from "react-router-dom";
import NavBar from './NavBar';
import NavBarAdmin from '../../page/pageAdmin/navBarAdmin/NavBarAdmin';

function NavBarChooser() {
  const location = useLocation();
  let header
if(location.pathname.split("/")[1] === "admin" ){
header = <NavBarAdmin/>
}else if(location.pathname.split("/")[1] === "public"){
 header = <NavBar/>
}else if (location.pathname.split("/")[1] === "public"){
  header = <></>
}

  return header;
}

export default NavBarChooser;