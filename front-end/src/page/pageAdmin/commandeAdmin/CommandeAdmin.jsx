import { Fragment } from 'react'
import {
  BriefcaseIcon,
  CalendarIcon,
  CheckIcon,
  ChevronDownIcon,
  CurrencyDollarIcon,
  LinkIcon,
  MapPinIcon,
  PencilIcon,
} from '@heroicons/react/20/solid'
import { Menu, Transition } from '@headlessui/react'
import NavBarAdmin from '../navBarAdmin/NavBarAdmin';

const people = [
  {
    name: 'Leslie Alexander',
    email: 'leslie.alexander@example.com',
    role: 'Co-Founder / CEO',
    imageUrl:
        'https://images.unsplash.com/photo-1494790108377-be9c29b29330?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80',
    lastSeen: '3h ago',
    lastSeenDateTime: '2023-01-23T13:23Z',
  },
  {
    name: 'Michael Foster',
    email: 'michael.foster@example.com',
    role: 'Co-Founder / CTO',
    imageUrl:
        'https://images.unsplash.com/photo-1519244703995-f4e0f30006d5?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80',
    lastSeen: '3h ago',
    lastSeenDateTime: '2023-01-23T13:23Z',
  },
  {
    name: 'Dries Vincent',
    email: 'dries.vincent@example.com',
    role: 'Business Relations',
    imageUrl:
        'https://images.unsplash.com/photo-1506794778202-cad84cf45f1d?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80',
    lastSeen: null,
  },
  {
    name: 'Lindsay Walton',
    email: 'lindsay.walton@example.com',
    role: 'Front-end Developer',
    imageUrl:
        'https://images.unsplash.com/photo-1517841905240-472988babdf9?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80',
    lastSeen: '3h ago',
    lastSeenDateTime: '2023-01-23T13:23Z',
  },
  {
    name: 'Courtney Henry',
    email: 'courtney.henry@example.com',
    role: 'Designer',
    imageUrl:
        'https://images.unsplash.com/photo-1438761681033-6461ffad8d80?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80',
    lastSeen: '3h ago',
    lastSeenDateTime: '2023-01-23T13:23Z',
  },
  {
    name: 'Tom Cook',
    email: 'tom.cook@example.com',
    role: 'Director of Product',
    imageUrl:
        'https://images.unsplash.com/photo-1472099645785-5658abf4ff4e?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80',
    lastSeen: null,
  },
]


