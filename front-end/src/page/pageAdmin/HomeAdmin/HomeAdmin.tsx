import React from 'react';

const HomeAdmin = () => {
    return (
        <div>
            <nav className="bg-blue-500 p-4 flex items-center justify-between">
                <div>
                    <h1 className="text-white text-xl font-semibold">SALUD 360</h1>
                </div>
                <div className="flex items-center space-x-4">
                    <span className="text-white">Bienvenido</span>
                    <i className="fas fa-user-circle text-white text-2xl"></i>
                </div>
            </nav>

            <aside className="bg-gray-800 text-white w-64 min-h-screen p-4">
                <nav>
                    <ul className="space-y-2">
                        <li className="opcion-con-desplegable">
                            <div className="flex items-center justify-between p-2 hover:bg-gray-700">
                                <div className="flex items-center">
                                    <i className="fas fa-calendar-alt mr-2"></i>
                                    <span>Agenda</span>
                                </div>
                                <i className="fas fa-chevron-down text-xs"></i>
                            </div>
                            <ul className="desplegable ml-4 hidden">
                                <li>
                                    <a href="src/page/pageUser#" className="block p-2 hover:bg-gray-700 flex items-center">
                                        <i className="fas fa-chevron-right mr-2 text-xs"></i>
                                        Gestion de citas
                                    </a>
                                </li>
                                <li>
                                    <a href="src/page/pageUser#" className="block p-2 hover:bg-gray-700 flex items-center">
                                        <i className="fas fa-chevron-right mr-2 text-xs"></i>
                                        Polizas
                                    </a>
                                </li>
                            </ul>
                        </li>
                        <li className="opcion-con-desplegable">
                            <div className="flex items-center justify-between p-2 hover:bg-gray-700">
                                <div className="flex items-center">
                                    <i className="fas fa-money-bill-wave mr-2"></i>
                                    <span>Contabilidad</span>
                                </div>
                                <i className="fas fa-chevron-down text-xs"></i>
                            </div>
                            <ul className="desplegable ml-4 hidden">
                                <li>
                                    <a href="src/page/pageUser#" className="block p-2 hover:bg-gray-700 flex items-center">
                                        <i className="fas fa-chevron-right mr-2 text-xs"></i>
                                        Tratamientos
                                    </a>
                                </li>
                                <li>
                                    <a href="src/page/pageUser#" className="block p-2 hover:bg-gray-700 flex items-center">
                                        <i className="fas fa-chevron-right mr-2 text-xs"></i>
                                        Gastos
                                    </a>
                                </li>
                                <li>
                                    <a href="src/page/pageUser#" className="block p-2 hover:bg-gray-700 flex items-center">
                                        <i className="fas fa-chevron-right mr-2 text-xs"></i>
                                        Facturas
                                    </a>
                                </li>
                            </ul>
                        </li>
                        <li className="opcion-con-desplegable">
                            <div className="flex items-center justify-between p-2 hover:bg-gray-700">
                                <div className="flex items-center">
                                    <i className="fas fa-chart-bar mr-2"></i>
                                    <span>Informes</span>
                                </div>
                                <i className="fas fa-chevron-down text-xs"></i>
                            </div>
                            <ul className="desplegable ml-4 hidden">
                                <li>
                                    <a href="src/page/pageUser#" className="block p-2 hover:bg-gray-700 flex items-center">
                                        <i className="fas fa-chevron-right mr-2 text-xs"></i>
                                        Presupuestos
                                    </a>
                                </li>
                                <li>
                                    <a href="src/page/pageUser#" className="block p-2 hover:bg-gray-700 flex items-center">
                                        <i className="fas fa-chevron-right mr-2 text-xs"></i>
                                        Informe médico
                                    </a>
                                </li>
                            </ul>
                        </li>
                        <li className="opcion-con-desplegable">
                            <div className="flex items-center justify-between p-2 hover:bg-gray-700">
                                <div className="flex items-center">
                                    <i className="fas fa-file-alt mr-2"></i>
                                    <span>Documentación</span>
                                </div>
                                <i className="fas fa-chevron-down text-xs"></i>
                            </div>
                            <ul className="desplegable ml-4 hidden">
                                <li>
                                    <a href="src/page/pageUser#" className="block p-2 hover:bg-gray-700 flex items-center">
                                        <i className="fas fa-chevron-right mr-2 text-xs"></i>
                                        Firmas pendientes
                                    </a>
                                </li>
                                <li>
                                    <a href="src/page/pageUser#" className="block p-2 hover:bg-gray-700 flex items-center">
                                        <i className="fas fa-chevron-right mr-2 text-xs"></i>
                                        Documentos
                                    </a>
                                </li>
                            </ul>
                        </li>
                    </ul>
                </nav>
            </aside>
        </div>
    );
};

export default HomeAdmin;