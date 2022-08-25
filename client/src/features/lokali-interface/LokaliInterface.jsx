import React from 'react'
import { Link, Route, Routes } from 'react-router-dom'
import Cmimorja from './Cmimorja'
import Faturat from './Faturat'
import Konzolat from './Konzolat'

const LokaliInterface = () => {
  return (
    <>
        <div className="dashboard-nav">
            <button><Link to="./">Konzolat</Link></button>
            <button><Link to="./Faturat">Faturat</Link></button>
            <button><Link to="./Cmimorja">Cmimorja</Link></button>
        </div>

        <h3>Pershendetje!</h3>

        <Routes>
            <Route path='/' element={<Konzolat />} />
            <Route path='/Faturat' element={<Faturat />} />
            <Route path='/Cmimorja' element={<Cmimorja />} />
        </Routes>
    </>
  )
}

export default LokaliInterface