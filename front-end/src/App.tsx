import React from "react";
import './App.css';
import Login from './connection/login/Login'
import Home from "./page/pagePublic/home/Home";
import {BrowserRouter,Route,Routes} from 'react-router-dom'
import Register from "./connection/register/Register";
import Nous from "./page/pagePublic/Nous/Nous";
import Error404 from "./page/pagePublic/page404/Error404";
import {ProtectedRoute} from "./route/Route";
import { User } from './route/Route';
import NavBar from "./components/navBar/NavBar";
import {Token} from "./service/useAuth";
import Profile from "./page/pageUser/profile/Profile";
import HomeAdmin from "./page/pageAdmin/HomeAdmin/HomeAdmin";
import Contact from "./components/contact/Contact";
import ItemDetails from "./page/pagePublic/itemdetails/ItemDetails";
function App() {

    let user = Token()
    let role
    if(user) role = user["role"]
    let item : any

    return (
        <div className="App">
        <BrowserRouter>
            <Routes>
                <Route path='/' element={<Home />}/>
                <Route path="/nous" element={<ProtectedRoute role={role} allowedRoles={["User"]} component={Nous} />}/>
                <Route path="/register" element={<ProtectedRoute role={role} allowedRoles={["visitor"]} component={Register}/>}/>
                <Route path="/login" element={<ProtectedRoute role={role} allowedRoles={["visitor"]} component={Login}/>}/>
                <Route path='/*' element={<Error404/>}/>
                <Route path='/profile' /*element={<ProtectedRoute role={role} allowedRoles={["User"]} component={Profile}*/ element={<Profile/>}/>
                <Route path='/admin' element={<HomeAdmin/>}/>
                <Route path='/contact' element={<Contact/>}/>
                <Route path='/itemDetails/:id' element={<ItemDetails />}/>

            </Routes>
         </BrowserRouter>
    </div>
  );
}

export default App;
