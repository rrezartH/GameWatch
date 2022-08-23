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
import CmimorjaCrud from '../cruds/cmimorja/CmimorjaCrud';

const Dashboard = () => {
  return (
    <>
        <div className="dashboard-nav">
            <button><Link to="./">Bizneset</Link></button>
            <button><Link to="./Lokalet">Lokalet</Link></button>
            <button><Link to="./Konzolat">Konzolat</Link></button>
            <button><Link to="./BiznesiKonzolat">BizKon</Link></button>
            <button><Link to="./BizneziKonzolaVideolojat">BizKonVid</Link></button>
            <button><Link to="./Faturat">Faturat</Link></button>
            <button><Link to="./Cmimoret">Cmimoret</Link></button>
            <button><Link to="./VideoLojat">VideoLojat</Link></button>
        </div>

        <Routes>
            <Route path='/' element={<BiznesiCrud />} />
            <Route path='/Lokalet' element={<LokaliCrud />} />
            <Route path='/Konzolat' element={<KonzolatCrud />} />
            <Route path='/BiznesiKonzolat' element={<BiznesiKonzolaCrud />} />
            <Route path='/BizneziKonzolaVideolojat' element={<BiznesiKonzolaVideolojaCrud />} />
            <Route path='/Faturat' element={<FaturaCrud />} />
            <Route path='/Cmimoret' element={<CmimorjaCrud />} />
            <Route path='/VideoLojat' element={<VideoLojaCrud />} />
        </Routes>
    </> 
  )
}

export default Dashboard