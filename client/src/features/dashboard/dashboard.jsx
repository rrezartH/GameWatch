import React from 'react'
import './dashboard-style.scss'
import { Route, Routes, Link } from 'react-router-dom';
import BiznesiCrud from '../cruds/biznesi/BiznesiCrud';
import LokaliCrud from '../cruds/lokali/LokaliCrud';
import KonzolatCrud from '../cruds/konzola/KonzolatCrud';
import BiznesiKonzolaCrud from '../cruds/biznesiKonzola/BiznesiKonzolaCrud';
import VideoLojaCrud from '../cruds/videoloja/VideoLojaCrud';
import FaturaCrud from '../cruds/fatura/FaturaCrud';
import BiznesiKonzolaVideolojaCrud from '../cruds/biznesiKonzolaVideoloja/BiznesiKonzolaVideolojaCrud';

const Dashboard = () => {
  return (
    <>
        <h3>Dashboard</h3>

        <div className="dashboard-nav">
            <Link to="./Bizneset">Bizneset</Link>
            <Link to="./Lokalet">Lokalet</Link>
            <Link to="./Konzolat">Konzolat</Link>
            <Link to="./BiznesiKonzolat">BiznesiKonzolat</Link>
            <Link to="./BizneziKonzolaVideolojat">BizneziKonzolaVideolojat</Link>
            <Link to="./Faturat">Faturat</Link>
            <Link to="./VideoLojat">VideoLojat</Link>
        </div>

        <Routes>
            <Route path='/Bizneset' element={<BiznesiCrud />} />
            <Route path='/Lokalet' element={<LokaliCrud />} />
            <Route path='/Konzolat' element={<KonzolatCrud />} />
            <Route path='/BiznesiKonzolat' element={<BiznesiKonzolaCrud />} />
            <Route path='/BizneziKonzolaVideolojat' element={<BiznesiKonzolaVideolojaCrud />} />
            <Route path='/Faturat' element={<FaturaCrud />} />
            <Route path='/VideoLojat' element={<VideoLojaCrud />} />
        </Routes>
    </> 
  )
}

export default Dashboard