import React, { useContext, useState } from 'react'
import { GWContext } from '../../../context/GWContext'  
import CrudTable from '../../../components/crud-table/CrudTable'
import CreateCmimore from './CreateCmimore'

const CmimorjaCrud = () => {

  const { cmimoret } = useContext(GWContext)
  const[showCreate, setShowCreate] = useState(false);

  return (
    <>
      <h3>Cmimoret</h3>
      <button onClick={() => setShowCreate(!showCreate)}>Shto Cmimore</button>
      <CrudTable apiObjects = {cmimoret} objectName="Cmimoret"/>
      {showCreate ? <CreateCmimore showCreate={showCreate} setShowCreate={setShowCreate} /> : null}
    </>
  )
}

export default CmimorjaCrud