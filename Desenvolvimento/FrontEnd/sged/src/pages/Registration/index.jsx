import React from "react";
import NavBar from "../../components/NavBar";
import SideBar from "../../components/SideBar";
import ImgEstado from "../../assets/ImgEstado.png";
import ImgCidade from "../../assets/ImgCidade.png";
import ImgUsuario from "../../assets/ImgUsuario.png";
import { Link } from "react-router-dom";

export default function Registrations() {
    return (
        <div style={{ display: 'flex', flexDirection: 'column', height: '100%' }}>
            <NavBar /> {/* NavBar no topo */}
            <div style={{ display: 'flex', flex: 1 }}> {/* Container principal flexível */}
                <div style={{ flex: 0, width: '200px' }}>
                    <SideBar /> {/* Sidebar à esquerda */}
                </div>
                <div style={{ flex: 2, marginLeft: '80px', marginRight: '40px', marginTop: -5 }}>
                    <br />
                    <h3 className="text-2xl font-semibold text-gray-600">Cadastros</h3>
                    <div className="bg-slate-200 rounded-md" style={{ marginTop: 15 }}>
                        <h4 className="pl-4 pt-2 pb-2 text-gray-500">Funções</h4>
                    </div>
                    <div style={{ paddingTop: 40 }}>
                        <div className="flex flex-row">
                            <Link to="/state">
                                <div className="flex flex-col" style={{ width: 229, border: '2px solid #58AFAE', height: 229, justifyContent: 'center', alignItems: 'center', backgroundColor: '#DAEEEE', borderRadius: 20 }}>
                                    <p className="text-2xl pb-2 text-green-800 font-medium" style={{ textAlign: 'center' }}>
                                        Estado
                                    </p>
                                    <div style={{ width: 165, height: 104, alignItems: 'center' }}>
                                        <img src={ImgEstado} alt="Abrir Cadastro de Estado" />
                                    </div>
                                </div>
                            </Link>
                            <Link to="/city">
                                <div className="flex flex-col ml-12" style={{ width: 229, border: '2px solid #58AFAE', height: 229, justifyContent: 'center', alignItems: 'center', backgroundColor: '#DAEEEE', borderRadius: 20 }}>
                                    <p className="text-2xl pb-2 text-green-800 font-medium" style={{ textAlign: 'center' }}>
                                        Cidade
                                    </p>
                                    <div style={{ width: 165, height: 104, alignItems: 'center' }}>
                                        <img src={ImgCidade} alt="Abrir Cadastro de Estado" />
                                    </div>
                                </div>
                            </Link>
                            <Link to="/user">
                                <div className="flex flex-col ml-12" style={{ width: 229, border: '2px solid #58AFAE', height: 229, justifyContent: 'center', alignItems: 'center', backgroundColor: '#DAEEEE', borderRadius: 20 }}>
                                    <p className="text-2xl pb-2 text-green-800 font-medium" style={{ textAlign: 'center' }}>
                                        Usuário
                                    </p>
                                    <div style={{ width: 104, height: 104, alignItems: 'center' }}>
                                        <img src={ImgUsuario} alt="Abrir Cadastro de Estado" />
                                    </div>
                                </div>
                            </Link>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}