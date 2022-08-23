import React, { useContext, useState } from 'react'
import { GWContext } from '../../../context/GWContext'  
import CrudTable from '../../../components/crud-table/CrudTable'
import CreateBiznesiKonzola from './CreateBiznesiKonzola'

const BiznesiKonzolaCrud = () => {

  const { biznesiKonzolat } = useContext(GWContext)
  const [showCreate, setShowCreate] = useState(false);

  return (
    <>
      <h3>Bizneset</h3>
      <button onClick={() => setShowCreate(!showCreate)}>Shto BiznesiKonzola</button>
      <CrudTable apiObjects = {biznesiKonzolat} objectName="BiznesiKonzolat" />
      {showCreate ? <CreateBiznesiKonzola showCreate={showCreate} setShowCreate={setShowCreate} /> : null}
    </>
  )
}

export default BiznesiKonzolaCrud