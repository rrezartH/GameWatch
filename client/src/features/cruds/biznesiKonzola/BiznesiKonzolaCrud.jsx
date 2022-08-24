import React, { useContext, useState } from 'react'
import { GWContext } from '../../../context/GWContext'  
import CrudTable from '../../../components/crud-table/CrudTable'
import CreateBiznesiKonzola from './CreateBiznesiKonzola'

const BiznesiKonzolaCrud = () => {

  const { biznesiKonzolat } = useContext(GWContext)
  const [showCreate, setShowCreate] = useState(false);
  const[isForUpdate, setIsForUpdate] = useState(false);
  const[biznesiKonzolaId, setBiznesiKonzolaId] = useState(0);

  return (
    <>
      <h3>BizKon</h3>
      <button onClick={() => setShowCreate(!showCreate)}>Shto BiznesiKonzola</button>
      <CrudTable 
        apiObjects={biznesiKonzolat} 
        objectName="BiznesiKonzolat"
        showCreate={showCreate} 
        setShowCreate={setShowCreate}
        setIsForUpdate={setIsForUpdate} 
        setObjectId={setBiznesiKonzolaId}
        />
      {showCreate ? <CreateBiznesiKonzola 
                      showCreate={showCreate} 
                      setShowCreate={setShowCreate} 
                      setIsForUpdate={setIsForUpdate}
                      isForUpdate={isForUpdate}
                      biznesiKonzolaId={biznesiKonzolaId}
                      /> : null}
    </>
  )
}

export default BiznesiKonzolaCrud