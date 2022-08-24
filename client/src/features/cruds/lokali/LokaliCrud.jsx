import React, { useContext, useState } from 'react'
import { GWContext } from '../../../context/GWContext'  
import CrudTable from '../../../components/crud-table/CrudTable'
import CreateLokal from './CreateLokal'

const LokaliCrud = () => {
    const { lokalet } = useContext(GWContext)
    const[showCreate, setShowCreate] = useState(false);
    const[isForUpdate, setIsForUpdate] = useState(false);
    const[lokaliId, setLokaliId] = useState(0);
    
  return (
    <>
      <h3>Lokalet</h3>
      <button onClick={() => {setShowCreate(!showCreate); 
                              setIsForUpdate(false)}}>Shto Lokal</button>
      <CrudTable 
        apiObjects={lokalet} 
        objectName="Lokalet"
        showCreate={showCreate} 
        setShowCreate={setShowCreate}
        setIsForUpdate={setIsForUpdate}
        setObjectId={setLokaliId}
      />
      {showCreate ? <CreateLokal 
                      showCreate={showCreate} 
                      setShowCreate={setShowCreate} 
                      setIsForUpdate={setIsForUpdate}
                      isForUpdate={isForUpdate}
                      lokaliId={lokaliId}
                      /> : null}
    </>
  )
}

export default LokaliCrud