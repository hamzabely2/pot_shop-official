import React, { Fragment, useState  } from 'react';
import { Dialog, Transition } from '@headlessui/react';
import {LuShoppingCart} from "react-icons/lu";

const Cart = ({ isOpen, openModal, closeModal }) => {



    return (
        <>
            <button
                onClick={openModal}
                className="relative rounded-full p-1 text-gray-400 focus:outline-none focus:ring-2 focus:ring-white focus:ring-offset-2 focus:ring-offset-gray-40"
            >
                <LuShoppingCart className="" style={{}} />
            </button>

            <Transition.Root show={isOpen} as={Fragment}>
                <Dialog
                    as="div"
                    className="fixed inset-0 overflow-hidden"
                    onClose={closeModal}
                >
                    <div className="absolute inset-0 overflow-hidden">
                        <div className="pointer-events-none fixed inset-y-0 right-0 flex max-w-full pl-10">
                            <div className="pointer-events-auto w-screen max-w-md">
                                <div className="flex h-full flex-col overflow-y-scroll bg-white shadow-xl">
                                    <div className="flex-1 overflow-y-auto px-4 py-6 sm:px-6">
                                        <div className="flex items-start justify-between">
                                            <h2 className="text-lg font-medium text-gray-900" id="slide-over-title">Panier</h2>
                                            <div className="ml-3 flex h-7 items-center">
                                                <button
                                                    type="button"
                                                    className="relative -m-2 p-2 text-gray-400 hover:text-gray-500"
                                                    onClick={closeModal}
                                                >
                                                    <span className="absolute -inset-0.5"></span>
                                                    <span className="sr-only"></span>
                                                    <svg className="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" aria-hidden="true">
                                                        <path stroke-linecap="round" stroke-linejoin="round" d="M6 18L18 6M6 6l12 12" />
                                                    </svg>
                                                </button>
                                            </div>
                                        </div>

                                        <div className="mt-8">
                                            <div className="flow-root">
                                                <ul role="list" className="-my-6 divide-y divide-gray-200">
                                                    <p>list des produits</p>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>

                                    <div className="border-t border-gray-200 px-4 py-6 sm:px-6">
                                        <div className="flex justify-between text-base font-medium text-gray-900">
                                            <p>Total</p>
                                            <p>$0</p>
                                        </div>
                                        <p className="mt-0.5 text-sm text-gray-500">Frais de port et taxes calculés à la caisse.</p>
                                        <div className="mt-6">
                                            <a href="#" className="flex items-center justify-center rounded-md border border-transparent bg-indigo-600 px-6 py-3 text-base font-medium text-white shadow-sm hover:bg-indigo-700">Checkout</a>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </Dialog>
            </Transition.Root>
        </>
    );
};

export default Cart;
