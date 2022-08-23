import React, { useContext, useState } from 'react'
import { GWContext } from '../../../context/GWContext'  
import CrudTable from '../../../components/crud-table/CrudTable'
import CreateLokal from './CreateLokal'

const LokaliCrud = () => {
    const { lokalet } = useContext(GWContext)
    const[showCreate, setShowCreate] = useState(false);
    
  return (
    <>
      <h3>Lokalet</h3>
      <button onClick={() => setShowCreate(!showCreate)}>Shto Lokal</button>
      <CrudTable apiObjects = {lokalet} objectName="Lokalet"/>
      {showCreate ? <CreateLokal showCreate={showCreate} setShowCreate={setShowCreate} /> : null}
    </>
  )
}

export default LokaliCrud