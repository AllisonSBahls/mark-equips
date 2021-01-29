import React from 'react';
import './App.css';
import Routes from './Routes';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

export default function App() {
  return (
    <>
    <Routes />
    <ToastContainer />
    </>
  );
}
