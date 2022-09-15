import React, { useContext, useState } from 'react'
import { GWContext } from '../../../context/GWContext'  
import CrudTable from '../../../components/tables/CrudTable'
import CreateCmimore from './CreateCmimore'

const CmimorjaCrud = () => {

  const { cmimoret } = useContext(GWContext)
  const[showCreate, setShowCreate] = useState(false);
  const[isForUpdate, setIsForUpdate] = useState(false);
  const[cmimorjaId, setCmimorjaId] = useState(0);

  return (
    <>
      <h3>Cmimoret</h3>
      <button onClick={() => {setShowCreate(!showCreate); 
                              setIsForUpdate(false)}}>Shto Cmimore</button>
      <CrudTable 
        apiObjects={cmimoret} 
        objectName="Cmimoret"
        setShowCreate={setShowCreate}
        setIsForUpdate={setIsForUpdate}
        setObjectId={setCmimorjaId}
        />
      {showCreate ? <CreateCmimore 
                      showCreate={showCreate} 
                      setShowCreate={setShowCreate} 
                      setIsForUpdate={setIsForUpdate}
                      isForUpdate={isForUpdate}
                      cmimorjaId={cmimorjaId}
                      /> : null}
    </>
  )
}

export default CmimorjaCrud