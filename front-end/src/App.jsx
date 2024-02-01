import React from "react";
import './App.css';
import Login from './connection/login/Login';
import Home from "./page/pagePublic/home/Home.jsx";
import {
    BrowserRouter,
    Route,
    Routes,
    Navigate, useLocation,
} from 'react-router-dom';
import Register from "./connection/register/Register";
import Nous from "./page/pagePublic/Nous/Nous.jsx";
import Error404 from "./page/pagePublic/page404/Error404";
import { ProtectedRoute } from "./route/Route";
import Profile from "./page/pageUser/profile/Profile";
import HomeAdmin from "./page/pageAdmin/HomeAdmin/HomeAdmin";
import Contact from "./components/contact/Contact.jsx";
import ItemDetails from "./page/pagePublic/itemdetails/ItemDetails";
import Collection from "./page/pagePublic/collection/Collection";
import Item from "./page/pagePublic/item/Item";
import NavBar from './components/navBar/NavBar';
import NavBarAdmin from './page/pageAdmin/navBarAdmin/NavBarAdmin';
import NavBarChooser from './components/navBar/NavBarChooser';
import ItemAdmin from './page/pageAdmin/itemAdmin/ItemAdmin';
import UserAdmin from './page/pageAdmin/userAdmin/UserAdmin';
import CommandeAdmin from './page/pageAdmin/commandeAdmin/CommandeAdmin';


function App() {

    return (

        <BrowserRouter>
          <NavBarChooser/>
          <Routes>
            <Route path="/"  element={<Home />} />
            <Route path="/public/home"  element={<Home />} />
            <Route path="/public/nous" element={<Nous/>} />
            <Route path="/register" element={<Register />} />
            <Route path="/login" element={<Login/>} />
            <Route path="/public/profile" element={<Profile />} />
            <Route path="/public/contact" element={<Contact />} />
            <Route path="/public/itemDetails/:id" element={<ItemDetails />} />
            <Route path="/public/collection" element={<Collection />} />
            <Route path="/public/item" element={<Item />} />



          </Routes>
        </BrowserRouter>
    );
}

export default App;
