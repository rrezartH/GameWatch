import React from 'react'
import './dashboard-style.scss'
import { Route, Routes, Link } from 'react-router-dom';
import BiznesiCrud from '../cruds/biznesi/BiznesiCrud';

const Dashboard = () => {
  return (
    <>
        <h3>Dashboard</h3>

        <div className="dashboard-nav">
            <Link to="./Bizneset">Bizneset</Link>
            <Link to="./Bizneset">Bizneset</Link>
            <Link to="./Bizneset">Bizneset</Link>
            <Link to="./Bizneset">Bizneset</Link>
        </div>

        <Routes>
            <Route path='/Bizneset' element={<BiznesiCrud />} />
        </Routes>
    </> 
  )
}

export default Dashboard