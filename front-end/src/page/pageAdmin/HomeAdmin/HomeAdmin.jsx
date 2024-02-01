import React, { Fragment, useState } from 'react'
import { Dialog, Menu, Transition } from '@headlessui/react'
import {
    Bars3Icon,
    BellIcon,
    CalendarIcon,
    ChartPieIcon,
    Cog6ToothIcon,
    DocumentDuplicateIcon,
    FolderIcon,
    HomeIcon,
    UsersIcon,
    XMarkIcon,
} from '@heroicons/react/24/outline'
import { ChevronDownIcon, MagnifyingGlassIcon } from '@heroicons/react/20/solid'
import {
    BrowserRouter,
    Route,
    Routes,
    Navigate, useLocation, Link,
} from 'react-router-dom';
import ItemAdmin from '../itemAdmin/ItemAdmin';
import UserAdmin from '../userAdmin/UserAdmin';
import CommandeAdmin from '../commandeAdmin/CommandeAdmin';

const navigation = [
    { name: 'Dashboard', to: '/itemAdmin', icon: HomeIcon, current: false },
    { name: 'Produits', to: '/itemAdmin', icon: UsersIcon, current: false },
    { name: 'User', to: '/admin/userAdmin', icon: FolderIcon, current: false },
    { name: 'Commande', to: '/admin/commandeAdmin', icon: CalendarIcon, current: false },

]

const teams = [
    { id: 1, name: 'Heroicons', to: '#', initial: 'H', current: false },
    { id: 2, name: 'Tailwind Labs', to: '#', initial: 'T', current: false },
    { id: 3, name: 'Workcation', to: '#', initial: 'W', current: false },
]
const userNavigation = [
    { name: 'Your profile', to: '#' },
    { name: 'Sign out', to: '#' },
]

function classNames(...classes) {
    return classes.filter(Boolean).join(' ')
}

export default function HomeAdmin() {
    const [sidebarOpen, setSidebarOpen] = useState(false)
    const [currentNavItem, setCurrentNavItem] = useState(navigation[0]); // Set initial selected navigation item


    return (
        <>
            <div>
<p>dd</p>
            </div>
        </>

    )
}
