import React, { useContext } from 'react'
import { GWContext } from '../../../context/GWContext'  
import { Link } from 'react-router-dom'
import CrudTable from '../../../components/crud-table/CrudTable'
import { useState } from 'react'
import CreateBiznes from './CreateBiznes'

const BiznesiCrud = () => {

  const { bizneset } = useContext(GWContext);
  const[showCreate, setShowCreate] = useState(false);

  return (
    <>
      <h3>Bizneset</h3>
      <button onClick={() => setShowCreate(!showCreate)}>Shto Biznes</button>
      <CrudTable apiObjects={bizneset} objectName="Bizneset" />
      {showCreate ? <CreateBiznes showCreate={showCreate} setShowCreate={setShowCreate} /> : null}
    </>
  )
}

export default BiznesiCrud