export default function CommandeAdmin() {
  return (
      <div>
        <NavBarAdmin/>
        <div className="container mx-auto p-5">
          <div className="lg:flex lg:items-center lg:justify-between ">
            <div className="min-w-0 flex-1">
              <h2 className="text-2xl font-bold leading-7 text-gray-900 sm:truncate sm:text-3xl sm:tracking-tight">
                Back End Developer
              </h2>
              <div className="mt-1 flex flex-col sm:mt-0 sm:flex-row sm:flex-wrap sm:space-x-6">
                <div className="mt-2 flex items-center text-sm text-gray-500">
                  <BriefcaseIcon className="mr-1.5 h-5 w-5 flex-shrink-0 text-gray-400" aria-hidden="true" />
                  Full-time
                </div>
                <div className="mt-2 flex items-center text-sm text-gray-500">
                  <MapPinIcon className="mr-1.5 h-5 w-5 flex-shrink-0 text-gray-400" aria-hidden="true" />
                  Remote
                </div>
                <div className="mt-2 flex items-center text-sm text-gray-500">
                  <CurrencyDollarIcon className="mr-1.5 h-5 w-5 flex-shrink-0 text-gray-400" aria-hidden="true" />
                  $120k &ndash; $140k
                </div>
                <div className="mt-2 flex items-center text-sm text-gray-500">
                  <CalendarIcon className="mr-1.5 h-5 w-5 flex-shrink-0 text-gray-400" aria-hidden="true" />
                  Closing on January 9, 2020
                </div>
              </div>
            </div>
            <div className="mt-5 flex lg:ml-4 lg:mt-0">
        <span className="hidden sm:block">
          <button
              type="button"
              className="inline-flex items-center rounded-md bg-white px-3 py-2 text-sm font-semibold text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 hover:bg-gray-50"
          >
            <PencilIcon className="-ml-0.5 mr-1.5 h-5 w-5 text-gray-400" aria-hidden="true" />
            Edit
          </button>
        </span>

              <span className="ml-3 hidden sm:block">
          <button
              type="button"
              className="inline-flex items-center rounded-md bg-white px-3 py-2 text-sm font-semibold text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 hover:bg-gray-50"
          >
            <LinkIcon className="-ml-0.5 mr-1.5 h-5 w-5 text-gray-400" aria-hidden="true" />
            View
          </button>
        </span>

              <span className="sm:ml-3">
          <button
              type="button"
              className="inline-flex items-center rounded-md bg-indigo-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
          >
            <CheckIcon className="-ml-0.5 mr-1.5 h-5 w-5" aria-hidden="true" />
            Publish
          </button>
        </span>

              <Menu as="div" className="relative ml-3 sm:hidden">
                <Menu.Button className="inline-flex items-center rounded-md bg-white px-3 py-2 text-sm font-semibold text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 hover:ring-gray-400">
                  More
                  <ChevronDownIcon className="-mr-1 ml-1.5 h-5 w-5 text-gray-400" aria-hidden="true" />
                </Menu.Button>

                <Transition
                    as={Fragment}
                    enter="transition ease-out duration-200"
                    enterFrom="transform opacity-0 scale-95"
                    enterTo="transform opacity-100 scale-100"
                    leave="transition ease-in duration-75"
                    leaveFrom="transform opacity-100 scale-100"
                    leaveTo="transform opacity-0 scale-95"
                >
                  <Menu.Items className="absolute right-0 z-10 -mr-1 mt-2 w-48 origin-top-right rounded-md bg-white py-1 shadow-lg ring-1 ring-black ring-opacity-5 focus:outline-none">
                    <Menu.Item>
                      {({ active }) => (
                          <a
                              href="#"
                              className={`${active ? 'bg-gray-100' : ''}'block px-4 py-2 text-sm text-gray-700`}
                          >
                            Edit
                          </a>
                      )}
                    </Menu.Item>
                    <Menu.Item>
                      {({ active }) => (
                          <a
                              href="#"
                              className={`${active ? 'bg-gray-100' : ''} block px-4 py-2 text-sm text-gray-700`}
                          >
                            View
                          </a>
                      )}
                    </Menu.Item>
                  </Menu.Items>
                </Transition>
              </Menu>
            </div>
          </div>
          <div>
            <ul role="list" className="divide-y divide-gray-100">
              {people.map((person) => (
                  <li key={person.email} className="flex justify-between gap-x-6 py-5">
                    <div className="flex min-w-0 gap-x-4">
                      <img className="h-12 w-12 flex-none rounded-full bg-gray-50" src={person.imageUrl} alt="" />
                      <div className="min-w-0 flex-auto">
                        <p className="text-sm font-semibold leading-6 text-gray-900">{person.name}</p>
                        <p className="mt-1 truncate text-xs leading-5 text-gray-500">{person.email}</p>
                      </div>
                    </div>
                    <div className="hidden shrink-0 sm:flex sm:flex-col sm:items-end">
                      <p className="text-sm leading-6 text-gray-900">{person.role}</p>
                      {person.lastSeen ? (
                          <p className="mt-1 text-xs leading-5 text-gray-500">
                            Last seen <time dateTime={person.lastSeenDateTime}>{person.lastSeen}</time>
                          </p>
                      ) : (
                          <div className="mt-1 flex items-center gap-x-1.5">
                            <div className="flex-none rounded-full bg-emerald-500/20 p-1">
                              <div className="h-1.5 w-1.5 rounded-full bg-emerald-500" />
                            </div>
                            <p className="text-xs leading-5 text-gray-500">Online</p>
                          </div>
                      )}
                    </div>
                  </li>
              ))}
            </ul>
          </div>
        </div>
      </div>
  )
}
