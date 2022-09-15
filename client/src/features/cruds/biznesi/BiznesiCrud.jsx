import React, { useContext } from 'react'
import { GWContext } from '../../../context/GWContext'  
import CrudTable from '../../../components/tables/CrudTable'
import { useState } from 'react'
import CreateBiznes from './CreateBiznes'

const BiznesiCrud = () => {

  const { bizneset } = useContext(GWContext);
  const[showCreate, setShowCreate] = useState(false);
  const[isForUpdate, setIsForUpdate] = useState(false);
  const[biznesiId, setBiznesiId] = useState(0);

  return (
    <>
      <h3>Bizneset</h3>
      <button onClick={() => {setShowCreate(!showCreate); 
                              setIsForUpdate(false)}}>
                                Shto Biznes</button>
      <CrudTable 
        apiObjects={bizneset} 
        objectName="Bizneset" 
        showCreate={showCreate} 
        setShowCreate={setShowCreate}
        setIsForUpdate={setIsForUpdate}
        setObjectId={setBiznesiId}
        />
      {showCreate ? <CreateBiznes 
                      showCreate={showCreate} 
                      setShowCreate={setShowCreate}
                      setIsForUpdate={setIsForUpdate}
                      isForUpdate={isForUpdate}
                      biznesiId={biznesiId}
                      /> : null}
    </>
  )
}

export default BiznesiCrud